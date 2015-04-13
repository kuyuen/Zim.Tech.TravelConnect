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

using Zim.Tech.TravelConnect.Common;
using Zim.Tech.TravelConnect.Travelport.uAPI;
using Zim.Tech.TravelConnect.Travelport.uAPI.Connection;
using uAPIUnit = Zim.Tech.TravelConnect.Travelport.uAPI.Util;
using uAPIFlight = Zim.Tech.TravelConnect.Travelport.uAPI.Air;
using uAPIHotel = Zim.Tech.TravelConnect.Travelport.uAPI.Hotel;
using uAPIBooking = Zim.Tech.TravelConnect.Travelport.uAPI.UniversalRecord;
using Zim.Tech.TravelConnect.Flight;
using Zim.Tech.TravelConnect.Hotel;

namespace Zim.Tech.TravelConnect
{
    public class uApiAgent
    {
        #region uApiAgent Variables
        private const string AIR_SERVICE = "AirService";
        private const string HOTEL_SERVICE = "HotelService";
        private string NAMESPACE_AIR = "http://www.travelport.com/schema/air_v30_0";
        private string NAMESPACE_HOTEL = "http://www.travelport.com/schema/hotel_v30_0";
        private string NAMESPACE_COMMON = "http://www.travelport.com/schema/common_v30_0";
        private string NAMESPACE_BOOKING = "http://www.travelport.com/schema/universal_v29_0";
        Configuration config;

        private string sUserID = string.Empty;
        private string sPassword = string.Empty;
        private string sURL = string.Empty;
        private string sAuthorizedBy = string.Empty;
        private string sTraceId = string.Empty;
        private string sTargetBranch = string.Empty;
        private int iMaxSearchResult;
        private int iWebRequestMaxRetries;
        private int iWebRequestTimeout;
        
        bool Connected = false;
        private IUniversalApiConnection connection;
        #endregion

        #region Public Properties
        public int MaxResult { get { return iMaxSearchResult; } set { iMaxSearchResult = value; } }
        public string ErrorMessage;
        #endregion

        #region Constructors
        /// <summary>
        /// TravelAgent Constructors
        /// </summary>
        public uApiAgent()
        {
            try
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
            catch(Exception ex)
            {
                ErrorMessage = "API Configure file (Zim.Tech.TravelConnect.dll.config) not found.";
            }
        }
        #endregion

        #region Connection
        private bool OpenConnection()
        {
            try
            {
                connection = new UniversalApiConnection();

                connection.UserName = sUserID;
                connection.Password = sPassword;
                connection.Uri = new Uri(sURL);

                Connected = true;
            }
            catch (Exception ex)
            {
                ErrorMessage = ex.Message;
            }
            return Connected;
        }
        #endregion

        #region Preparation
        internal T PrepareHeader<T>() where T : new()
        {
            T xRequest = new T();
            string PropertieName = "AuthorizedBy";
            if (xRequest.GetType().GetProperties().Any(p => p.Name == PropertieName))
                xRequest.GetType().GetProperty(PropertieName).SetValue(xRequest, sAuthorizedBy, null); //Universal API/uAPI6768275016-96b0fd84
            PropertieName = "TraceId";
            if (xRequest.GetType().GetProperties().Any(p => p.Name == PropertieName))
                xRequest.GetType().GetProperty(PropertieName).SetValue(xRequest, sTraceId, null);
            PropertieName = "TargetBranch";
            if (xRequest.GetType().GetProperties().Any(p => p.Name == PropertieName))
                xRequest.GetType().GetProperty(PropertieName).SetValue(xRequest, sTargetBranch, null);

            return xRequest;
        }
        #endregion

        private List<FareQuote.ErrorMessage> CheckConfigure()
        {
            List<FareQuote.ErrorMessage> ErrorMessages = new List<FareQuote.ErrorMessage>();
            if (string.IsNullOrEmpty(sUserID))
                ErrorMessages.Add((new FareQuote.ErrorMessage() { Type = ResponseMessageType.Error, Value = "UserID not found" }));
            if (string.IsNullOrEmpty(sPassword))
                ErrorMessages.Add((new FareQuote.ErrorMessage() { Type = ResponseMessageType.Error, Value = "Password not found" }));
            if (string.IsNullOrEmpty(sURL))
                ErrorMessages.Add((new FareQuote.ErrorMessage() { Type = ResponseMessageType.Error, Value = "URL not found" }));
            if (string.IsNullOrEmpty(sAuthorizedBy))
                ErrorMessages.Add((new FareQuote.ErrorMessage() { Type = ResponseMessageType.Error, Value = "AuthorizedBy not found" }));
            if (string.IsNullOrEmpty(sTraceId))
                ErrorMessages.Add((new FareQuote.ErrorMessage() { Type = ResponseMessageType.Error, Value = "TraceId not found" }));
            if (string.IsNullOrEmpty(sTargetBranch))
                ErrorMessages.Add((new FareQuote.ErrorMessage() { Type = ResponseMessageType.Error, Value = "TargetBranch not found" }));

            return ErrorMessages;
        }

        #region LowFareSearch
        public FareQuote LowFareSearch(FareQuote.FareType fareType, List<FareQuote.SearchInfo> listSearchInfo, decimal maxAmount)
        {
            FareQuote FareQute = new FareQuote();
            if (string.IsNullOrEmpty(ErrorMessage) == false)
                FareQute.ErrorMessages.Add((new FareQuote.ErrorMessage() { Type = ResponseMessageType.Error, Value = ErrorMessage }));
            else
                FareQute.ErrorMessages = CheckConfigure();
            if (FareQute.ErrorMessages.Count == 0)
            {
                string sLowFareSearchReq = PrepareLowFareSearchReq(fareType, listSearchInfo, maxAmount);

                #region UAPI Handling
                try
                {
                    XmlDocument request = new XmlDocument();
                    request.LoadXml(sLowFareSearchReq);

                    if (Connected == false)
                        OpenConnection();

                    connection.Uri = new Uri(connection.Uri, AIR_SERVICE);
                    //Send Request to uAPI
                    XmlDocument responseDocument = connection.SendRequest(request);

                    FareQute = DeserializeLowFareSearchResp(responseDocument.OuterXml);
                    if (FareQute.RresultCount > 0)
                    {
                        //Handle Max Amount
                        if (maxAmount > 0)
                        {
                            var oAirPricingSolution = (from p in FareQute.AirPricingSolutions
                                                       where Convert.ToDecimal(p.TotalPrice.Replace("HKD", "")) <= maxAmount
                                                       select p).ToList();
                            FareQute.AirPricingSolutions = oAirPricingSolution;
                        }
                    }
                }
                catch (Exception ex)
                {

                }
                #endregion
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

                //if (oSearchInfo.FrightClass != null)
                //    oLowFareSearchReq.JourneyData = new uAPIFlight.typeBaseAirSegment[1] { new uAPIFlight.typeBaseAirSegment() { CabinClass = oSearchInfo.FrightClass.ToString() } };
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
                (new XmlNamespace() { NameSpace = "common_v30", Url=NAMESPACE_COMMON})
            };

            sLowFareSearchReq = Serialize<uAPIFlight.LowFareSearchReq>.SerializeXmlToString(xmlNamespaces, oLowFareSearchReq);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "LowFareSearchReq.xml"), sLowFareSearchReq);

            return sLowFareSearchReq;
        }

        public FareQuote DeserializeLowFareSearchResp(string sXmlContents)
        {
            XElement xRoot = XElement.Parse(sXmlContents);
            sXmlContents = Serialize<uAPIFlight.LowFareSearchRsp>.RemoveAllNamespaces(xRoot).ToString();
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "LowFareSearchResp.xml"), sXmlContents);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(sXmlContents);

            List<Common.ResponseMessage> oResponseMessageList = new List<Common.ResponseMessage>();
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
                    #region ResponseMessage Handling
                    if (childnode.Name == "ResponseMessage")
                    {
                        try
                        { 
                            Common.ResponseMessage oResponseMessage = Serialize<Common.ResponseMessage>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                            oResponseMessageList.Add(oResponseMessage);
                        }
                        catch (Exception ex) { }
                    }
                    #endregion

                    #region FlightDetailsList Handling
                    if (childnode.Name == "FlightDetailsList")
                    {
                        try
                        { 
                            oFlightDetailsList = Serialize<Flight.FlightDetailsList>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                            //foreach (XmlNode subchildnode in childnode.ChildNodes)
                            //{
                            //    if (subchildnode.Name == "FlightDetails")
                            //    {
                            //        Flight.FlightDetails oFlightDetails = Serialize<Flight.FlightDetails>.DeserializeXmlFromStringWithoutNamespace(subchildnode.OuterXml);
                            //    }
                            //}
                        }
                        catch(Exception ex) {}
                    }
                    #endregion

                    #region AirSegmentList Handling
                    if (childnode.Name == "AirSegmentList")
                    {
                        try
                        {
                            //foreach (XmlNode subchildnode in childnode.ChildNodes)
                            //{
                            //    if (subchildnode.Name == "AirSegment")
                            //    {
                            //        Flight.AirSegment oAirSegment = Serialize<Flight.AirSegment>.DeserializeXmlFromStringWithoutNamespace(subchildnode.OuterXml);
                            //        //oAirSegmentList.FareInfo.Add(oAirSegment);
                            //    }
                            //}
                            oAirSegmentList = Serialize<Flight.AirSegmentList>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        }
                        catch(Exception ex) {}
                    }
                    #endregion

                    #region FareInfoList Handling
                    if (childnode.Name == "FareInfoList")
                    {
                        try
                        { 
                            oFareInfoList = Serialize<Flight.FareInfoList>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                            //foreach (XmlNode subchildnode in childnode.ChildNodes)
                            //{
                            //    if (subchildnode.Name == "FareInfo")
                            //    {
                            //        Flight.FareInfo oFareInfo = Serialize<Flight.FareInfo>.DeserializeXmlFromStringWithoutNamespace(subchildnode.OuterXml);
                            //        //oFareInfoList.FareInfo.Add(oFareInfo);
                            //    }
                            //}
                        }
                        catch(Exception ex) {}
                    }
                    #endregion

                    #region RouteList Handling
                    if (childnode.Name == "RouteList")
                    {
                        try
                        { 
                            //uAPIFlight.Route[] oRouteList = Serialize<uAPIFlight.Route[]>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                            oRouteList = Serialize<Flight.RouteList>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        }
                        catch (Exception ex) { }
                    }
                    #endregion

                    #region AirPricingSolution Handling
                    if (childnode.Name == "AirPricingSolution")
                    {
                        try
                        { 
                            //uAPIFlight.typeBaseAirSegment oAirSegmentList = Serialize<uAPIFlight.typeBaseAirSegment>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                            Flight.AirPricingSolution oAirPricingSolution = Serialize<Flight.AirPricingSolution>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                            AirPricingSolutionList.Add(oAirPricingSolution);
                        }
                        catch (Exception ex) { }
                    }
                    #endregion


                }
            }

            FareQuote oFareQuote = new FareQuote();

            var ErrorMessageList = from e in oResponseMessageList
                                   where e.Type == ResponseMessageType.Error
                                   select e;
            foreach (Common.ResponseMessage oResponseMessage in ErrorMessageList)
            {
                FareQuote.ErrorMessage oErrorMessage = new FareQuote.ErrorMessage(oResponseMessage);
                oFareQuote.ErrorMessages.Add(oErrorMessage);
            }

            List<Flight.FareQuote.AirPricingSolution> airs = new List<Flight.FareQuote.AirPricingSolution>();
            foreach (Flight.AirPricingSolution airPricingSolution in AirPricingSolutionList)
            {
                Flight.FareQuote.AirPricingSolution air = new Flight.FareQuote.AirPricingSolution(airPricingSolution, oAirSegmentList, oRouteList, oFareInfoList, oFlightDetailsList);
                airs.Add(air);
            }
            oFareQuote.AirPricingSolutions = airs;


            return oFareQuote;
        }
        #endregion

        #region AirCreateReservation (Fare Booking)
        public FareBooking AirCreateReservation(FareBooking.BookingInfo oBookingInfo)
        {
            FareBooking oFareBooking = new FareBooking();
            if (string.IsNullOrEmpty(ErrorMessage) == false)
                oFareBooking.ErrorMessages.Add((new FareQuote.ErrorMessage() { Type = ResponseMessageType.Error, Value = ErrorMessage }));
            else
                oFareBooking.ErrorMessages = CheckConfigure();
            if (oFareBooking.ErrorMessages.Count == 0)
            {
                string sAirCreateReservationReq = PrepareAirCreateReservationReq(oBookingInfo);

                #region UAPI Handling
                try
                {
                    XmlDocument request = new XmlDocument();
                    request.LoadXml(sAirCreateReservationReq);

                    if (Connected == false)
                        OpenConnection();

                    connection.Uri = new Uri(connection.Uri, AIR_SERVICE);
                    //Send Request to uAPI
                    XmlDocument responseDocument = connection.SendRequest(request);

                    //oFareBooking = DeserializeLowFareSearchResp(responseDocument.OuterXml);
                    //if (oFareBooking.RresultCount > 0)
                    //{
                    //    //Handle Max Amount
                    //    if (maxAmount > 0)
                    //    {
                    //        var oAirPricingSolution = (from p in oFareBooking.AirPricingSolutions
                    //                                   where Convert.ToDecimal(p.TotalPrice.Replace("HKD", "")) <= maxAmount
                    //                                   select p).ToList();
                    //        oFareBooking.AirPricingSolutions = oAirPricingSolution;
                    //    }
                    //}
                }
                catch (Exception ex)
                {

                }
                #endregion
            }
            return oFareBooking;
        }

        public string PrepareAirCreateReservationReq(FareBooking.BookingInfo oBookingInfo)
        {
            string sAirCreateReservationReq = string.Empty;
            uAPIBooking.AirCreateReservationReq oAirCreateReservationReq = PrepareHeader<uAPIBooking.AirCreateReservationReq>(); //new uAPIFlight.LowFareSearchReq();

            oAirCreateReservationReq.RetainReservation = uAPIBooking.typeRetainReservation.Both;
            oAirCreateReservationReq.BillingPointOfSaleInfo = new uAPIBooking.BillingPointOfSaleInfo() { OriginApplication = "UAPI" };

            #region BookingTraveler Properties Values
            List<uAPIBooking.BookingTraveler> oBookingTravelerList = new List<uAPIBooking.BookingTraveler>();
            foreach (FareBooking.BookingPassenger oPassenger in oBookingInfo.Passengers)
            {
                uAPIBooking.BookingTraveler oBookingTraveler = new uAPIBooking.BookingTraveler();
                oBookingTraveler.Key = Variables.NewUUID();
                oBookingTraveler.DOB = oPassenger.DOB;
                oBookingTraveler.Gender = oPassenger.Gender;
                oBookingTraveler.Nationality = oPassenger.Nationality;
                oBookingTraveler.TravelerType = oPassenger.TravelerType;

                #region BookingTravelerName BookingTraveler Values
                oBookingTraveler.BookingTravelerName = new uAPIBooking.BookingTravelerName();
                oBookingTraveler.BookingTravelerName.Prefix = oPassenger.Prefix;
                oBookingTraveler.BookingTravelerName.First = oPassenger.First;
                oBookingTraveler.BookingTravelerName.Last = oPassenger.Last;
                #endregion

                #region Assign PhoneNumber Values
                uAPIBooking.PhoneNumber oPhoneNumber = new uAPIBooking.PhoneNumber();
                oPhoneNumber.Type = uAPIBooking.PhoneNumberType.Mobile;
                //oPhoneNumber.Location = string.Empty;
                oPhoneNumber.CountryCode = oPassenger.PhoneNumber.CountryCode;
                oPhoneNumber.AreaCode = oPassenger.PhoneNumber.AreaCode;
                oPhoneNumber.Number = oPassenger.PhoneNumber.Number;
                oBookingTraveler.PhoneNumber = new uAPIBooking.PhoneNumber[1] { oPhoneNumber };
                #endregion

                #region Assign Email Values
                uAPIBooking.Email oEmail = new uAPIBooking.Email();
                oEmail.Type = oPhoneNumber.Type.ToString();
                oEmail.EmailID = oPassenger.Email;
                oBookingTraveler.Email = new uAPIBooking.Email[1] { oEmail };
                #endregion

                oBookingTravelerList.Add(oBookingTraveler);
            }
            oAirCreateReservationReq.BookingTraveler = oBookingTravelerList.ToArray();
            #endregion

            #region AirPricingSolution Properties Value
            oAirCreateReservationReq.AirPricingSolution = new uAPIBooking.AirPricingSolution();
            try
            {
                #region Copy AirPricingSolution Properties
                Variables.CopyObject<Flight.FareQuote.AirPricingSolution, uAPIBooking.AirPricingSolution>(oBookingInfo.AirPricingSolution, oAirCreateReservationReq.AirPricingSolution);
                #endregion
                
                #region Copy AirPricingSolution.AirPricingInfoList Properties
                List<uAPIBooking.AirPricingInfo> newAirPricingInfoList = new List<uAPIBooking.AirPricingInfo>();
                List<uAPIBooking.typeBaseAirSegment> newBaseAirSegmentList = new List<uAPIBooking.typeBaseAirSegment>();
                foreach (FareQuote.AirPricingSolution.AirPricingInfo oAirPricingInfo in oBookingInfo.AirPricingSolution.AirPricingInfoList)
                {
                    uAPIBooking.AirPricingInfo newAirPricingInfo = new uAPIBooking.AirPricingInfo();
                    Variables.CopyObject<Flight.FareQuote.AirPricingSolution.AirPricingInfo, uAPIBooking.AirPricingInfo>(oAirPricingInfo, newAirPricingInfo);


                    #region Copy AirPricingInfo AirSegment Properties
                    foreach (FareQuote.AirPricingSolution.AirSegment oAirSegment in oAirPricingInfo.AirSegmentList)
                    {
                        uAPIBooking.typeBaseAirSegment newBaseAirSegment = new uAPIBooking.typeBaseAirSegment();
                        Variables.CopyObject<FareQuote.AirPricingSolution.AirSegment, uAPIBooking.typeBaseAirSegment>(oAirSegment, newBaseAirSegment);
                        if (newBaseAirSegmentList.Contains(newBaseAirSegment) == false)
                            newBaseAirSegmentList.Add(newBaseAirSegment);
                    }
                    #endregion


                    #region Copy AirPricingInfo FareInfo Properties
                    List<uAPIBooking.FareInfo> newFareInfoList = new List<uAPIBooking.FareInfo>();
                    foreach (Flight.FareInfo oFareInfo in oAirPricingInfo.FareInfoList)
                    {
                        uAPIBooking.FareInfo newFareInfo = new uAPIBooking.FareInfo();
                        Variables.CopyObject<Flight.FareInfo, uAPIBooking.FareInfo>(oFareInfo, newFareInfo);
                        if (newFareInfoList.Contains(newFareInfo) == false)
                            newFareInfoList.Add(newFareInfo);
                    }
                    newAirPricingInfo.FareInfo = newFareInfoList.ToArray();
                    #endregion

                    #region Copy AirPricingInfo BookingInfo Properties
                    List<uAPIBooking.BookingInfo> newBookingInfoList = new List<uAPIBooking.BookingInfo>();
                    foreach (FareQuote.AirPricingSolution.AirBookingInfo oAirBookingInfo in oAirPricingInfo.BookingInfoList)
                    {
                        uAPIBooking.BookingInfo newBookingInfo = new uAPIBooking.BookingInfo();
                        Variables.CopyObject<FareQuote.AirPricingSolution.AirBookingInfo, uAPIBooking.BookingInfo>(oAirBookingInfo, newBookingInfo);
                        if (oAirBookingInfo.CabinClassSpecified)
                            newBookingInfo.CabinClass = oAirBookingInfo.CabinClass.ToString();
                        if (newBookingInfoList.Contains(newBookingInfo) == false)
                            newBookingInfoList.Add(newBookingInfo);
                    }
                    newAirPricingInfo.BookingInfo = newBookingInfoList.ToArray();
                    #endregion

                    #region Copy AirPricingInfo TaxInfo Properties
                    List<uAPIBooking.typeTaxInfo> newTaxInfoList = new List<uAPIBooking.typeTaxInfo>();
                    foreach (Flight.TaxInfo oTaxInfo in oAirPricingInfo.TaxInfo)
                    {
                        uAPIBooking.typeTaxInfo newTaxInfo = new uAPIBooking.typeTaxInfo();
                        Variables.CopyObject<Flight.TaxInfo, uAPIBooking.typeTaxInfo>(oTaxInfo, newTaxInfo);
                        newTaxInfo.Key = Variables.NewUUID();
                        if (newTaxInfoList.Contains(newTaxInfo) == false)
                            newTaxInfoList.Add(newTaxInfo);
                    }
                    newAirPricingInfo.TaxInfo = newTaxInfoList.ToArray();
                    #endregion

                    #region Assign PassengerType Properties Value refer to BookingTraveler
                    List<uAPIBooking.PassengerType> newPassengerTypeList = new List<uAPIBooking.PassengerType>();
                    foreach (uAPIBooking.BookingTraveler oBookingTraveler in oBookingTravelerList)
                    {
                        uAPIBooking.PassengerType newPassengerType = new uAPIBooking.PassengerType();
                        newPassengerType.BookingTravelerRef = oBookingTraveler.Key;
                        newPassengerType.Code = oBookingTraveler.TravelerType;
                        newPassengerTypeList.Add(newPassengerType);
                    }
                    newAirPricingInfo.PassengerType = newPassengerTypeList.ToArray();
                    #endregion


                    newAirPricingInfoList.Add(newAirPricingInfo);
                }
                oAirCreateReservationReq.AirPricingSolution.AirPricingInfo = newAirPricingInfoList.ToArray();
                oAirCreateReservationReq.AirPricingSolution.AirSegment = newBaseAirSegmentList.ToArray();
                #endregion
            }
            catch (Exception ex) {
                string errorMessage = ex.Message;
            }
            #endregion

            #region ActionStatus Properties Values
            uAPIBooking.ActionStatus oActionStatus = new uAPIBooking.ActionStatus();
            oActionStatus.ProviderCode = "1G";
            oActionStatus.TicketDate = DateTime.Now.ToString();
            oActionStatus.Type = uAPIBooking.ActionStatusType.TAW;
            oAirCreateReservationReq.ActionStatus = new uAPIBooking.ActionStatus[1] { oActionStatus };
            #endregion

            #region FormOfPayment Properties Values
            uAPIBooking.FormOfPayment oFormOfPayment = new uAPIBooking.FormOfPayment();
            oFormOfPayment.Type = "Credit";
            #region FormOfPayment CreditCard Properties Values
            uAPIBooking.CreditCard oCreditCard = new uAPIBooking.CreditCard();
            oCreditCard.Name = oBookingInfo.CreditCardInfo.Name;
            oCreditCard.Number = oBookingInfo.CreditCardInfo.Number;
            oCreditCard.ExpDate = oBookingInfo.CreditCardInfo.ExpDate;
            oCreditCard.CVV = oBookingInfo.CreditCardInfo.CVV;
            oCreditCard.Type = oBookingInfo.CreditCardInfo.Type;
            //foreach (PropertyInfo prop in oBookingInfo.CreditCardInfo.GetType().GetProperties())
            //{
            //    try
            //    {
            //        #region BookingTraveler Values
            //        PropertyInfo pptCreditCard = oCreditCard.GetType().GetProperty(prop.Name);
            //        if (pptCreditCard != null)
            //            pptCreditCard.SetValue(pptCreditCard, prop.GetValue(oBookingInfo.CreditCardInfo, null), null);
            //        #endregion
            //    }
            //    catch (Exception ex) { }
            //}
            oFormOfPayment.Item = oCreditCard;
            #endregion

            oAirCreateReservationReq.FormOfPayment = new uAPIBooking.FormOfPayment[1] { oFormOfPayment };
            #endregion

            //string xml = Serialize<uAPIFlight.LowFareSearchReq>.SerializeXmlToString(oLowFareSearchReq);
            List<XmlNamespace> xmlNamespaces = new List<XmlNamespace>() { 
                (new XmlNamespace() { NameSpace = "univ", Url=NAMESPACE_BOOKING}), 
                (new XmlNamespace() { NameSpace = "air", Url=NAMESPACE_AIR}), 
                (new XmlNamespace() { NameSpace = "common_v30", Url=NAMESPACE_COMMON})
            };
            //xmlNamespaces.Add(new XmlNamespace() { NameSpace = "univ", Url = NAMESPACE_BOOKING });

            sAirCreateReservationReq = Serialize<uAPIBooking.AirCreateReservationReq>.SerializeXmlToString(xmlNamespaces, oAirCreateReservationReq);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "AirCreateReservationReq.xml"), sAirCreateReservationReq);

            return sAirCreateReservationReq;
        }

        public FareBooking DeserializeAirCreateReservationResp(string sXmlContents)
        {
            
            XElement xRoot = XElement.Parse(sXmlContents);
            sXmlContents = Serialize<uAPIFlight.LowFareSearchRsp>.RemoveAllNamespaces(xRoot).ToString();
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "LowFareSearchResp.xml"), sXmlContents);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(sXmlContents);

            List<Common.ResponseMessage> oResponseMessageList = new List<Common.ResponseMessage>();
            Booking.ActionStatus oActionStatus = new Booking.ActionStatus();
            Booking.ProviderReservationInfo oProviderReservationInfo = new Booking.ProviderReservationInfo();
            Booking.AirReservation oAirReservation = new Booking.AirReservation();
            Booking.AgencyInfo oAgencyInfo = new Booking.AgencyInfo();

            XmlNodeList LowFareSearchRsp = xmlDoc.GetElementsByTagName("AirCreateReservationRsp");
            foreach (XmlNode node in LowFareSearchRsp)
            {
                foreach (XmlNode childnode in node.ChildNodes)
                {
                    #region ResponseMessage Handling
                    if (childnode.Name == "ResponseMessage")
                    {
                        try
                        {
                            Common.ResponseMessage oResponseMessage = Serialize<Common.ResponseMessage>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                            oResponseMessageList.Add(oResponseMessage);
                        }
                        catch (Exception ex) { }
                    }
                    #endregion

                    #region ActionStatus Handling
                    if (childnode.Name == "ActionStatus")
                    {
                        try
                        {
                            oActionStatus = Serialize<Booking.ActionStatus>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        }
                        catch (Exception ex) { }
                    }
                    #endregion

                    #region ProviderReservationInfo Handling
                    if (childnode.Name == "ProviderReservationInfo")
                    {
                        try
                        {
                            oProviderReservationInfo = Serialize<Booking.ProviderReservationInfo>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        }
                        catch (Exception ex) { }
                    }
                    #endregion
                    
                    #region AirReservation Handling
                    if (childnode.Name == "AirReservation")
                    {
                        try
                        {
                            oAirReservation = Serialize<Booking.AirReservation>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        }
                        catch (Exception ex) { }
                    }
                    #endregion

                    #region AgencyInfo Handling
                    if (childnode.Name == "AgencyInfo")
                    {
                        try
                        {
                            oAgencyInfo = Serialize<Booking.AgencyInfo>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        }
                        catch (Exception ex) { }
                    }
                    #endregion
                }
            }

            FareBooking oFareBooking = new FareBooking();

            var ErrorMessageList = from e in oResponseMessageList
                                   where e.Type == ResponseMessageType.Error
                                   select e;
            foreach (Common.ResponseMessage oResponseMessage in ErrorMessageList)
            {
                FareQuote.ErrorMessage oErrorMessage = new FareQuote.ErrorMessage(oResponseMessage);
                oFareBooking.ErrorMessages.Add(oErrorMessage);
            }

            return oFareBooking;
        }
        #endregion


        #region HotelSearchAvailability
        public HotelQute HotelSearch(List<HotelQute.SearchInfo> listSearchInfo, decimal maxAmount)
        {
            HotelQute oHotelQute = new HotelQute();
            string sHotelSearchAvailabilityReq = PrepareHotelSearchAvailabilityReq(listSearchInfo, maxAmount);

            #region UAPI Handling
            try
            {
                XmlDocument request = new XmlDocument();
                request.LoadXml(sHotelSearchAvailabilityReq);

                if (Connected == false)
                    OpenConnection();

                connection.Uri = new Uri(connection.Uri, HOTEL_SERVICE);
                //Send Request to uAPI
                XmlDocument responseDocument = connection.SendRequest(request);

                List<Hotel.HotelSearchResult> HotelSearchResultList = new List<HotelSearchResult>();
                oHotelQute = DeserializeHotelSearchAvailabilityResp(responseDocument.OuterXml, out HotelSearchResultList);
                if (oHotelQute.RresultCount > 0)
                {
                    //Handle Max Amount
                    if (maxAmount > 0)
                    {
                        var oHotelPricingSolution = (from p in oHotelQute.HotelPricingSolutions
                                                   where Convert.ToDecimal(p.MaximumAmount.Replace("HKD", "")) <= maxAmount
                                                   select p).ToList();
                        oHotelQute.HotelPricingSolutions = oHotelPricingSolution;
                    }

                    foreach (HotelQute.HotelPricingSolution oHotelPricingSolution in oHotelQute.HotelPricingSolutions)
                    {
                        try
                        {
                            var oHotelSearchResult = (from r in HotelSearchResultList where r.HotelProperty.VendorLocationKey == oHotelPricingSolution.VendorLocationKey select r).ToList();
                            if (oHotelSearchResult.Count() > 0)
                            {
                                    string sHotelMediaLinksReq = PrepareHotelMediaLinksReq(oHotelSearchResult[0].HotelProperty);
                                    XmlDocument request2 = new XmlDocument();
                                    request2.LoadXml(sHotelMediaLinksReq);
                                    XmlDocument responseDocument2 = connection.SendRequest(request2);
                                    List<MediaItem> MediaItemLists = DeserializeHotelMediaLinksResp(responseDocument2.OuterXml);
                                    oHotelPricingSolution.MediaItems = MediaItemLists;
                            }
                        }
                        catch (Exception ex) { }
                    }

                }
            }
            catch (Exception ex)
            {

            }
            #endregion
            return oHotelQute;
        }

        #region PrepareHotelSearchAvailabilityReq
        internal string PrepareHotelSearchAvailabilityReq(List<HotelQute.SearchInfo> listSearchInfo, decimal maxAmount)
        {
            string sHotelSearchAvailabilityReq = string.Empty;
            uAPIHotel.HotelSearchAvailabilityReq oHotelSearchAvailabilityReq = PrepareHeader<uAPIHotel.HotelSearchAvailabilityReq>(); //new uAPIFlight.LowFareSearchReq();

            //uAPIFlight.LowFareSearchReq oLowFareSearchReq = new uAPIFlight.LowFareSearchReq();
            oHotelSearchAvailabilityReq.BillingPointOfSaleInfo = new uAPIHotel.BillingPointOfSaleInfo() { OriginApplication = "UAPI" };

            #region Hotel Location Values
            foreach (HotelQute.SearchInfo oSearchInfo in listSearchInfo)
            {
                #region HotelLocation Values
                uAPIHotel.HotelLocation oHotelLocation = new uAPIHotel.HotelLocation();
                if (string.IsNullOrEmpty(oSearchInfo.Location))
                    oHotelLocation.Location = oSearchInfo.City;
                else
                    oHotelLocation.Location = oSearchInfo.Location;
                //oHotelSearchAvailabilityReq.HotelLocation = oHotelLocation;
                oHotelSearchAvailabilityReq.HotelSearchLocation = new uAPIHotel.HotelSearchLocation() { HotelLocation = oHotelLocation };
                #endregion

                #region HotelSearchModifiers Values
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
                #endregion

                #region CheckInOUt Date Values
                oHotelSearchAvailabilityReq.HotelStay = new uAPIHotel.HotelStay();
                oHotelSearchAvailabilityReq.HotelStay.CheckinDate = oSearchInfo.CheckInDate;
                oHotelSearchAvailabilityReq.HotelStay.CheckoutDate = oSearchInfo.CheckOutDate;
                #endregion
            }
            #endregion


            List<XmlNamespace> xmlNamespaces = new List<XmlNamespace>() { 
                (new XmlNamespace() { NameSpace = "hot", Url=NAMESPACE_HOTEL}), 
                (new XmlNamespace() { NameSpace = "common_v30", Url=NAMESPACE_COMMON})
            };

            sHotelSearchAvailabilityReq = Serialize<uAPIHotel.HotelSearchAvailabilityReq>.SerializeXmlToString(xmlNamespaces, oHotelSearchAvailabilityReq);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "HotelSearchAvailabilityReq.xml"), sHotelSearchAvailabilityReq);

            return sHotelSearchAvailabilityReq;
        }
        #endregion

        #region DeserializeHotelSearchAvailabilityResp
        internal HotelQute DeserializeHotelSearchAvailabilityResp(string sXmlContents, out List<Hotel.HotelSearchResult> HotelSearchResultList)
        {
            XElement xRoot = XDocument.Parse(sXmlContents).Root;
            sXmlContents = Serialize<uAPIHotel.HotelSearchResult>.RemoveAllNamespaces(xRoot).ToString();
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "HotelSearchAvailabilityResp.xml"), sXmlContents);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(sXmlContents);

            List<Common.ResponseMessage> oResponseMessageList = new List<Common.ResponseMessage>();
            HotelSearchResultList = new List<Hotel.HotelSearchResult>();

            XmlNodeList HotelSearchAvailabilityRsp = xmlDoc.GetElementsByTagName("HotelSearchAvailabilityRsp");
            foreach (XmlNode node in HotelSearchAvailabilityRsp)
            {
                foreach (XmlNode childnode in node.ChildNodes)
                {
                    #region ResponseMessage Handling
                    if (childnode.Name == "ResponseMessage")
                    {
                        try
                        {
                            Common.ResponseMessage oResponseMessage = Serialize<Common.ResponseMessage>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                            oResponseMessageList.Add(oResponseMessage);
                        }
                        catch (Exception ex) { }
                    }
                    #endregion

                    #region HotelSearchResult Handling
                    if (childnode.Name == "HotelSearchResult")
                    {
                        try
                        {
                            Hotel.HotelSearchResult oHotelSearchResult = Serialize<Hotel.HotelSearchResult>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                            HotelSearchResultList.Add(oHotelSearchResult);

                            #region HotelProperty and RateInfo Handling
                            /*
                            foreach (XmlNode subchildnode in childnode.ChildNodes)
                            {
                                if (subchildnode.Name == "HotelProperty")
                                {
                                    foreach (XmlNode subchildnode2 in subchildnode.ChildNodes)
                                    {
                                        if (subchildnode2.Name == "Amenities")
                                        {
                                            Hotel.Amenities oAmenities = Serialize<Hotel.Amenities>.DeserializeXmlFromStringWithoutNamespace(subchildnode2.OuterXml);
                                        }
                                    }
                                    Hotel.HotelProperty oHotelProperty = Serialize<Hotel.HotelProperty>.DeserializeXmlFromStringWithoutNamespace(subchildnode.OuterXml);

                                }

                                if (subchildnode.Name == "RateInfo")
                                {
                                    Hotel.RateInfo oHotelProperty = Serialize<Hotel.RateInfo>.DeserializeXmlFromStringWithoutNamespace(subchildnode.OuterXml);
                                }
                            }
                            */
                            #endregion
                        }
                        catch (Exception ex) { }

                    }
                    #endregion

                    #region NextResultReference Handling
                    if (childnode.Name == "NextResultReference")
                    {
                        try
                        {
                            Hotel.NextResultReference oNextResultReference = Serialize<Hotel.NextResultReference>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        }
                        catch (Exception ex) { }
                    }
                    #endregion

                    #region VendorLocation Handling
                    if (childnode.Name == "VendorLocation")
                    {
                        try
                        {
                        }
                        catch (Exception ex) { }
                    }
                    #endregion
                }
            }

            HotelQute oHotelQute = new HotelQute();

            var ErrorMessageList = from e in oResponseMessageList
                                   where e.Type == ResponseMessageType.Error
                                   select e;
            foreach (Common.ResponseMessage oResponseMessage in ErrorMessageList)
            {
                HotelQute.ErrorMessage oErrorMessage = new HotelQute.ErrorMessage(oResponseMessage);
                oHotelQute.ErrorMessages.Add(oErrorMessage);
            }

            List<Hotel.HotelQute.HotelPricingSolution> hotels = new List<Hotel.HotelQute.HotelPricingSolution>();
            foreach (Hotel.HotelSearchResult hotelSearchResult in HotelSearchResultList)
            {
                try
                {
                    Hotel.HotelQute.HotelPricingSolution hotel = new Hotel.HotelQute.HotelPricingSolution(hotelSearchResult.HotelProperty, hotelSearchResult.RateInfo);
                    hotels.Add(hotel);
                }
                catch (Exception ex) { }
            }
            oHotelQute.HotelPricingSolutions = hotels;
            return oHotelQute;
        }
        #endregion

        #region HotelPropertyWithMediaItems
        #region PrepareHotelMediaLinksReq
        internal string PrepareHotelMediaLinksReq(Hotel.HotelProperty oHotelProperty)
        {
            uAPIHotel.HotelMediaLinksReq oHotelMediaLinksReq = PrepareHeader<uAPIHotel.HotelMediaLinksReq>();
            oHotelMediaLinksReq.BillingPointOfSaleInfo = new uAPIHotel.BillingPointOfSaleInfo() { OriginApplication = "UAPI" };
            oHotelMediaLinksReq.RichMedia = false;
            oHotelMediaLinksReq.Gallery = true;
            string sHotelMediaLinksReq = string.Empty;

            uAPIHotel.HotelProperty newHotelProperty = new uAPIHotel.HotelProperty();
            #region HotelProperty Properties Values
            foreach (PropertyInfo prop in oHotelProperty.GetType().GetProperties())
            {
                try
                {
                    if (prop.PropertyType == typeof(string))
                    {
                        string propValue = oHotelProperty.GetValue(prop.Name);
                        newHotelProperty.GetType().GetProperty(prop.Name).SetValue(newHotelProperty, propValue, null);
                    }
                }
                catch(Exception ex) {}
            }
            if (oHotelProperty.PropertyAddress.Count() > 0)
            {
                try
                {
                    newHotelProperty.PropertyAddress = new string[oHotelProperty.PropertyAddress.Count()];
                    for (int i = 0; i < oHotelProperty.PropertyAddress.Count(); i++)
                        newHotelProperty.PropertyAddress[i] = oHotelProperty.PropertyAddress[i];
                }
                catch (Exception ex) { }
            }
            newHotelProperty.Availability = uAPIHotel.typeHotelAvailability.Available;
            #endregion
            oHotelMediaLinksReq.HotelProperty = new uAPIHotel.HotelProperty[1] { newHotelProperty };


            List<XmlNamespace> xmlNamespaces = new List<XmlNamespace>() { 
                (new XmlNamespace() { NameSpace = "hot", Url=NAMESPACE_HOTEL}), 
                (new XmlNamespace() { NameSpace = "common_v30", Url=NAMESPACE_COMMON})
            };

            sHotelMediaLinksReq = Serialize<uAPIHotel.HotelMediaLinksReq>.SerializeXmlToString(xmlNamespaces, oHotelMediaLinksReq);
            //File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "HotelMediaLinksReq.xml"), sHotelMediaLinksReq);

            return sHotelMediaLinksReq;
        }
        #endregion

        #region DeserializeHotelMediaLinksResp
        public List<MediaItem> DeserializeHotelMediaLinksResp(string sXmlContents)
        {
            XElement xRoot = XElement.Parse(sXmlContents);
            sXmlContents = Serialize<uAPIFlight.LowFareSearchRsp>.RemoveAllNamespaces(xRoot).ToString();
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "HotelPropertyWithMediaItems.xml"), sXmlContents);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(sXmlContents);

            List<MediaItem> MediaItemList = new List<MediaItem>();
            List<Common.ResponseMessage> oResponseMessageList = new List<Common.ResponseMessage>();

            XmlNodeList HotelMediaLinksResp = xmlDoc.GetElementsByTagName("HotelPropertyWithMediaItems");
            foreach (XmlNode node in HotelMediaLinksResp)
            {
                foreach (XmlNode childnode in node.ChildNodes)
                {
                    #region ResponseMessage Handling
                    if (childnode.Name == "ResponseMessage")
                    {
                        try
                        {
                            Common.ResponseMessage oResponseMessage = Serialize<Common.ResponseMessage>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                            oResponseMessageList.Add(oResponseMessage);
                        }
                        catch (Exception ex) { }
                    }
                    #endregion

                    #region MediaItem Handling
                    if (childnode.Name == "MediaItem")
                    {
                        try
                        {
                            MediaItem oMediaItem = Serialize<MediaItem>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                            MediaItemList.Add(oMediaItem);
                        }
                        catch (Exception ex) { }
                    }
                    #endregion
                }
            }

            return MediaItemList;
        }
        #endregion
        #endregion
        #endregion
    }
}
