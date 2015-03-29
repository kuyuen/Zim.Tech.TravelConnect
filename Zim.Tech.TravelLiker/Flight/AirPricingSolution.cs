using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;

namespace Zim.Tech.TravelLiker.Flight
{
    #region HotelSearchResult Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v29_0")]
    public partial class AirPricingSolution : object
    {
        public AirPricingSolution()
        {
            this.completeItineraryField = true;
        }

        #region AirPricingSolution private properties
        private List<Journey> journeyField;
        private List<LegRef> legRefField;
        private List<AirPricingInfo> airPricingInfoField;
        #endregion

        #region AirPricingSolution private Attribute
        private string keyField;
        private bool completeItineraryField;
        private string totalPriceField;
        private string basePriceField;
        private string approximateTotalPriceField;
        private string approximateBasePriceField;
        private string equivalentBasePriceField;
        private string taxesField;
        private string feesField;
        private string servicesField;
        private string approximateTaxesField;
        private string approximateFeesField;
        #endregion

        #region AirPricingSolution public properties
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Journey")]
        public List<Journey> Journey
        {
            get
            {
                return this.journeyField;
            }
            set
            {
                this.journeyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LegRef")]
        public List<LegRef> LegRef
        {
            get
            {
                return this.legRefField;
            }
            set
            {
                this.legRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirPricingInfo")]
        public List<AirPricingInfo> AirPricingInfo
        {
            get
            {
                return this.airPricingInfoField;
            }
            set
            {
                this.airPricingInfoField = value;
            }
        }
        #endregion

        #region AirPricingSolution public Attribute
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
        [System.ComponentModel.DefaultValueAttribute(true)]
        public bool CompleteItinerary
        {
            get
            {
                return this.completeItineraryField;
            }
            set
            {
                this.completeItineraryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TotalPrice
        {
            get
            {
                return this.totalPriceField;
            }
            set
            {
                this.totalPriceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BasePrice
        {
            get
            {
                return this.basePriceField;
            }
            set
            {
                this.basePriceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ApproximateTotalPrice
        {
            get
            {
                return this.approximateTotalPriceField;
            }
            set
            {
                this.approximateTotalPriceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ApproximateBasePrice
        {
            get
            {
                return this.approximateBasePriceField;
            }
            set
            {
                this.approximateBasePriceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string EquivalentBasePrice
        {
            get
            {
                return this.equivalentBasePriceField;
            }
            set
            {
                this.equivalentBasePriceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Taxes
        {
            get
            {
                return this.taxesField;
            }
            set
            {
                this.taxesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Fees
        {
            get
            {
                return this.feesField;
            }
            set
            {
                this.feesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Services
        {
            get
            {
                return this.servicesField;
            }
            set
            {
                this.servicesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ApproximateTaxes
        {
            get
            {
                return this.approximateTaxesField;
            }
            set
            {
                this.approximateTaxesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ApproximateFees
        {
            get
            {
                return this.approximateFeesField;
            }
            set
            {
                this.approximateFeesField = value;
            }
        }
        #endregion

    }
    #endregion


    #region Journey Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v29_0")]
    public partial class Journey : object
    {
        private List<typeAirSegmentRef> airSegmentRefField;
        private string travelTimeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirSegmentRef", Order = 0)]
        public List<typeAirSegmentRef> AirSegmentRef
        {
            get
            {
                return this.airSegmentRefField;
            }
            set
            {
                this.airSegmentRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "duration")]
        public string TravelTime
        {
            get
            {
                return this.travelTimeField;
            }
            set
            {
                this.travelTimeField = value;
            }
        }


        #region AirSegmentRef Class
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v29_0")]
        public partial class typeAirSegmentRef : object
        {

            private string keyField;

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

        }
        #endregion
    }
    #endregion


    #region LegRef Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v29_0")]
    public partial class LegRef : object
    {

        private string keyField;

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

    }
    #endregion
    

    #region AirPricingInfo Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v29_0")]
    public partial class AirPricingInfo : object
    {
        private List<FareInfoRef> fareInfoRefField;
        private List<BookingInfo> bookingInfoField;
        private List<TaxInfo> taxInfoField;
        private string fareCalcField;
        private List<PassengerType> passengerTypeField;
        private FarePenalty changePenaltyField;
        private FarePenalty cancelPenaltyField;

        private string keyField;
        private string commandKeyField;
        private string totalPriceField;
        private string basePriceField;
        private string approximateTotalPriceField;
        private string approximateBasePriceField;
        private string taxesField;
        private string latestTicketingTimeField;
        private typePricingMethod pricingMethodField;
        private bool refundableField;
        private bool eTicketabilityFieldSpecified;
        private string platingCarrierField;
        private string providerCodeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FareInfoRef")]
        public List<FareInfoRef> FareInfoRef
        {
            get
            {
                return this.fareInfoRefField;
            }
            set
            {
                this.fareInfoRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BookingInfo")]
        public List<BookingInfo> BookingInfo
        {
            get
            {
                return this.bookingInfoField;
            }
            set
            {
                this.bookingInfoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TaxInfo")]
        public List<TaxInfo> TaxInfo
        {
            get
            {
                return this.taxInfoField;
            }
            set
            {
                this.taxInfoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string FareCalc
        {
            get
            {
                return this.fareCalcField;
            }
            set
            {
                this.fareCalcField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PassengerType")]
        public List<PassengerType> PassengerType
        {
            get
            {
                return this.passengerTypeField;
            }
            set
            {
                this.passengerTypeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public FarePenalty ChangePenalty
        {
            get
            {
                return this.changePenaltyField;
            }
            set
            {
                this.changePenaltyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public FarePenalty CancelPenalty
        {
            get
            {
                return this.cancelPenaltyField;
            }
            set
            {
                this.cancelPenaltyField = value;
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
        public string CommandKey
        {
            get
            {
                return this.commandKeyField;
            }
            set
            {
                this.commandKeyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TotalPrice
        {
            get
            {
                return this.totalPriceField;
            }
            set
            {
                this.totalPriceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BasePrice
        {
            get
            {
                return this.basePriceField;
            }
            set
            {
                this.basePriceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ApproximateTotalPrice
        {
            get
            {
                return this.approximateTotalPriceField;
            }
            set
            {
                this.approximateTotalPriceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ApproximateBasePrice
        {
            get
            {
                return this.approximateBasePriceField;
            }
            set
            {
                this.approximateBasePriceField = value;
            }
        }


        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Taxes
        {
            get
            {
                return this.taxesField;
            }
            set
            {
                this.taxesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LatestTicketingTime
        {
            get
            {
                return this.latestTicketingTimeField;
            }
            set
            {
                this.latestTicketingTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public typePricingMethod PricingMethod
        {
            get
            {
                return this.pricingMethodField;
            }
            set
            {
                this.pricingMethodField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Refundable
        {
            get
            {
                return this.refundableField;
            }
            set
            {
                this.refundableField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ETicketabilitySpecified
        {
            get
            {
                return this.eTicketabilityFieldSpecified;
            }
            set
            {
                this.eTicketabilityFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PlatingCarrier
        {
            get
            {
                return this.platingCarrierField;
            }
            set
            {
                this.platingCarrierField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ProviderCode
        {
            get
            {
                return this.providerCodeField;
            }
            set
            {
                this.providerCodeField = value;
            }
        }

    }
    #endregion


    #region FareInfoRef
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v29_0")]
    public partial class FareInfoRef : object
    {

        private string keyField;

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
    }
    #endregion

    #region BookingInfo
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v29_0")]
    public partial class BookingInfo : object
    {

        private string bookingCodeField;
        private typeCabinClass cabinClassField;
        private bool cabinClassFieldSpecified;
        private string fareInfoRefField;
        private string segmentRefField;
        private string couponRefField;
        private string airItinerarySolutionRefField;
        private string hostTokenRefField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BookingCode
        {
            get
            {
                return this.bookingCodeField;
            }
            set
            {
                this.bookingCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public typeCabinClass CabinClass
        {
            get
            {
                return this.cabinClassField;
            }
            set
            {
                this.cabinClassField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CabinClassSpecified
        {
            get
            {
                return this.cabinClassFieldSpecified;
            }
            set
            {
                this.cabinClassFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FareInfoRef
        {
            get
            {
                return this.fareInfoRefField;
            }
            set
            {
                this.fareInfoRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SegmentRef
        {
            get
            {
                return this.segmentRefField;
            }
            set
            {
                this.segmentRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CouponRef
        {
            get
            {
                return this.couponRefField;
            }
            set
            {
                this.couponRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AirItinerarySolutionRef
        {
            get
            {
                return this.airItinerarySolutionRefField;
            }
            set
            {
                this.airItinerarySolutionRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string HostTokenRef
        {
            get
            {
                return this.hostTokenRefField;
            }
            set
            {
                this.hostTokenRefField = value;
            }
        }

    }
    #endregion

    #region TaxInfo
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.travelport.com/schema/air_v29_0")]
    public partial class TaxInfo : object
    {
        private string categoryField;
        private string amountField;

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Category
        {
            get
            {
                return this.categoryField;
            }
            set
            {
                this.categoryField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }

    }
    #endregion

    #region PassengerType
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.travelport.com/schema/common_v29_0")]
    public partial class PassengerType : object
    {
        private string codeField;
        private string ageField;
        private System.DateTime dOBField;
        private bool dOBFieldSpecified;
        private string genderField;
        private bool pricePTCOnlyField;
        private bool pricePTCOnlyFieldSpecified;
        private string bookingTravelerRefField;
        private bool accompaniedPassengerField;
        private bool residencyTypeFieldSpecified;

        public PassengerType()
        {
            this.accompaniedPassengerField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Code
        {
            get
            {
                return this.codeField;
            }
            set
            {
                this.codeField = value;
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
        public bool PricePTCOnly
        {
            get
            {
                return this.pricePTCOnlyField;
            }
            set
            {
                this.pricePTCOnlyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PricePTCOnlySpecified
        {
            get
            {
                return this.pricePTCOnlyFieldSpecified;
            }
            set
            {
                this.pricePTCOnlyFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BookingTravelerRef
        {
            get
            {
                return this.bookingTravelerRefField;
            }
            set
            {
                this.bookingTravelerRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool AccompaniedPassenger
        {
            get
            {
                return this.accompaniedPassengerField;
            }
            set
            {
                this.accompaniedPassengerField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ResidencyTypeSpecified
        {
            get
            {
                return this.residencyTypeFieldSpecified;
            }
            set
            {
                this.residencyTypeFieldSpecified = value;
            }
        }

    }
    #endregion

    #region FarePenalty
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.travelport.com/schema/air_v29_0")]
    public partial class FarePenalty
    {

        private string amountField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string Amount
        {
            get
            {
                return this.amountField;
            }
            set
            {
                this.amountField = value;
            }
        }

    }
    #endregion

    #region typeCabinClass Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.travelport.com/schema/common_v29_0")]
    public enum typeCabinClass
    {

        /// <remarks/>
        First,

        /// <remarks/>
        Business,

        /// <remarks/>
        Economy,

        /// <remarks/>
        PremiumEconomy,

        /// <remarks/>
        PremiumFirst,
    }
    #endregion

    #region typePricingMethod Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.travelport.com/schema/air_v29_0")]
    public enum typePricingMethod
    {

        /// <remarks/>
        Auto,

        /// <remarks/>
        Manual,

        /// <remarks/>
        ManualFare,

        /// <remarks/>
        Guaranteed,

        /// <remarks/>
        Invalid,

        /// <remarks/>
        Restored,

        /// <remarks/>
        Ticketed,

        /// <remarks/>
        Unticketable,

        /// <remarks/>
        Reprice,

        /// <remarks/>
        Expired,

        /// <remarks/>
        AutoUsingPrivateFare,

        /// <remarks/>
        GuaranteedUsingAirlinePrivateFare,

        /// <remarks/>
        Airline,

        /// <remarks/>
        AgentAssisted,

        /// <remarks/>
        VerifyPrice,

        /// <remarks/>
        AltSegmentRemovedReprice,

        /// <remarks/>
        AuxiliarySegmentRemovedReprice,

        /// <remarks/>
        DuplicateSegmentRemovedReprice,

        /// <remarks/>
        Unknown,

        /// <remarks/>
        GuaranteedUsingAgencyPrivateFare,
    }
    #endregion
}
