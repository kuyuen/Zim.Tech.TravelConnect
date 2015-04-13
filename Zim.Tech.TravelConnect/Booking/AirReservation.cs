using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;

using uAPIBooking = Zim.Tech.TravelConnect.Travelport.uAPI.UniversalRecord;

namespace Zim.Tech.TravelConnect.Booking
{
    #region AirReservation Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AirReservation : uAPIBooking.BaseReservation
    {
        #region AirReservation private Attribute
        private TicketingModifiers[] ticketingModifiersField;
        //private OptionalServices optionalServicesField;
        //private SupplierLocator[] supplierLocatorField;
        //private ThirdPartyInformation[] thirdPartyInformationField;
        //private DocumentInfo documentInfoField;
        //private BookingTravelerRef[] bookingTravelerRefField;
        //private ProviderReservationInfoRef[] providerReservationInfoRefField;
        //private typeBaseAirSegment[] airSegmentField;
        //private AirPricingInfo[] airPricingInfoField;
        //private Payment[] paymentField;
        //private CreditCardAuth[] creditCardAuthField;
        //private FareNote[] fareNoteField;
        //private typeFeeInfo[] feeInfoField;
        //private typeTaxInfoWithPaymentRef[] taxInfoField;
        //private AssociatedRemark[] associatedRemarkField;
        //private PocketItineraryRemark[] pocketItineraryRemarkField;
        #endregion

        #region AirReservation public Attribute
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TicketingModifiers")]
        public TicketingModifiers[] TicketingModifiers
        {
            get
            {
                return this.ticketingModifiersField;
            }
            set
            {
                this.ticketingModifiersField = value;

            }
        }
        /*
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        public OptionalServices OptionalServices
        {
            get
            {
                return this.optionalServicesField;
            }
            set
            {
                this.optionalServicesField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SupplierLocator")]
        public SupplierLocator[] SupplierLocator
        {
            get
            {
                return this.supplierLocatorField;
            }
            set
            {
                this.supplierLocatorField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("ThirdPartyInformation")]
        public ThirdPartyInformation[] ThirdPartyInformation
        {
            get
            {
                return this.thirdPartyInformationField;
            }
            set
            {
                this.thirdPartyInformationField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public DocumentInfo DocumentInfo
        {
            get
            {
                return this.documentInfoField;
            }
            set
            {
                this.documentInfoField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BookingTravelerRef")]
        public BookingTravelerRef[] BookingTravelerRef
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
        [System.Xml.Serialization.XmlElementAttribute("ProviderReservationInfoRef")]
        public ProviderReservationInfoRef[] ProviderReservationInfoRef
        {
            get
            {
                return this.providerReservationInfoRefField;
            }
            set
            {
                this.providerReservationInfoRefField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirSegment")]
        public typeBaseAirSegment[] AirSegment
        {
            get
            {
                return this.airSegmentField;
            }
            set
            {
                this.airSegmentField = value;

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

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Payment")]
        public Payment[] Payment
        {
            get
            {
                return this.paymentField;
            }
            set
            {
                this.paymentField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("CreditCardAuth")]
        public CreditCardAuth[] CreditCardAuth
        {
            get
            {
                return this.creditCardAuthField;
            }
            set
            {
                this.creditCardAuthField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FareNote")]
        public FareNote[] FareNote
        {
            get
            {
                return this.fareNoteField;
            }
            set
            {
                this.fareNoteField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FeeInfo")]
        public typeFeeInfo[] FeeInfo
        {
            get
            {
                return this.feeInfoField;
            }
            set
            {
                this.feeInfoField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("TaxInfo")]
        public typeTaxInfoWithPaymentRef[] TaxInfo
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
        [System.Xml.Serialization.XmlElementAttribute("AssociatedRemark")]
        public AssociatedRemark[] AssociatedRemark
        {
            get
            {
                return this.associatedRemarkField;
            }
            set
            {
                this.associatedRemarkField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("PocketItineraryRemark")]
        public PocketItineraryRemark[] PocketItineraryRemark
        {
            get
            {
                return this.pocketItineraryRemarkField;
            }
            set
            {
                this.pocketItineraryRemarkField = value;

            }
        }
        */
        #endregion
    }
    #endregion


    #region TicketingModifiers Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v30_0")]
    public partial class TicketingModifiers : object
    {
        private DocumentSelect documentSelectField;

        #region ActionStatus private Attribute
        private string platingCarrierField;
        private bool exemptVATField;
        private bool exemptVATFieldSpecified;
        private bool netRemitAppliedField;
        private bool netRemitAppliedFieldSpecified;
        private bool freeTicketField;
        private bool freeTicketFieldSpecified;
        private string currencyOverrideCodeField;
        private string keyField;
        private string elStatField;
        private bool elStatFieldSpecified;
        private bool keyOverrideField;
        private bool keyOverrideFieldSpecified;
        #endregion

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public DocumentSelect DocumentSelect
        {
            get
            {
                return this.documentSelectField;
            }
            set
            {
                this.documentSelectField = value;

            }
        }

        #region TicketingModifiers public Attribute
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
        public bool ExemptVAT
        {
            get
            {
                return this.exemptVATField;
            }
            set
            {
                this.exemptVATField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ExemptVATSpecified
        {
            get
            {
                return this.exemptVATFieldSpecified;
            }
            set
            {
                this.exemptVATFieldSpecified = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool NetRemitApplied
        {
            get
            {
                return this.netRemitAppliedField;
            }
            set
            {
                this.netRemitAppliedField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool NetRemitAppliedSpecified
        {
            get
            {
                return this.netRemitAppliedFieldSpecified;
            }
            set
            {
                this.netRemitAppliedFieldSpecified = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool FreeTicket
        {
            get
            {
                return this.freeTicketField;
            }
            set
            {
                this.freeTicketField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FreeTicketSpecified
        {
            get
            {
                return this.freeTicketFieldSpecified;
            }
            set
            {
                this.freeTicketFieldSpecified = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CurrencyOverrideCode
        {
            get
            {
                return this.currencyOverrideCodeField;
            }
            set
            {
                this.currencyOverrideCodeField = value;

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
        #endregion
    }
    #endregion

    #region DocumentSelect Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v30_0")]
    public partial class DocumentSelect : object
    {
        #region DocumentSelect private Attribute
        private bool issueTicketOnlyField;
        private bool issueTicketOnlyFieldSpecified;
        private bool issueElectronicTicketField;
        private bool issueElectronicTicketFieldSpecified;
        private bool faxIndicatorField;
        private bool faxIndicatorFieldSpecified;
        #endregion

        #region DocumentSelect public Attribute
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool IssueTicketOnly
        {
            get
            {
                return this.issueTicketOnlyField;
            }
            set
            {
                this.issueTicketOnlyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IssueTicketOnlySpecified
        {
            get
            {
                return this.issueTicketOnlyFieldSpecified;
            }
            set
            {
                this.issueTicketOnlyFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool IssueElectronicTicket
        {
            get
            {
                return this.issueElectronicTicketField;
            }
            set
            {
                this.issueElectronicTicketField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool IssueElectronicTicketSpecified
        {
            get
            {
                return this.issueElectronicTicketFieldSpecified;
            }
            set
            {
                this.issueElectronicTicketFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool FaxIndicator
        {
            get
            {
                return this.faxIndicatorField;
            }
            set
            {
                this.faxIndicatorField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool FaxIndicatorSpecified
        {
            get
            {
                return this.faxIndicatorFieldSpecified;
            }
            set
            {
                this.faxIndicatorFieldSpecified = value;
            }
        }
        #endregion
    }
    #endregion
 
}
