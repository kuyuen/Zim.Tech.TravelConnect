using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Reflection;

using Zim.Tech.TravelLiker.Common;

namespace Zim.Tech.TravelLiker.Hotel
{
    public class HotelQute
    {

        #region SearchInfo
        public class SearchInfo
        {
            #region Constructors
            public SearchInfo()
            {
            }

            public SearchInfo(string city, string location, DateTime checkinDate, int stayDays, int adults, int rooms, string bedType, string specifiedHotel)
                : this(city, location, checkinDate.ToString(Variables.DATE_FORMAT), stayDays, adults, rooms, bedType, specifiedHotel)
            {
            }

            public SearchInfo(string city, string location, string checkinDate, int stayDays, int adults, int rooms, string bedType, string specifiedHotel)
            {
                this.m_City = city;
                this.m_Location = location;
                this.m_CheckInDate = checkinDate;
                this.m_StayDays = stayDays;
                this.m_Adults = adults;
                this.m_Rooms = rooms;
                this.m_BedType = bedType;
                this.m_SpecifiedHotel = specifiedHotel;
            }
            #endregion

            #region Properties Variables
            private string m_City = string.Empty;
            private string m_Location = string.Empty;
            private string m_CheckInDate = string.Empty;
            private int m_StayDays = 1;
            private int m_Adults = 0;
            private int m_Rooms = 0;
            private string m_BedType = string.Empty;
            private string m_SpecifiedHotel = string.Empty;
            #endregion

            #region Public Properties
            public string City { get { return m_City; } set { m_City = value; } }
            public string Location { get { return m_Location; } set { m_Location = value; } }
            public string CheckIn { get { return m_CheckInDate; } set { m_CheckInDate = value; } }
            public string CheckOut { get { return CheckInDate.AddDays(m_StayDays).ToString(Variables.DATE_FORMAT); } }
            public DateTime CheckInDate { get { return DateTime.ParseExact(m_CheckInDate, Variables.DATE_FORMAT, null); } set { m_CheckInDate = value.ToString(Variables.DATE_FORMAT); } }
            public DateTime CheckOutDate { get { return CheckInDate.AddDays(m_StayDays); } }
            public int StayDays { get { return m_StayDays; } set { m_StayDays = value;  } }
            public int Adults { get { return m_Adults; } set { m_Adults = value; } }
            public int Rooms { get { return m_Rooms; } set { m_Rooms = value; } }
            public string BedType { get { return m_BedType; } set { m_BedType = value; } }
            public string SpecifiedHotel { get { return m_SpecifiedHotel; } set { m_SpecifiedHotel = value; } }
            #endregion
        }
        #endregion
    }
}
