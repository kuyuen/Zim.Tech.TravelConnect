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
    public partial class AirReservation
    {
        #region AirReservation private Properties
        //private List<TicketingModifiers> ticketingModifiersField;
        private List<SupplierLocator> supplierLocatorField;
        protected List<BookingTravelerRef> bookingTravelerRefField;
        protected List<ProviderReservationInfoRef> providerReservationInfoRefField;
        private List<Flight.AirSegment> airSegmentListField;
        #endregion
        #region AirReservation private Attribute
        private string locatorCodeField;
        private string createDateField;
        private string modifiedDateField;
        //private OptionalServices optionalServicesField;
        //private ThirdPartyInformation[] thirdPartyInformationField;
        //private DocumentInfo documentInfoField;
        //private AirPricingInfo[] airPricingInfoField;
        //private Payment[] paymentField;
        //private CreditCardAuth[] creditCardAuthField;
        //private FareNote[] fareNoteField;
        //private typeFeeInfo[] feeInfoField;
        //private typeTaxInfoWithPaymentRef[] taxInfoField;
        //private AssociatedRemark[] associatedRemarkField;
        //private PocketItineraryRemark[] pocketItineraryRemarkField;
        #endregion

        #region AirReservation public Properties
        /// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("TicketingModifiers")]
        //public List<TicketingModifiers> TicketingModifiers
        //{
        //    get
        //    {
        //        return this.ticketingModifiersField;
        //    }
        //    set
        //    {
        //        this.ticketingModifiersField = value;

        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirSegment", typeof(Flight.AirSegment), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<Flight.AirSegment> AirSegment
        {
            get
            {
                return this.airSegmentListField;
            }
            set
            {
                this.airSegmentListField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SupplierLocator")]
        public List<SupplierLocator> SupplierLocator
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
        [System.Xml.Serialization.XmlElementAttribute("BookingTravelerRef")]
        public List<BookingTravelerRef> BookingTravelerRef
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
        public List<ProviderReservationInfoRef> ProviderReservationInfoRef
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

        #endregion

        #region AirReservation public Attribute
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string LocatorCode
        {
            get
            {
                return this.locatorCodeField;
            }
            set
            {
                this.locatorCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CreateDate
        {
            get
            {
                return this.createDateField;
            }
            set
            {
                this.createDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ModifiedDate
        {
            get
            {
                return this.modifiedDateField;
            }
            set
            {
                this.modifiedDateField = value;
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
     

    #region SupplierLocator Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/common_v30_0")]
    public partial class SupplierLocator : object
    {

        #region SupplierLocator public Attribute
        private string supplierCodeField;
        private string supplierLocatorCodeField;
        private string providerReservationInfoRefField;
        private System.DateTime createDateTimeField;
        //private bool createDateTimeFieldSpecified;
        #endregion

        #region SupplierLocator public Attribute
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SupplierCode
        {
            get
            {
                return this.supplierCodeField;
            }
            set
            {
                this.supplierCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SupplierLocatorCode
        {
            get
            {
                return this.supplierLocatorCodeField;
            }
            set
            {
                this.supplierLocatorCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ProviderReservationInfoRef
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
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime CreateDateTime
        {
            get
            {
                return this.createDateTimeField;
            }
            set
            {
                this.createDateTimeField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool CreateDateTimeSpecified
        //{
        //    get
        //    {
        //        return this.createDateTimeFieldSpecified;
        //    }
        //    set
        //    {
        //        this.createDateTimeFieldSpecified = value;
        //    }
        //}
        #endregion
    }

    #endregion


    #region BookingTravelerRef Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/common_v30_0")]
    public partial class BookingTravelerRef : object
    {

        //private LoyaltyCardRef[] loyaltyCardRefField;
        //private DriversLicenseRef driversLicenseRefField;
        //private DiscountCardRef[] discountCardRefField;
        private string keyField;

        /*
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("LoyaltyCardRef")]
        public LoyaltyCardRef[] LoyaltyCardRef
        {
            get
            {
                return this.loyaltyCardRefField;
            }
            set
            {
                this.loyaltyCardRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public DriversLicenseRef DriversLicenseRef
        {
            get
            {
                return this.driversLicenseRefField;
            }
            set
            {
                this.driversLicenseRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("DiscountCardRef")]
        public DiscountCardRef[] DiscountCardRef
        {
            get
            {
                return this.discountCardRefField;
            }
            set
            {
                this.discountCardRefField = value;
            }
        }
        */

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

    #region ProviderReservationInfoRef Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/common_v30_0")]
    public partial class ProviderReservationInfoRef : object
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
