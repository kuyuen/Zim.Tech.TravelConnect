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

using Zim.Tech.TravelLiker.Common;
using Zim.Tech.TravelLiker.Travelport.uAPI;
using uAPIUnit = Zim.Tech.TravelLiker.Travelport.uAPI.Util;
using uAPIFlight = Zim.Tech.TravelLiker.Travelport.uAPI.Air;
using uAPIFlightNS = Zim.Tech.TravelLiker.Travelport.uAPI.Air.witoutNS;
using Zim.Tech.TravelLiker.Travelport.uAPI.Air;

namespace Zim.Tech.TravelLiker.UnitTest
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
        
            string xml = Serialize<uAPIUnit.ReferenceDataRetrieveReq>.SerializeXmlToString("util", "http://www.travelport.com/schema/util_v25_0", xRequest);
            //string xml = Serialize<uAPIUnit.ReferenceDataRetrieveReq>.SerializeXmlToString(xRequest);
            string xmlFile = Path.Combine(sDllPath, "ReferenceDataRetrieveReq.xml");
            File.WriteAllText(xmlFile, xml);
        }


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
              //uAPIFlight.LowFareSearchRsp xResp2 = Serialize<uAPIFlight.LowFareSearchRsp>.DeserializeXmlFromStringWithoutNamespace(xmlcontents, extraTypes);
              //uAPIFlightNS.LowFareSearchRsp xResp2 = Serialize<uAPIFlightNS.LowFareSearchRsp>.DeserializeXmlFromString(xmlcontents, extraTypes);
              uAPIFlightNS.LowFareSearchRsp xResp2 = Serialize<uAPIFlightNS.LowFareSearchRsp>.DeserializeXmlFromStringWithoutNamespace(xmlcontents);
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
            string xmlFile = Path.Combine(sDllPath, "LowFareSearchRsp.xml");
            string xmlcontents = System.IO.File.ReadAllText(xmlFile);

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlcontents);

            List<Flight.AirPricingSolution> AirPricingSolutionList = new List<Flight.AirPricingSolution>();
            Flight.FlightDetailsList oFlightDetailsList = new Flight.FlightDetailsList();
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
                    
                    if (childnode.Name == "AirSegmentList")
                    {
                        //uAPIFlight.typeBaseAirSegment oAirSegmentList = Serialize<uAPIFlight.typeBaseAirSegment>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        uAPIFlight.typeBaseAirSegment oAirSegmentList = Serialize<uAPIFlight.typeBaseAirSegment>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        int i = oAirSegmentList.AirAvailInfo.Count();
                    }
                    if (childnode.Name == "RouteList")
                    {
                        uAPIFlight.Route[] oAirSegmentList = Serialize<uAPIFlight.Route[]>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
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

            int iFlightDetailsCount = oFlightDetailsList.FlightDetails.Count();
            int iFareInfoCount = oFareInfoList.FareInfo.Count();
            int iAirPricingSolutionCount = AirPricingSolutionList.Count();
            int o = 0;
        }
    }
}
