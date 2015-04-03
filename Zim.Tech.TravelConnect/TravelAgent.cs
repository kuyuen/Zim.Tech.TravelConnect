using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.Configuration;
using System.Threading.Tasks;

using Zim.Tech.TravelConnect.Flight;
using Zim.Tech.TravelConnect.Hotel;
using Zim.Tech.TravelConnect.Travelport.uAPI.Connection;
using uAPIUnit = Zim.Tech.TravelConnect.Travelport.uAPI.Util;
using uAPIFlight = Zim.Tech.TravelConnect.Travelport.uAPI.Air;

namespace Zim.Tech.TravelConnect
{
    public class TravelAgent
    {
        #region TravelAgent Variables
        public bool DebugMode = false; // Flight Agent Debug Mode 
        public bool AsyncMode = false; // Flight Agent Request in Async
        public int MaxResult = 10;

        private string sUserID = string.Empty;
        private string sPassword = string.Empty;
        private string sURL = string.Empty;
        private string sAuthorizedBy = string.Empty;
        private string sTraceId = string.Empty;
        private string sTargetBranch = string.Empty;
        int iWebRequestMaxRetries;
        int iWebRequestTimeout;

        bool Connected = false;
        private IUniversalApiConnection connection;
        #endregion

        #region Constructors
        /// <summary>
        /// TravelAgent Constructors
        /// </summary>
        public TravelAgent()
        {
            //string sDllPath = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
            //config = ConfigurationManager.OpenExeConfiguration(sDllPath);

            //string sUserID = config.AppSettings.Settings["UserID"].Value;
            //string sPassword = config.AppSettings.Settings["Password"].Value;
            //string sURL = config.AppSettings.Settings["URL"].Value;
            //string sAuthorizedBy = config.AppSettings.Settings["AuthorizedBy"].Value;
            //string sTraceId = config.AppSettings.Settings["TraceId"].Value;
            //string sTargetBranch = config.AppSettings.Settings["TargetBranch"].Value;
            //string sWebRequestMaxRetries = config.AppSettings.Settings["WebRequestMaxRetries"].Value;
            //string sWebRequestTimeout = config.AppSettings.Settings["WebRequestTimeout"].Value;
            //iWebRequestMaxRetries = (string.IsNullOrEmpty(sWebRequestMaxRetries)) ? 3 : Convert.ToInt16(sWebRequestMaxRetries);
            //iWebRequestTimeout = (string.IsNullOrEmpty(sWebRequestTimeout)) ? 500 : Convert.ToInt16(sWebRequestTimeout);
        }
        #endregion


        #region Flight Agnet
        public FareQuote FlightOneWay(string fromCity, string toCity, DateTime frightDate, int adults, int children, bool directFlightOnly, FareQuote.SearchInfo.CabinClass frightClass, string specifiedAirline, decimal maxAmount)
        {
            FareQuote FareQute = new FareQuote();

            if (fromCity == toCity)
                FareQute.ErrorMessages.Add((new FareQuote.ErrorMessage() { Value = "OneWay searching criteria invalid (From City = To City)" }) );
            else if (frightDate < DateTime.Today)
                FareQute.ErrorMessages.Add((new FareQuote.ErrorMessage() { Value = "OneWay searching criteria invalid (frightDate before Today)" }));

            if (FareQute.ErrorMessages.Count == 0)
            {
                List<FareQuote.SearchInfo> listSearchInfo = new List<FareQuote.SearchInfo>();
                listSearchInfo.Add(new FareQuote.SearchInfo(fromCity, toCity, frightDate, adults, children, directFlightOnly, frightClass, specifiedAirline));
                uApiAgent agent = new uApiAgent();
                agent.MaxResult = MaxResult;
                FareQute = agent.LowFareSearch(FareQuote.FareType.OneWay, listSearchInfo, maxAmount);
            }

            return FareQute;
        }

        public FareQuote FlightRoundTrip(string fromCity, string toCity, DateTime fromDate, DateTime toDate, int adults, int children, bool directFlightOnly, FareQuote.SearchInfo.CabinClass frightClass, string specifiedAirline, decimal maxAmount)
        {
            FareQuote FareQute = new FareQuote();

            if (fromCity == toCity)
                FareQute.ErrorMessages.Add((new FareQuote.ErrorMessage() { Value = "Round Trip searching criteria invalid (From City = To City)" }) );
            else if (fromDate < DateTime.Today || fromDate >= toDate)
                FareQute.ErrorMessages.Add((new FareQuote.ErrorMessage() { Value = "Round Trip searching criteria invalid fromDate" }) );
            else if (toDate < DateTime.Today)
                FareQute.ErrorMessages.Add((new FareQuote.ErrorMessage() { Value = "Round Trip searching criteria invalid toDate" }) );

            if (FareQute.ErrorMessages.Count == 0)
            {
                List<FareQuote.SearchInfo> listSearchInfo = new List<FareQuote.SearchInfo>();
                listSearchInfo.Add(new FareQuote.SearchInfo(fromCity, toCity, fromDate, adults, children, directFlightOnly, frightClass, specifiedAirline));
                listSearchInfo.Add(new FareQuote.SearchInfo(toCity, fromCity, toDate, adults, children, directFlightOnly, frightClass, specifiedAirline));
                uApiAgent agent = new uApiAgent();
                agent.MaxResult = MaxResult;
                FareQute = agent.LowFareSearch(FareQuote.FareType.RoundTrip, listSearchInfo, maxAmount);
            }
            return FareQute;
        }

        #endregion

        #region Hotel Agnet
        public HotelQute HotelEnquiy(string City, DateTime CheckInDate, int StayDays, int NoOfRoom, string BedType, string specifiedHotel, decimal maxAmount)
        {
            HotelQute HotelQute = new HotelQute();

            if (string.IsNullOrEmpty(City))
                HotelQute.ErrorMessages.Add((new HotelQute.ErrorMessage() { Value = "Hotel searching criteria invalid City" }));
            else if (CheckInDate < DateTime.Today)
                HotelQute.ErrorMessages.Add((new HotelQute.ErrorMessage() { Value = "Hotel searching criteria invalid CheckInDate" }));
            else if (StayDays < 1)
                HotelQute.ErrorMessages.Add((new HotelQute.ErrorMessage() { Value = "Hotel searching criteria invalid StayDays" }));

            if (HotelQute.ErrorMessages.Count == 0)
            {
                List<HotelQute.SearchInfo> listSearchInfo = new List<HotelQute.SearchInfo>();
                listSearchInfo.Add(new HotelQute.SearchInfo(City, "", CheckInDate, StayDays, 0, NoOfRoom, BedType, specifiedHotel));
                uApiAgent agent = new uApiAgent();
                agent.MaxResult = MaxResult;
                HotelQute = agent.HotelSearch(listSearchInfo, maxAmount);
            }
            return HotelQute;
        }
        #endregion
    }
}
