using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Zim.Tech.TravelLiker.Flight;
using uAPIUnit = Zim.Tech.TravelLiker.Travelport.uAPI.Util;
using uAPIFlight = Zim.Tech.TravelLiker.Travelport.uAPI.Air;

namespace Zim.Tech.TravelLiker
{
    public interface IFlight
    {
        FareQuote FlightOneWay(string fromCity, string toCity, DateTime frightDate, int adults, int children, int infantWOS, bool directFlightOnly, string frightClass, string specifiedAirline, decimal maxAmount, out string errorMessage);
        FareQuote FlightRoundTrip(string fromCity, string toCity, DateTime fromDate, DateTime toDate, int adults, int children, int infantWOS, bool directFlightOnly, string frightClass, string specifiedAirline, decimal maxAmount, out string errorMessage);

        //FareBooking Booking(List<FareQuote.FlightInfo> flightInfoList, List<FareBooking.BookingPassenger> PassengerInfoList, out string errorMessage);
    }
}
