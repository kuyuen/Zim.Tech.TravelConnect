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
using Microsoft.VisualStudio.TestTools.UnitTesting;

using Zim.Tech.TravelConnect.Common;
using Zim.Tech.TravelConnect.Booking;
using Zim.Tech.TravelConnect.Travelport.uAPI;
using uAPIUnit = Zim.Tech.TravelConnect.Travelport.uAPI.Util;
using uAPIFlight = Zim.Tech.TravelConnect.Travelport.uAPI.Air;
using Zim.Tech.TravelConnect.Travelport.uAPI.Air;

namespace Zim.Tech.TravelConnect.UnitTest
{
    [TestClass]
    public class FlightTest
    {
        public T PrepareHeader<T>() where T : new()
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

        [TestMethod]
        public void NewUUID()
        {
            string uuid = Variables.NewUUID();
            int length = uuid.Length;
        }

        #region Booking
        Flight.FareBooking.BookingInfo PrepareBooking(uApiAgent uAgent)
        {
            Flight.FareBooking.BookingInfo oBookingInfo = new Flight.FareBooking.BookingInfo();
            Flight.FareBooking.BookingPassenger oPassenger = new Flight.FareBooking.BookingPassenger();
            oPassenger.DOB = new DateTime(1969, 9, 17);
            oPassenger.Gender = "M";
            oPassenger.Nationality = "CH";
            oPassenger.TravelerType = "ADT";
            oPassenger.Prefix = "Mr";
            oPassenger.First = "Jack";
            oPassenger.Last = "Smith";
            oPassenger.Email = "kuyuen@gmail.com";
            oPassenger.PhoneNumber = new Flight.FareBooking.PhoneNumber() { CountryCode = "852", Number = "97880987" };
            oBookingInfo.Passengers.Add(oPassenger);

            Flight.FareBooking.PaymentInfo oPaymentInfo = new Flight.FareBooking.PaymentInfo();
            oPaymentInfo.Name = string.Format("{0} {1}", oPassenger.First, oPassenger.Last);
            oPaymentInfo.Number = "5123456789012346";
            oPaymentInfo.ExpDate = "2017-05";
            oPaymentInfo.CVV = "100";
            oPaymentInfo.Type = "VI";
            oBookingInfo.CreditCardInfo = oPaymentInfo;

            oBookingInfo.AirPricingSolution = new Flight.FareQuote.AirPricingSolution();
            string CurrencyType = string.Empty;
            string sDllPath = Directory.GetCurrentDirectory();
            string xmlFile = Path.Combine(sDllPath, "LowFareSearchResp.xml");
            string xmlcontents = System.IO.File.ReadAllText(xmlFile);
            Flight.FareQuote oFareQuote = uAgent.DeserializeLowFareSearchResp(xmlcontents);
            if (oFareQuote.AirPricingSolutions.Count() > 0)
                oBookingInfo.AirPricingSolution = oFareQuote.AirPricingSolutions[0];

            return oBookingInfo;
        }

        [TestMethod]
        public void FareBook()
        {
            uApiAgent uAgent = new uApiAgent();

            Flight.FareBooking.BookingInfo oBookingInfo = PrepareBooking(uAgent);
            Flight.FareBooking oFareBooking = uAgent.AirCreateReservation(oBookingInfo);
            string sTicketDate = oFareBooking.ActionStatus.TicketDate;
            string sCreateDate = oFareBooking.FareReservation.CreateDate;
        }
        #region Booking Serialize & Deserialize
        [TestMethod]
        public void PrepareAirCreateReservationReq()
        {
            uApiAgent uAgent = new uApiAgent();

            Flight.FareBooking.BookingInfo oBookingInfo = PrepareBooking(uAgent);

            string xml = uAgent.PrepareAirCreateReservationReq(oBookingInfo);
            xml = xml;
        }

        [TestMethod]
        public void DeserializeAirCreateReservationResp()
        {
            uApiAgent uAgent = new uApiAgent();

            string CurrencyType = string.Empty;
            string sDllPath = Directory.GetCurrentDirectory();
            string xmlFile = Path.Combine(sDllPath, "AirCreateReservationResp.xml");
            string xmlcontents = System.IO.File.ReadAllText(xmlFile);

            Flight.FareBooking oFareBooking = uAgent.DeserializeAirCreateReservationResp(xmlcontents);
            int o = 0;

        }
        #endregion
        #endregion

        #region Flight
        #region Fare Seach
        [TestMethod]
        public void SearchOneWay()
        {
            DateTime fromDate = new DateTime(2015, 5, 1);
            decimal maxAmount = 3750; // 100000;
            string specifiedAirline = "";

            TravelAgent agent = new TravelAgent();
            agent.MaxResult = 20;
            Flight.FareQuote.SearchInfo.CabinClass flightClass = Flight.FareQuote.SearchInfo.CabinClass.Economy;
            Flight.FareQuote oFareQuote = agent.FlightOneWay("HKG", "TPE", fromDate, 1, 0, true, flightClass, specifiedAirline, maxAmount);
            int i = oFareQuote.AirPricingSolutions.Count();

            string xml = Serialize<Flight.FareQuote>.SerializeXmlToString(oFareQuote);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "OneWayFareQuote.xml"), xml);
        }

        [TestMethod]
        public void SearchRoundTrip()
        {
            DateTime fromDate = new DateTime(2015, 5, 1);
            DateTime toDate = new DateTime(2015, 5, 5);
            decimal maxAmount = 5600; // 100000;
            string specifiedAirline = "";

            TravelAgent agent = new TravelAgent();
            agent.MaxResult = 20;
            Flight.FareQuote.SearchInfo.CabinClass flightClass = Flight.FareQuote.SearchInfo.CabinClass.Economy;
            Flight.FareQuote oFareQuote = agent.FlightRoundTrip("HKG", "TPE", fromDate, toDate, 1, 0, true, flightClass, specifiedAirline, maxAmount);
            int i = oFareQuote.AirPricingSolutions.Count();

            string xml = Serialize<Flight.FareQuote>.SerializeXmlToString(oFareQuote);
            File.WriteAllText(Path.Combine(Environment.CurrentDirectory, "RoundTripFareQuote.xml"), xml);
        }
        #endregion

        [TestMethod]
        public void ReferenceDataRetrieveReq()
        {
            //string test_dir = TestContext.TestDir;
            //string solution_dir = Path.GetDirectoryName(Path.GetDirectoryName(test_dir));
            string sDllPath = Directory.GetCurrentDirectory();

            uAPIUnit.ReferenceDataRetrieveReq xRequest = new uAPIUnit.ReferenceDataRetrieveReq();
            xRequest.AuthorizedBy = "Universal API/uAPI6768275016-96b0fd84";
            xRequest.TraceId = "trace";
            xRequest.TargetBranch = "P7009887";
            xRequest.BillingPointOfSaleInfo = new uAPIUnit.BillingPointOfSaleInfo() { OriginApplication = "UAPI" };
            xRequest.TypeCode = "City";
            xRequest.ReferenceDataSearchModifiers = new uAPIUnit.ReferenceDataSearchModifiers();
            xRequest.ReferenceDataSearchModifiers.MaxResults = "15000";
        
            string xml = Serialize<uAPIUnit.ReferenceDataRetrieveReq>.SerializeXmlToString("util", "http://www.travelport.com/schema/util_v25_0", xRequest);
            //string xml = Serialize<uAPIUnit.ReferenceDataRetrieveReq>.SerializeXmlToString(xRequest);
            string xmlFile = Path.Combine(sDllPath, "ReferenceDataRetrieveReq.xml");
            File.WriteAllText(xmlFile, xml);
        }

        #region Flight Serialize & Deserialize
        [TestMethod]
        public void LowFareSearchReq()
        {
            //string test_dir = TestContext.TestDir;
            //string solution_dir = Path.GetDirectoryName(Path.GetDirectoryName(test_dir));
            string sDllPath = Directory.GetCurrentDirectory();

            uAPIFlight.LowFareSearchReq xRequest = PrepareHeader<uAPIFlight.LowFareSearchReq>();
            xRequest.SolutionResult = true;
            //uAPIFlight.LowFareSearchReq xRequest = new uAPIFlight.LowFareSearchReq();
            xRequest.BillingPointOfSaleInfo = new uAPIFlight.BillingPointOfSaleInfo() { OriginApplication = "UAPI" };

            uAPIFlight.SearchAirLeg from = new uAPIFlight.SearchAirLeg();
            from.SearchOrigin = new typeSearchLocation[1] { (new typeSearchLocation() { Item = new Airport() { Code = "HKG" } }) };
            from.SearchDestination = new typeSearchLocation[1] { (new typeSearchLocation() { Item = new Airport() { Code = "TPE" } }) };
            from.Items = new typeFlexibleTimeSpec[1] { (new typeFlexibleTimeSpec() { PreferredTime = "2015-03-24" }) };

            uAPIFlight.SearchAirLeg to = new uAPIFlight.SearchAirLeg();
            to.SearchOrigin = new typeSearchLocation[1] { (new typeSearchLocation() { Item = new Airport() { Code = "TPE" } }) };
            to.SearchDestination = new typeSearchLocation[1] { (new typeSearchLocation() { Item = new Airport() { Code = "HKG" } }) };
            to.Items = new typeFlexibleTimeSpec[1] { (new typeFlexibleTimeSpec() { PreferredTime = "2015-03-29" }) };

            xRequest.Items = new SearchAirLeg[2] { from, to };
            xRequest.AirSearchModifiers = new AirSearchModifiers() { MaxSolutions = "5" };
            xRequest.SearchPassenger = new SearchPassenger[1] { new SearchPassenger() { BookingTravelerRef = "gr8AVWGCR064r57Jt0+8bA==", Code = "ADT" } };
            xRequest.AirPricingModifiers = new AirPricingModifiers() { CurrencyType = "HKD" };

            //string xml = Serialize<uAPIFlight.LowFareSearchReq>.SerializeXmlToString(xRequest);
            List<XmlNamespace> xmlNamespaces = new List<XmlNamespace>() { 
                (new XmlNamespace() { NameSpace = "air", Url="http://www.travelport.com/schema/air_v25_0"}), 
                (new XmlNamespace() { NameSpace = "com", Url="http://www.travelport.com/schema/common_v25_0"})
            };
            string xml = Serialize<uAPIFlight.LowFareSearchReq>.SerializeXmlToString(xmlNamespaces, xRequest);
            string xmlFile = Path.Combine(sDllPath, "LowFareSearchReq.xml");
            File.WriteAllText(xmlFile, xml);
        }

        [TestMethod]
        public void LowFareSearchResp()
        {
            string CurrencyType = string.Empty;
            string sDllPath = Directory.GetCurrentDirectory();
            string xmlFile = Path.Combine(sDllPath, "LowFareSearchRsp.xml");
            string xmlcontents = System.IO.File.ReadAllText(xmlFile);
            uAPIFlight.LowFareSearchRsp xResp = Serialize<uAPIFlight.LowFareSearchRsp>.DeserializeXmlFromStringWithoutNamespace(xmlcontents);
            if (xResp != null)
                CurrencyType = xResp.CurrencyType;


            XElement xRoot = XDocument.Parse(xmlcontents).Root;
            xmlcontents = Serialize<uAPIFlight.LowFareSearchRsp>.RemoveAllNamespaces(xRoot).ToString();

            //string xmlFile2 = Path.Combine(sDllPath, "LowFareSearchRsp_withoutNS.xml");
            //File.WriteAllText(xmlFile2, xmlcontents);

            //XmlDocument doc = new XmlDocument();
            //doc.PreserveWhitespace = true;
            //doc.Load(xmlFile);
            //xmlcontents = doc.InnerXml;

            
              Type [] extraTypes= new Type[6];
              extraTypes[0] = typeof(uAPIUnit.ResponseMessage[]);
              extraTypes[1] = typeof(uAPIFlight.FlightDetails[]);
              extraTypes[2] = typeof(uAPIFlight.typeBaseAirSegment[]);
              extraTypes[3] = typeof(uAPIFlight.FareInfo[]);
              extraTypes[4] = typeof(uAPIFlight.Route[]);
              extraTypes[5] = typeof(uAPIFlight.AirPricingSolution);

              xmlFile = Path.Combine(sDllPath, "LowFareSearchRsp_withoutNS.xml");
              xmlcontents = System.IO.File.ReadAllText(xmlFile);
              uAPIFlight.LowFareSearchRsp xResp2 = Serialize<uAPIFlight.LowFareSearchRsp>.DeserializeXmlFromStringWithoutNamespace(xmlcontents, extraTypes);
              //uAPIFlightNS.LowFareSearchRsp xResp2 = Serialize<uAPIFlightNS.LowFareSearchRsp>.DeserializeXmlFromString(xmlcontents, extraTypes);
              //uAPIFlightNS.LowFareSearchRsp xResp2 = Serialize<uAPIFlightNS.LowFareSearchRsp>.DeserializeXmlFromStringWithoutNamespace(xmlcontents);
              if (xResp2 != null)
              {
                  CurrencyType = xResp.CurrencyType;
                  int i = xResp.FareNoteList.Count();
              }
        }


        [TestMethod]
        public void DeserializeLowFareSearchResp()
        {
            string CurrencyType = string.Empty;
            string sDllPath = Directory.GetCurrentDirectory();
            string xmlFile = Path.Combine(sDllPath, "LowFareSearchResp.xml");
            string xmlcontents = System.IO.File.ReadAllText(xmlFile);

            XElement xRoot = XDocument.Parse(xmlcontents).Root;
            xmlcontents = Serialize<uAPIFlight.LowFareSearchRsp>.RemoveAllNamespaces(xRoot).ToString();

            uApiAgent agent = new uApiAgent();
            Flight.FareQuote oFareQuote = agent.DeserializeLowFareSearchResp(xmlcontents);

            string Result = string.Empty;
            foreach (Flight.FareQuote.AirPricingSolution airPricingSolution in oFareQuote.AirPricingSolutions)
            {
                Result  += string.Format("Price = {0}{1}", airPricingSolution.TotalPrice, Environment.NewLine);
                foreach (Flight.RouteLeg oRouteLeg in airPricingSolution.RouteLegList)
                {
                    Result += string.Format("Origin = {0} Destination {1}{2}", oRouteLeg.Origin, oRouteLeg.Destination, Environment.NewLine);
                }
                foreach (Flight.FareQuote.AirPricingSolution.Journey oJourney in airPricingSolution.JourneyList)
                {
                    Result += string.Format("Flight = {0}{1} FlightTime = {2} min(s)", oJourney.AirSegment.Carrier, oJourney.AirSegment.FlightNumber, oJourney.AirSegment.FlightTime);
                    Result += string.Format("From = {0} ({1}) To {2} ({3}) {4}"
                        , oJourney.AirSegment.Origin, oJourney.AirSegment.FlightDetails[0].DepartureTime
                        , oJourney.AirSegment.Destination, oJourney.AirSegment.FlightDetails[0].ArrivalTime 
                        , Environment.NewLine);
                }

                Result += string.Format("{0}", Environment.NewLine);
            }
            System.Console.WriteLine(Result);
            File.WriteAllText(Path.Combine(sDllPath, "LowFareSearchRsp_Result.txt"), Result);
            int o = 0;
        }
        #endregion
        #endregion
    }
}
