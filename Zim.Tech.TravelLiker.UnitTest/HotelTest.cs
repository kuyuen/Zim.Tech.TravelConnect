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
using uAPIHotel = Zim.Tech.TravelLiker.Travelport.uAPI.Hotel;
using Zim.Tech.TravelLiker.Travelport.uAPI.Hotel;

namespace Zim.Tech.TravelLiker.UnitTest
{
    [TestClass]
    public class HotelTest
    {
        [TestMethod]
        public void PrepareHotelSearchAvailabilityReq()
        {
            decimal maxAmount = 0; // 100000;
            Hotel.HotelQute.SearchInfo oSearchInfo = new Hotel.HotelQute.SearchInfo();
            oSearchInfo.Location = "DEN";
            oSearchInfo.Rooms = 1;
            oSearchInfo.CheckInDate = new DateTime(2015, 4, 1);
            oSearchInfo.StayDays = 3;
            List<Hotel.HotelQute.SearchInfo> oSearchInfoList = new List<Hotel.HotelQute.SearchInfo>();
            oSearchInfoList.Add(oSearchInfo);

            uApiAgent agent = new uApiAgent();
            agent.PrepareHotelSearchAvailabilityReq(oSearchInfoList, maxAmount);
        }


        [TestMethod]
        public void DeserializeHotelSearchAvailabilityResp()
        {
            string CurrencyType = string.Empty;
            string sDllPath = Directory.GetCurrentDirectory();
            string xmlFile = Path.Combine(sDllPath, "HotelSearchAvailabilityResp.xml");
            string xmlcontents = System.IO.File.ReadAllText(xmlFile);

            XElement xRoot = XDocument.Parse(xmlcontents).Root;
            xmlcontents = Serialize<uAPIHotel.HotelSearchResult>.RemoveAllNamespaces(xRoot).ToString();

            XmlDocument xmlDoc = new XmlDocument();
            xmlDoc.LoadXml(xmlcontents);


            List<Hotel.HotelSearchResult> HotelSearchResultList = new List<Hotel.HotelSearchResult>();

            XmlNodeList LowFareSearchRsp = xmlDoc.GetElementsByTagName("HotelSearchAvailabilityRsp");
            foreach (XmlNode node in LowFareSearchRsp)
            {
                foreach (XmlNode childnode in node.ChildNodes)
                {
                    if (childnode.Name == "HotelSearchResult")
                    {
                        //uAPIHotel.HotelSearchResult oHotelSearchResult = Serialize<uAPIHotel.HotelSearchResult>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        Hotel.HotelSearchResult oHotelSearchResult = Serialize<Hotel.HotelSearchResult>.DeserializeXmlFromStringWithoutNamespace(childnode.OuterXml);
                        HotelSearchResultList.Add(oHotelSearchResult);
                    }
                }
            }

            int iHotelSearchResultList = HotelSearchResultList.Count();
            int o = 0;
        }
    }
}
