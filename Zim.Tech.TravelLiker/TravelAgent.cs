using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using System.Reflection;
using System.Configuration;
using System.Threading.Tasks;

using Zim.Tech.TravelLiker.Flight;
using Zim.Tech.TravelLiker.Travelport.uAPI.Connection;
using uAPIUnit = Zim.Tech.TravelLiker.Travelport.uAPI.Util;
using uAPIFlight = Zim.Tech.TravelLiker.Travelport.uAPI.Air;

namespace Zim.Tech.TravelLiker
{
    public class TravelAgent
    {

        #region TravelAgent Variables
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
        public FareQuote FlightOneWay(string fromCity, string toCity, DateTime frightDate, int adults, int children, bool directFlightOnly, string frightClass, string specifiedAirline, decimal maxAmount, out string errorMessage)
        {
            errorMessage = string.Empty;
            FareQuote FareQute = new FareQuote();

            List<FareQuote.SearchInfo> listSearchInfo = new List<FareQuote.SearchInfo>();
            listSearchInfo.Add(new FareQuote.SearchInfo(fromCity, toCity, frightDate, adults, children, directFlightOnly, frightClass, specifiedAirline));
            uApiAgent agent = new uApiAgent();
            FareQute = agent.LowFareSearch(FareQuote.FareType.OneWay, listSearchInfo, maxAmount);

            return FareQute;
        }

        public FareQuote FlightRoundTrip(string fromCity, string toCity, DateTime fromDate, DateTime toDate, int adults, int children, bool directFlightOnly, string frightClass, string specifiedAirline, decimal maxAmount, out string errorMessage)
        {
            errorMessage = string.Empty;
            FareQuote FareQute = new FareQuote();

            List<FareQuote.SearchInfo> listSearchInfo = new List<FareQuote.SearchInfo>();
            listSearchInfo.Add(new FareQuote.SearchInfo(fromCity, toCity, fromDate, adults, children, directFlightOnly, frightClass, specifiedAirline));
            listSearchInfo.Add(new FareQuote.SearchInfo(toCity, fromCity, toDate, adults, children, directFlightOnly, frightClass, specifiedAirline));
            uApiAgent agent = new uApiAgent();
            FareQute = agent.LowFareSearch(FareQuote.FareType.RoundTrip, listSearchInfo, maxAmount);

            return FareQute;
        }

        #endregion

        #region Hotel Agnet
        public List<Object> HotelEnquiy(string sCity, DateTime CheckIn, int StayDays, int NoOfRoom, string BedType, decimal maxAmount, out string errorMessage)
        {
            errorMessage = string.Empty;
            List<Object> HotelResult = new List<Object>();

            return HotelResult;
        }
        #endregion
    }
}
