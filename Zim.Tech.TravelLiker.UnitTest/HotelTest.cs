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
using Zim.Tech.TravelLiker.Travelport.uAPI.Air;

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
    }
}
