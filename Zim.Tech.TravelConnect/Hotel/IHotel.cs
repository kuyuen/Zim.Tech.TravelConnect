using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zim.Tech.TravelConnect.Hotel;
using Zim.Tech.TravelConnect.Common;

namespace Zim.Tech.TravelConnect
{
    public interface IHotel
    {
        HotelQute HotelEnquiy(string sCity, DateTime CheckIn, int StayDays, int NoOfRoom, string BedType, decimal maxAmount, out string errorMessage);
    }
}
