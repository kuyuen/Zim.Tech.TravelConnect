using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Reflection;

using Zim.Tech.TravelConnect.Flight;
using Zim.Tech.TravelConnect.Common;

namespace Zim.Tech.TravelConnect.Flight
{
    public class FareBooking
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
        
        #region Constructors
        public FareBooking()
        {
        }
        #endregion

        
        #region Properties Variables
        private List<FareQuote.ErrorMessage> errorMessageList = new List<FareQuote.ErrorMessage>();
        #endregion

        #region Public Properties
        public List<FareQuote.ErrorMessage> ErrorMessages { get { return errorMessageList; } set { errorMessageList = value; } }

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


        #region BookingInfo Class
        public class BookingInfo
        {
            #region Constructors
            public BookingInfo()
            {
            }

            public BookingInfo(List<BookingPassenger> bookingPassengerList, FareQuote.AirPricingSolution airPricingSolution, PaymentInfo paymentInfo)
            {
                this.oBookingPassengers = bookingPassengerList;
                this.AirPricingSolution = airPricingSolution;
                this.oPaymentInfo = paymentInfo;
            }
            #endregion

            #region Properties Variables
            private List<BookingPassenger> oBookingPassengers = new List<BookingPassenger>();
            private FareQuote.AirPricingSolution oAirPricingSolution = new FareQuote.AirPricingSolution();
            private PaymentInfo oPaymentInfo = new PaymentInfo();
            #endregion

            #region Public Properties
            public List<BookingPassenger> Passengers { get { return oBookingPassengers; } set { oBookingPassengers = value; } }
            public FareQuote.AirPricingSolution AirPricingSolution { get { return oAirPricingSolution; } set { oAirPricingSolution = value; } }
            public PaymentInfo CreditCardInfo { get { return oPaymentInfo; } set { oPaymentInfo = value; } }
            #endregion

        }

        #region BookingPassenger Class
        public partial class BookingPassenger : object
        {
            #region Private Variables
            #region BookingTravelerName Variables
            private string prefixField;
            private string firstField;
            private string middleField;
            private string lastField;
            private string suffixField;
            #endregion
            #region BookingTraveler Variables
            private System.DateTime dOBField;
            private string genderField;
            private string nationalityField;
            private string travelerTypeField;
            #endregion
            private PhoneNumber phoneNumberField;
            private string emailField;
            #endregion
            #endregion

            #region Public Properties
            #region BookingTravelerName Public Properties
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Prefix
            {
                get
                {
                    return this.prefixField;
                }
                set
                {
                    this.prefixField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string First
            {
                get
                {
                    return this.firstField;
                }
                set
                {
                    this.firstField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Middle
            {
                get
                {
                    return this.middleField;
                }
                set
                {
                    this.middleField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Last
            {
                get
                {
                    return this.lastField;
                }
                set
                {
                    this.lastField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Suffix
            {
                get
                {
                    return this.suffixField;
                }
                set
                {
                    this.suffixField = value;
                }
            }
            #endregion

            #region BookingTraveler Public Properties
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
            #endregion
            #endregion

            public PhoneNumber PhoneNumber {
                get {
                    return this.phoneNumberField;
                }
                set {
                    this.phoneNumberField = value;
                }
            }
        
            /// <remarks/>
            public string Email {
                get {
                    return this.emailField;
                }
                set {
                    this.emailField = value;
                }
            }
        }
        #endregion

        #region PhoneNumber Class
        public partial class PhoneNumber : object
        {
            #region Private Variables
            private string locationField;
            private string countryCodeField;
            private string areaCodeField;
            private string numberField;
            #endregion

            #region Public Properties
            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Location
            {
                get
                {
                    return this.locationField;
                }
                set
                {
                    this.locationField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string CountryCode
            {
                get
                {
                    return this.countryCodeField;
                }
                set
                {
                    this.countryCodeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string AreaCode
            {
                get
                {
                    return this.areaCodeField;
                }
                set
                {
                    this.areaCodeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Number
            {
                get
                {
                    return this.numberField;
                }
                set
                {
                    this.numberField = value;
                }
            }
            #endregion
        }
        #endregion

        #region PaymentInfo Class
        public partial class PaymentInfo : object
        {
            private string typeField;
            private string numberField;
            private string expDateField;
            private string nameField;
            private string cVVField;
            //private StructuredAddress billingAddressField;

            /// <remarks/>
            //[System.Xml.Serialization.XmlElementAttribute()]
            //public StructuredAddress BillingAddress
            //{
            //    get
            //    {
            //        return this.billingAddressField;
            //    }
            //    set
            //    {
            //        this.billingAddressField = value;
            //    }
            //}

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Type
            {
                get
                {
                    return this.typeField;
                }
                set
                {
                    this.typeField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Number
            {
                get
                {
                    return this.numberField;
                }
                set
                {
                    this.numberField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string ExpDate
            {
                get
                {
                    return this.expDateField;
                }
                set
                {
                    this.expDateField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string Name
            {
                get
                {
                    return this.nameField;
                }
                set
                {
                    this.nameField = value;
                }
            }

            /// <remarks/>
            [System.Xml.Serialization.XmlAttributeAttribute()]
            public string CVV
            {
                get
                {
                    return this.cVVField;
                }
                set
                {
                    this.cVVField = value;
                }
            }
        }
        #endregion

        #region StructuredAddress Class
        #endregion
    }
  
}
