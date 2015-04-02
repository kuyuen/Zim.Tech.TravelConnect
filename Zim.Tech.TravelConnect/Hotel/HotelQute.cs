using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Reflection;

using Zim.Tech.TravelConnect.Hotel;
using Zim.Tech.TravelConnect.Common;

namespace Zim.Tech.TravelConnect.Hotel
{
    public class HotelQute
    {
        public string GetValue(string m_Name)
        {
            PropertyInfo info = this.GetType().GetProperty(m_Name);
            if (info != null)
            {
                object val = info.GetValue(this, null);
                return (string)val;
            }
            else
            {
                return string.Empty;
            }
        }

        #region Properties Variables
        private List<HotelQute.HotelPricingSolution> hotelPricingSolutionList = new List<HotelQute.HotelPricingSolution>();
        private List<HotelQute.ErrorMessage> errorMessageList = new List<HotelQute.ErrorMessage>();
        #endregion

        #region Public Properties
        public List<HotelQute.HotelPricingSolution> HotelPricingSolutions { get { return hotelPricingSolutionList; } set { hotelPricingSolutionList = value; } }
        public List<HotelQute.ErrorMessage> ErrorMessages { get { return errorMessageList; } set { errorMessageList = value; } }

        public int RresultCount { get { return HotelPricingSolutions.Count(); } }
        #endregion


        #region ErrorMessage
        public class ErrorMessage : Common.ResponseMessage
        {
            public ErrorMessage() { }
            public ErrorMessage(Common.ResponseMessage oResponseMessage)
            {
                #region ErrorMessage Properties Values
                foreach (PropertyInfo prop in oResponseMessage.GetType().GetProperties())
                    GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(oResponseMessage, null), null);
                #endregion
            }

            #region Hide Base Class Properties
            [Obsolete("Don't use this ProviderCode", true)]
            new public string ProviderCode { get; set; }
            #endregion
        }
        #endregion


        #region HotelPricingSolution
        public class HotelPricingSolution : Hotel.HotelProperty
        {
            public HotelPricingSolution(Hotel.HotelProperty oHotelProperty, List<RateInfo> oRateInfoList)
            {
                #region HotelPricingSolution Properties Values
                foreach (PropertyInfo prop in oHotelProperty.GetType().GetProperties())
                    GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(oHotelProperty, null), null);
                #endregion

                if (oRateInfoList.Count > 0)
                {
                    this.rateInfoField = oRateInfoList.First();
                    this.minimumAmountField = this.rateInfoField.ApproximateMinimumAmount;
                    this.maximumAmountField = this.rateInfoField.ApproximateMaximumAmount;
                }

                if (oHotelProperty.PropertyAddress.Count > 0)
                    addressField = string.Join(",", oHotelProperty.PropertyAddress.ToArray());
            }

            private RateInfo rateInfoField = new RateInfo();
            private List<MediaItem> mediaItemField = new List<MediaItem>();
            private string minimumAmountField;
            private string maximumAmountField;
            private string addressField;

            /// <remarks/>
            //[System.Xml.Serialization.XmlElementAttribute("RateInfo")]
            //public RateInfo RateInfo
            //{
            //    get
            //    {
            //        return this.rateInfoField;
            //    }
            //    set
            //    {
            //        this.rateInfoField = value;
            //    }
            //}

            /// <remarks/>
            //[System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.travelport.com/schema/common_v29_0")]
            public List<MediaItem> MediaItems
            {
                get
                {
                    return this.mediaItemField;
                }
                set
                {
                    this.mediaItemField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string MinimumAmount
            {
                get
                {
                    return this.minimumAmountField;
                }
                set
                {
                    this.minimumAmountField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string MaximumAmount
            {
                get
                {
                    return this.maximumAmountField;
                }
                set
                {
                    this.maximumAmountField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string HotelAddress
            {
                get
                {
                    return this.addressField;
                }
            }
        }
        #endregion


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
