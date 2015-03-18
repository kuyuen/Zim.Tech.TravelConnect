using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Reflection;
using System.Configuration;
using System.Threading.Tasks;

using Zim.Tech.TravelLiker.Flight;

namespace Zim.Tech.TravelLiker
{
    public class TravelAgent : IFlight, IHotel
    {
        Configuration config;

        #region TravelAgent Variables
        private string sUserID = string.Empty;
        private string sPassword = string.Empty;
        private string sURL = string.Empty;
        private string sAuthorizedBy = string.Empty;
        private string sTraceId = string.Empty;
        private string sTargetBranch = string.Empty;
        int iWebRequestMaxRetries;
        int iWebRequestTimeout;
        #endregion

        #region Constructors
        /// <summary>
        /// TravelAgent Constructors
        /// </summary>
        public TravelAgent()
        {
            string sDllPath = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
            config = ConfigurationManager.OpenExeConfiguration(sDllPath);

            string sWebRequestMaxRetries = config.AppSettings.Settings["WebRequestMaxRetries"].Value;
        }
        #endregion
        
        #region Flight Agnet
        public List<FareQuote> FlightOneWay(string fromCity, string toCity, DateTime frightDate, int adults, int children, int infantWOS, bool directFlightOnly, string frightClass, string specifiedAirline, decimal maxAmount, out string errorMessage)
        {
            errorMessage = string.Empty;
            List<FareQuote> FareQute = new List<FareQuote>();

            return FareQute;
        }

        public List<FareQuote> FlightRoundTrip(string fromCity, string toCity, DateTime fromDate, DateTime toDate, int adults, int children, int infantWOS, bool directFlightOnly, string frightClass, string specifiedAirline, decimal maxAmount, out string errorMessage)
        {
            errorMessage = string.Empty;
            List<FareQuote> FareQute = new List<FareQuote>();

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
