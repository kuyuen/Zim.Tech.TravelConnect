using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;
using uAPIBooking = Zim.Tech.TravelConnect.Travelport.uAPI.UniversalRecord;

namespace Zim.Tech.TravelConnect.Booking
{
    #region BookingTraveler Class
    public partial class BookingTraveler : object
    {
        public BookingTraveler()
        {
            this.vIPField = false;
        }

        #region AirReservation private Properties
        private uAPIBooking.BookingTravelerName bookingTravelerNameField;
        private List<uAPIBooking.PhoneNumber> phoneNumberField;
        private List<uAPIBooking.Email> emailField;
        #endregion
        #region AirReservation private Attribute
        private string keyField;
        private string travelerTypeField;
        private string ageField;
        private bool vIPField;
        private System.DateTime dOBField;
        private bool dOBFieldSpecified;
        private string genderField;
        private string nationalityField;
        private string elStatField;
        private bool elStatFieldSpecified;
        private bool keyOverrideField;
        private bool keyOverrideFieldSpecified;
        #endregion


        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public uAPIBooking.BookingTravelerName BookingTravelerName
        {
            get
            {
                return this.bookingTravelerNameField;
            }
            set
            {
                this.bookingTravelerNameField = value;
            }
        }

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("DeliveryInfo")]
        //public DeliveryInfo[] DeliveryInfo
        //{
        //    get
        //    {
        //        return this.deliveryInfoField;
        //    }
        //    set
        //    {
        //        this.deliveryInfoField = value;
        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PhoneNumber")]
        public List<uAPIBooking.PhoneNumber> PhoneNumber
        {
            get
            {
                return this.phoneNumberField;
            }
            set
            {
                this.phoneNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Email")]
        public List<uAPIBooking.Email> Email
        {
            get
            {
                return this.emailField;
            }
            set
            {
                this.emailField = value;
            }
        }


        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Key
        {
            get
            {
                return this.keyField;
            }
            set
            {
                this.keyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TravelerType
        {
            get
            {
                return this.travelerTypeField;
            }
            set
            {
                this.travelerTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string Age
        {
            get
            {
                return this.ageField;
            }
            set
            {
                this.ageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool VIP
        {
            get
            {
                return this.vIPField;
            }
            set
            {
                this.vIPField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime DOB
        {
            get
            {
                return this.dOBField;
            }
            set
            {
                this.dOBField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DOBSpecified
        {
            get
            {
                return this.dOBFieldSpecified;
            }
            set
            {
                this.dOBFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Gender
        {
            get
            {
                return this.genderField;
            }
            set
            {
                this.genderField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Nationality
        {
            get
            {
                return this.nationalityField;
            }
            set
            {
                this.nationalityField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ElStat
        {
            get
            {
                return this.elStatField;
            }
            set
            {
                this.elStatField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ElStatSpecified
        {
            get
            {
                return this.elStatFieldSpecified;
            }
            set
            {
                this.elStatFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool KeyOverride
        {
            get
            {
                return this.keyOverrideField;
            }
            set
            {
                this.keyOverrideField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KeyOverrideSpecified
        {
            get
            {
                return this.keyOverrideFieldSpecified;
            }
            set
            {
                this.keyOverrideFieldSpecified = value;
            }
        }

    }
 
    #endregion
}

