using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Zim.Tech.TravelLiker.Flight;

namespace Zim.Tech.TravelLiker
{
    public interface IFlight
    {
        List<FareQuote> FlightOneWay(string fromCity, string toCity, DateTime frightDate, int adults, int children, int infantWOS, bool directFlightOnly, string frightClass, string specifiedAirline, decimal maxAmount, out string errorMessage);
        List<FareQuote> FlightRoundTrip(string fromCity, string toCity, DateTime fromDate, DateTime toDate, int adults, int children, int infantWOS, bool directFlightOnly, string frightClass, string specifiedAirline, decimal maxAmount, out string errorMessage);

        //FareBooking Booking(List<FareQuote.FlightInfo> flightInfoList, List<FareBooking.BookingPassenger> PassengerInfoList, out string errorMessage);
    }
}
