using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;

namespace Zim.Tech.TravelLiker.Flight
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v25_0")]
    public partial class AirPricingSolution : object
    {
        private Journey[] journeyField;
        private LegRef[] legRefField;
        private AirPricingInfo[] airPricingInfoField;

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

        public AirPricingSolution()
        {
            this.completeItineraryField = true;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Journey")]
        public Journey[] Journey
        {
            get
            {
                return this.journeyField;
            }
            set
            {
                this.journeyField = value;
                this.RaisePropertyChanged("Journey");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LegRef")]
        public LegRef[] LegRef
        {
            get
            {
                return this.legRefField;
            }
            set
            {
                this.legRefField = value;
                this.RaisePropertyChanged("LegRef");
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirPricingInfo")]
        public AirPricingInfo[] AirPricingInfo
        {
            get
            {
                return this.airPricingInfoField;
            }
            set
            {
                this.airPricingInfoField = value;
                this.RaisePropertyChanged("AirPricingInfo");
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
                this.RaisePropertyChanged("Key");
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
                this.RaisePropertyChanged("CompleteItinerary");
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
                this.RaisePropertyChanged("TotalPrice");
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
                this.RaisePropertyChanged("BasePrice");
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
                this.RaisePropertyChanged("ApproximateTotalPrice");
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
                this.RaisePropertyChanged("ApproximateBasePrice");
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
                this.RaisePropertyChanged("EquivalentBasePrice");
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
                this.RaisePropertyChanged("Taxes");
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
                this.RaisePropertyChanged("Fees");
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
                this.RaisePropertyChanged("Services");
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
                this.RaisePropertyChanged("ApproximateTaxes");
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
                this.RaisePropertyChanged("ApproximateFees");
            }
        }

        public event System.ComponentModel.PropertyChangedEventHandler PropertyChanged;

        protected void RaisePropertyChanged(string propertyName)
        {
            System.ComponentModel.PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
            if ((propertyChanged != null))
            {
                propertyChanged(this, new System.ComponentModel.PropertyChangedEventArgs(propertyName));
            }
        }
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v25_0")]
    public partial class Journey : object
    {

        private typeAirSegmentRef[] airSegmentRefField;

        private string travelTimeField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirSegmentRef", Order = 0)]
        public typeAirSegmentRef[] AirSegmentRef
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


        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v25_0")]
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
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v25_0")]
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


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v25_0")]
    public partial class AirPricingInfo : object
    {
        private typeFareInfoRef[] fareInfoRefField;
        private typeBookingInfo[] bookingInfoField;
        private typeTaxInfo[] taxInfoField;
        private string fareCalcField;
        private typePassengerType[] passengerTypeField;
        private typeFarePenalty changePenaltyField;
        private typeFarePenalty cancelPenaltyField;

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
        public typeFareInfoRef[] FareInfoRef
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
        public typeBookingInfo[] BookingInfo
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
        public typeTaxInfo[] TaxInfo
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
        public typePassengerType[] PassengerType
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
        public typeFarePenalty ChangePenalty
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
        public typeFarePenalty CancelPenalty
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

        #region FareInfoRef
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v25_0")]
        public partial class typeFareInfoRef : object
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
        //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v25_0")]
        public partial class typeBookingInfo : object
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
        //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.travelport.com/schema/air_v25_0")]
        public partial class typeTaxInfo : object
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
        [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.travelport.com/schema/common_v25_0")]
        public partial class typePassengerType : object
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

            public typePassengerType()
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

        #region typeFarePenalty
        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.travelport.com/schema/air_v25_0")]
        public partial class typeFarePenalty
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
    }


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.travelport.com/schema/common_v25_0")]
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


    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.travelport.com/schema/air_v25_0")]
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
}
