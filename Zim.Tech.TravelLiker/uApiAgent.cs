using System;
using System.IO;
using System.Xml;
using System.Xml.Linq;
using System.Linq;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Configuration;
using System.Reflection;
using System.Globalization;
using System.Runtime.Serialization;

using Zim.Tech.TravelLiker.Common;
using Zim.Tech.TravelLiker.Travelport.uAPI;
using Zim.Tech.TravelLiker.Travelport.uAPI.Connection;
using uAPIUnit = Zim.Tech.TravelLiker.Travelport.uAPI.Util;
using uAPIFlight = Zim.Tech.TravelLiker.Travelport.uAPI.Air;
using uAPIHotel = Zim.Tech.TravelLiker.Travelport.uAPI.Hotel;
using Zim.Tech.TravelLiker.Flight;
using Zim.Tech.TravelLiker.Hotel;

namespace Zim.Tech.TravelLiker
{
    public class uApiAgent
    {
        #region uApiAgent Variables
        private string NAMESPACE_AIR = "http://www.travelport.com/schema/air_v25_0";
        private string NAMESPACE_HOTEL = "http://www.travelport.com/schema/hotel_v25_0";
        private string NAMESPACE_COMMON = "http://www.travelport.com/schema/common_v25_0";
        Configuration config;

        private string sUserID = string.Empty;
        private string sPassword = string.Empty;
        private string sURL = string.Empty;
        private string sAuthorizedBy = string.Empty;
        private string sTraceId = string.Empty;
        private string sTargetBranch = string.Empty;
        int iMaxSearchResult;
        int iWebRequestMaxRetries;
        int iWebRequestTimeout;
        
        bool Connected = false;
        private IUniversalApiConnection connection;
        #endregion

        
        #region Constructors
        /// <summary>
        /// TravelAgent Constructors
        /// </summary>
        public uApiAgent()
        {
            string sDllPath = new Uri(Assembly.GetExecutingAssembly().GetName().CodeBase).LocalPath;
            config = ConfigurationManager.OpenExeConfiguration(sDllPath);

            sUserID = config.AppSettings.Settings["UserID"].Value;
            sPassword = config.AppSettings.Settings["Password"].Value;
            sURL = config.AppSettings.Settings["URL"].Value;
            sAuthorizedBy = config.AppSettings.Settings["AuthorizedBy"].Value;
            sTraceId = config.AppSettings.Settings["TraceId"].Value;
            sTargetBranch = config.AppSettings.Settings["TargetBranch"].Value;
            string sWebRequestMaxRetries = config.AppSettings.Settings["WebRequestMaxRetries"].Value;
            string sWebRequestTimeout = config.AppSettings.Settings["WebRequestTimeout"].Value;
            string sMaxSearchResult = config.AppSettings.Settings["MaxSearchResult"].Value;

            iMaxSearchResult = (string.IsNullOrEmpty(sMaxSearchResult)) ? 5 : Convert.ToInt16(sMaxSearchResult);
            iWebRequestMaxRetries = (string.IsNullOrEmpty(sWebRequestMaxRetries)) ? 3 : Convert.ToInt16(sWebRequestMaxRetries);
            iWebRequestTimeout = (string.IsNullOrEmpty(sWebRequestTimeout)) ? 500 : Convert.ToInt16(sWebRequestTimeout);
        }
        #endregion

        #region Connection
        private bool OpenConnection()
        {
            connection = new UniversalApiConnection();

            connection.UserName = sUserID;
            connection.Password = sPassword;
            connection.Uri = new Uri(sURL);

            Connected = true;

            return Connected;
        }
        #endregion

        #region Preparation
        internal T PrepareHeader<T>() where T : new()
        {
            T xRequest = new T();
            string PropertieName = "AuthorizedBy";
            if (xRequest.GetType().GetProperties().Any(p => p.Name == PropertieName))
                xRequest.GetType().GetProperty(PropertieName).SetValue(xRequest, "user", null); //Universal API/uAPI6768275016-96b0fd84
            PropertieName = "TraceId";
            if (xRequest.GetType().GetProperties().Any(p => p.Name == PropertieName))
                xRequest.GetType().GetProperty(PropertieName).SetValue(xRequest, "trace", null);
            PropertieName = "TargetBranch";
            if (xRequest.GetType().GetProperties().Any(p => p.Name == PropertieName))
                xRequest.GetType().GetProperty(PropertieName).SetValue(xRequest, "P7009887", null);

            return xRequest;
        }
        #endregion

        #region LowFareSearch
        public FareQuote LowFareSearch(FareQuote.FareType fareType, List<FareQuote.SearchInfo> listSearchInfo, decimal maxAmount)
        {
            FareQuote FareQute = new FareQuote();
            string sLowFareSearchReq = PrepareLowFareSearchReq(fareType, listSearchInfo, maxAmount);

            XmlDocument request = new XmlDocument();
            request.LoadXml(sLowFareSearchReq);

            if (Connected == false)
                OpenConnection();

            connection.Uri = new Uri(connection.Uri, "AirService");
            XmlDocument responseDocument = connection.SendRequest(request);

            try
            {
                FareQute = DeserializeLowFareSearchResp(responseDocument.OuterXml);
                if (FareQute.RresultCount > 0)
                {
                    //Handle Max Amount
                    if (maxAmount > 0)
                    {
                        var oAirPricingSolution = (from p in FareQute.AirPricingSolutions
                                                  where Convert.ToDecimal(p.TotalPrice) <= maxAmount
                                                  select p).ToList();
                        FareQute.AirPricingSolutions = oAirPricingSolution;
                    }
                }
            }
            catch(Exception ex)
            {

            }

            return FareQute;
        }

        internal string PrepareLowFareSearchReq(FareQuote.FareType fareType, List<FareQuote.SearchInfo> listSearchInfo, decimal maxAmount)
        {
            string sLowFareSearchReq = string.Empty;
            uAPIFlight.LowFareSearchReq oLowFareSearchReq = PrepareHeader<uAPIFlight.LowFareSearchReq>(); //new uAPIFlight.LowFareSearchReq();

            oLowFareSearchReq.SolutionResult = true;
            //uAPIFlight.LowFareSearchReq oLowFareSearchReq = new uAPIFlight.LowFareSearchReq();
            oLowFareSearchReq.BillingPointOfSaleInfo = new uAPIFlight.BillingPointOfSaleInfo() { OriginApplication = "UAPI" };

            #region Direct Flight (NonStop) Value
            bool bPreferNonStop = listSearchInfo[0].DirectFlightOnly;
            #endregion

            #region Search Origin Destination Values
            List<uAPIFlight.SearchAirLeg> oSearchAirLegList = new List<uAPIFlight.SearchAirLeg>();
            foreach (FareQuote.SearchInfo oSearchInfo in listSearchInfo)
            {
                uAPIFlight.SearchAirLeg oSearchAirLeg = new uAPIFlight.SearchAirLeg();
                oSearchAirLeg.SearchOrigin = new uAPIFlight.typeSearchLocation[1] { (new uAPIFlight.typeSearchLocation() { Item = new uAPIFlight.Airport() { Code = oSearchInfo.FromCity } }) };
                oSearchAirLeg.SearchDestination = new uAPIFlight.typeSearchLocation[1] { (new uAPIFlight.typeSearchLocation() { Item = new uAPIFlight.Airport() { Code = oSearchInfo.ToCity } }) };
                oSearchAirLeg.Items = new uAPIFlight.typeFlexibleTimeSpec[1] { (new uAPIFlight.typeFlexibleTimeSpec() { PreferredTime = oSearchInfo.StartDate }) };
                oSearchAirLegList.Add(oSearchAirLeg);
            }
            oLowFareSearchReq.Items = oSearchAirLegList.ToArray();
            #endregion

            #region Passenger Values
            List<uAPIFlight.SearchPassenger> oSearchPassengerList = new List<uAPIFlight.SearchPassenger>();
            oLowFareSearchReq.AirSearchModifiers = new uAPIFlight.AirSearchModifiers() { MaxSolutions = iMaxSearchResult.ToString(), PreferNonStop = bPreferNonStop };
            for (int i = 1; i <= listSearchInfo[0].Adults; i++)
                oSearchPassengerList.Add(new uAPIFlight.SearchPassenger() { Code = "ADT" });
            oLowFareSearchReq.SearchPassenger = oSearchPassengerList.ToArray();
            #endregion

            #region CurrencyType Value
            //oLowFareSearchReq.SearchPassenger = new SearchPassenger[1] { new SearchPassenger() { BookingTravelerRef = "gr8AVWGCR064r57Jt0+8bA==", Code = "ADT" } };
            oLowFareSearchReq.AirPricingModifiers = new uAPIFlight.AirPricingModifiers() { CurrencyType = "HKD" };
            #endregion

            #region Group By Result
            uAPIFlight.SolutionGroup oSolutionGroup = new uAPIFlight.SolutionGroup() { TripType = uAPIFlight.typeTripType.Cheapest, Diversification = uAPIFlight.typeDiversity.Carrier };
            List<uAPIFlight.SolutionGroup> oSolutionGroupList = new List<uAPIFlight.SolutionGroup>();
            oSolutionGroupList.Add(oSolutionGroup);
            oLowFareSearchReq.Enumeration = oSolutionGroupList.ToArray();
            #endregion


            //string xml = Serialize<uAPIFlight.LowFareSearchReq>.SerializeXmlToString(oLowFareSearchReq);
            List<XmlNamespace> xmlNamespaces = new List<XmlNamespace>() { 
                (new XmlNamespace() { NameSpace = "air", Url=NAMESPACE_AIR}), 
                (new XmlNamespace() { NameSpace = "com", Url=NAMESPACE_COMMON})
            };

            sLowFareSearchReq = Serialize<uAPIFlight.LowFareSearchReq>.SerializeXmlToString(xmlNamespaces, oLowFareSearchReq);
            //File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "LowFareSearchReq.xml"), sLowFareSearchReq);

            return sLowFareSearchReq;
        }

        internal FareQuote DeserializeLowFareSearchResp(string sXmlContents)
        {
            XElement xRoot = XElement.Parse(sXmlContents);
            sXmlContents = Serialize<uAPIFlight.LowFareSearchRsp>.RemoveAllNamespaces(xRoot).ToString();
            //File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "LowFareSearchResp.xml"), sXmlContents);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(sXmlContents);

            List<Flight.AirPricingSolution> AirPricingSolutionList = new List<Flight.AirPricingSolution>();
            Flight.FlightDetailsList oFlightDetailsList = new Flight.FlightDetailsList();
            Flight.AirSegmentList oAirSegmentList = new Flight.AirSegmentList();
            Flight.RouteList oRouteList = new Flight.RouteList();
            Flight.FareInfoList oFareInfoList = new Flight.FareInfoList();

            XmlNodeList LowFareSearchRsp = xmlDoc.GetElementsByTagName("LowFareSearchRsp");
            foreach (XmlNode node in LowFareSearchRsp)
            {
                foreach (XmlNode childnode in node.ChildNodes)
                {
                    if (childnode.Name == "FlightDetailsList")
                    {
                        oFlightDetailsList = Serialize<Flight.FlightDetailsList>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        foreach (XmlNode subchildnode in childnode.ChildNodes)
                        {
                            if (subchildnode.Name == "FlightDetails")
                            {
                                Flight.FlightDetails oFlightDetails = Serialize<Flight.FlightDetails>.DeserializeXmlFromStringWithoutNamespace(subchildnode.OuterXml);
                            }
                        }
                    }

                    if (childnode.Name == "AirSegmentList")
                    {
                        oAirSegmentList = Serialize<Flight.AirSegmentList>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        foreach (XmlNode subchildnode in childnode.ChildNodes)
                        {
                            if (subchildnode.Name == "AirSegment")
                            {
                                Flight.AirSegment oAirSegment = Serialize<Flight.AirSegment>.DeserializeXmlFromStringWithoutNamespace(subchildnode.OuterXml);
                                //oAirSegmentList.FareInfo.Add(oAirSegment);
                            }
                        }
                    }

                    if (childnode.Name == "FareInfoList")
                    {
                        oFareInfoList = Serialize<Flight.FareInfoList>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        foreach (XmlNode subchildnode in childnode.ChildNodes)
                        {
                            if (subchildnode.Name == "FareInfo")
                            {
                                Flight.FareInfo oFareInfo = Serialize<Flight.FareInfo>.DeserializeXmlFromStringWithoutNamespace(subchildnode.OuterXml);
                                //oFareInfoList.FareInfo.Add(oFareInfo);
                            }
                        }
                    }

                    if (childnode.Name == "RouteList")
                    {
                        //uAPIFlight.Route[] oRouteList = Serialize<uAPIFlight.Route[]>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        oRouteList = Serialize<Flight.RouteList>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                    }
                    if (childnode.Name == "AirPricingSolution")
                    {
                        //uAPIFlight.typeBaseAirSegment oAirSegmentList = Serialize<uAPIFlight.typeBaseAirSegment>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        Flight.AirPricingSolution oAirPricingSolution = Serialize<Flight.AirPricingSolution>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        AirPricingSolutionList.Add(oAirPricingSolution);
                    }


                }
            }


            List<Flight.FareQuote.AirPricingSolution> airs = new List<Flight.FareQuote.AirPricingSolution>();
            foreach (Flight.AirPricingSolution airPricingSolution in AirPricingSolutionList)
            {
                Flight.FareQuote.AirPricingSolution air = new Flight.FareQuote.AirPricingSolution(airPricingSolution, oAirSegmentList, oRouteList, oFareInfoList, oFlightDetailsList);
                airs.Add(air);
            }

            FareQuote oFareQuote = new FareQuote();
            oFareQuote.AirPricingSolutions = airs;

            return oFareQuote;
        }
        #endregion

        #region HotelSearch
        public HotelQute HotelSearch(List<HotelQute.SearchInfo> listSearchInfo, decimal maxAmount)
        {
            HotelQute oHotelQute = new HotelQute();
            return oHotelQute;
        }

        public string PrepareHotelSearchAvailabilityReq(List<HotelQute.SearchInfo> listSearchInfo, decimal maxAmount)
        {
            string sHotelSearchAvailabilityReq = string.Empty;
            uAPIHotel.HotelSearchAvailabilityReq oHotelSearchAvailabilityReq = PrepareHeader<uAPIHotel.HotelSearchAvailabilityReq>(); //new uAPIFlight.LowFareSearchReq();

            //uAPIFlight.LowFareSearchReq oLowFareSearchReq = new uAPIFlight.LowFareSearchReq();
            oHotelSearchAvailabilityReq.BillingPointOfSaleInfo = new uAPIHotel.BillingPointOfSaleInfo() { OriginApplication = "UAPI" };

            #region Hotel Location Values
            foreach (HotelQute.SearchInfo oSearchInfo in listSearchInfo)
            {
                oHotelSearchAvailabilityReq.HotelLocation = new uAPIHotel.HotelLocation() { Location = oSearchInfo.Location };
                uAPIHotel.HotelSearchModifiers oHotelSearchModifiers = new uAPIHotel.HotelSearchModifiers();
                if (oSearchInfo.Adults > 0)
                {
                    oHotelSearchModifiers.NumberOfAdultsSpecified = true;
                    oHotelSearchModifiers.NumberOfAdults = oSearchInfo.Adults;
                }
                if (oSearchInfo.Rooms > 0)
                {
                    oHotelSearchModifiers.NumberOfRoomsSpecified = true;
                    oHotelSearchModifiers.NumberOfRooms = oSearchInfo.Rooms;
                }
                oHotelSearchModifiers.PermittedProviders = new uAPIHotel.PermittedProviders() { Provider = new uAPIHotel.Provider() { Code = "1G" } };
                oHotelSearchAvailabilityReq.HotelSearchModifiers = oHotelSearchModifiers;

                oHotelSearchAvailabilityReq.HotelSearchModifiers.AvailableHotelsOnly = true;
                oHotelSearchAvailabilityReq.HotelSearchModifiers.AvailableHotelsOnlySpecified = true;
                oHotelSearchAvailabilityReq.HotelSearchModifiers.PreferredCurrency = "HKD";

                #region CheckInOUt Date Values
                oHotelSearchAvailabilityReq.HotelStay = new uAPIHotel.HotelStay();
                oHotelSearchAvailabilityReq.HotelStay.CheckinDate = oSearchInfo.CheckInDate;
                oHotelSearchAvailabilityReq.HotelStay.CheckoutDate = oSearchInfo.CheckOutDate;
                #endregion
            }
            #endregion


            List<XmlNamespace> xmlNamespaces = new List<XmlNamespace>() { 
                (new XmlNamespace() { NameSpace = "hot", Url=NAMESPACE_HOTEL}), 
                (new XmlNamespace() { NameSpace = "com", Url=NAMESPACE_COMMON})
            };

            sHotelSearchAvailabilityReq = Serialize<uAPIHotel.HotelSearchAvailabilityReq>.SerializeXmlToString(xmlNamespaces, oHotelSearchAvailabilityReq);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "HotelSearchAvailabilityReq.xml"), sHotelSearchAvailabilityReq);

            return sHotelSearchAvailabilityReq;
        }
        #endregion
    }
}
