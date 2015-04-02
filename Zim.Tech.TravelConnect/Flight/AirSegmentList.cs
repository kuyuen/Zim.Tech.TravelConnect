using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;

namespace Zim.Tech.TravelConnect.Flight
{
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AirSegmentList
    {
        private List<AirSegment> airSegmentListField = new List<AirSegment>();

        //[System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        //[System.Xml.Serialization.XmlArrayItemAttribute("FareInfo", typeof(FlightDetails), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        [System.Xml.Serialization.XmlElementAttribute("AirSegment", typeof(AirSegment), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<AirSegment> AirSegment
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
    }


    #region AirSegment Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.travelport.com/schema/air_v29_0")]
    public partial class AirSegment : object
    {
        #region AirSegment private properties
        private List<AirAvailInfo> airAvailInfoField = new List<AirAvailInfo>();
        private List<FlightDetailsRef> flightDetailsRefField = new List<FlightDetailsRef>();
        #endregion
        
        #region AirSegment private Attribute
        private string keyField;
        //private string[] sellMessageField;
        //private bool openSegmentField;
        //private bool openSegmentFieldSpecified;
        private int groupField;
        private string carrierField;
        //private typeCabinClass cabinClassField;
        //private bool cabinClassFieldSpecified;
        private string flightNumberField;
        private string originField;
        private string destinationField;
        private string departureTimeField;
        private string arrivalTimeField;
        private string flightTimeField;
        //private string travelTimeField;
        private string distanceField;
        //private string providerCodeField;
        //private string supplierCodeField;
        private string participantLevelField;
        private bool linkAvailabilityField;
        //private bool linkAvailabilityFieldSpecified;
        private string polledAvailabilityOptionField;
        //private string classOfServiceField;
        private typeEticketability eTicketabilityField;
        //private bool eTicketabilityFieldSpecified;
        private string equipmentField;
        //private int marriageGroupField;
        //private bool marriageGroupFieldSpecified;
        //private int numberOfStopsField;
        //private bool numberOfStopsFieldSpecified;
        //private bool seamlessField;
        //private bool seamlessFieldSpecified;
        private bool changeOfPlaneField;
        //private string guaranteedPaymentCarrierField;
        //private string hostTokenRefField;
        //private string providerReservationInfoRefField;
        //private string passiveProviderReservationInfoRefField;
        private bool optionalServicesIndicatorField;
        //private bool optionalServicesIndicatorFieldSpecified;
        private string availabilitySourceField;
        private string availabilityDisplayTypeField;
        //private bool availabilitySourceFieldSpecified;
        //private string aPISRequirementsRefField;
        //private bool blackListedField;
        //private bool blackListedFieldSpecified;
        //private string operationalStatusField;
        //private string numberInPartyField;
        #endregion

        #region FareInfo public properties
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirAvailInfo")]
        public List<AirAvailInfo> AirAvailInfo
        {
            get
            {
                return this.airAvailInfoField;
            }
            set
            {
                this.airAvailInfoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FlightDetailsRef")]
        public List<FlightDetailsRef> FlightDetailsRef
        {
            get
            {
                return this.flightDetailsRefField;
            }
            set
            {
                this.flightDetailsRefField = value;
            }
        }
        #endregion

        #region AirSegment private Attribute
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }

        /*
        public typeBaseAirSegment()
        {
            this.changeOfPlaneField = false;
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public SponsoredFltInfo SponsoredFltInfo
        {
            get
            {
                return this.sponsoredFltInfoField;
            }
            set
            {
                this.sponsoredFltInfoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public CodeshareInfo CodeshareInfo
        {
            get
            {
                return this.codeshareInfoField;
            }
            set
            {
                this.codeshareInfoField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("FlightDetails")]
        public FlightDetails[] FlightDetails
        {
            get
            {
                return this.flightDetailsField;
            }
            set
            {
                this.flightDetailsField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AlternateLocationDistanceRef")]
        public AlternateLocationDistanceRef[] AlternateLocationDistanceRef
        {
            get
            {
                return this.alternateLocationDistanceRefField;
            }
            set
            {
                this.alternateLocationDistanceRefField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public Connection Connection
        {
            get
            {
                return this.connectionField;
            }
            set
            {
                this.connectionField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("SellMessage", Namespace = "http://www.travelport.com/schema/common_v29_0")]
        public string[] SellMessage
        {
            get
            {
                return this.sellMessageField;
            }
            set
            {
                this.sellMessageField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool OpenSegment
        {
            get
            {
                return this.openSegmentField;
            }
            set
            {
                this.openSegmentField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool OpenSegmentSpecified
        {
            get
            {
                return this.openSegmentFieldSpecified;
            }
            set
            {
                this.openSegmentFieldSpecified = value;
            }
        }
        */

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int Group
        {
            get
            {
                return this.groupField;
            }
            set
            {
                this.groupField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Carrier
        {
            get
            {
                return this.carrierField;
            }
            set
            {
                this.carrierField = value;
            }
        }
        /*
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
        */
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FlightNumber
        {
            get
            {
                return this.flightNumberField;
            }
            set
            {
                this.flightNumberField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Origin
        {
            get
            {
                return this.originField;
            }
            set
            {
                this.originField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Destination
        {
            get
            {
                return this.destinationField;
            }
            set
            {
                this.destinationField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DepartureTime
        {
            get
            {
                return this.departureTimeField;
            }
            set
            {
                this.departureTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ArrivalTime
        {
            get
            {
                return this.arrivalTimeField;
            }
            set
            {
                this.arrivalTimeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FlightTime
        {
            get
            {
                return this.flightTimeField;
            }
            set
            {
                this.flightTimeField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string TravelTime
        //{
        //    get
        //    {
        //        return this.travelTimeField;
        //    }
        //    set
        //    {
        //        this.travelTimeField = value;
        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string Distance
        {
            get
            {
                return this.distanceField;
            }
            set
            {
                this.distanceField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string ProviderCode
        //{
        //    get
        //    {
        //        return this.providerCodeField;
        //    }
        //    set
        //    {
        //        this.providerCodeField = value;
        //    }
        //}

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string SupplierCode
        //{
        //    get
        //    {
        //        return this.supplierCodeField;
        //    }
        //    set
        //    {
        //        this.supplierCodeField = value;
        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ParticipantLevel
        {
            get
            {
                return this.participantLevelField;
            }
            set
            {
                this.participantLevelField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool LinkAvailability
        {
            get
            {
                return this.linkAvailabilityField;
            }
            set
            {
                this.linkAvailabilityField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool LinkAvailabilitySpecified
        //{
        //    get
        //    {
        //        return this.linkAvailabilityFieldSpecified;
        //    }
        //    set
        //    {
        //        this.linkAvailabilityFieldSpecified = value;
        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PolledAvailabilityOption
        {
            get
            {
                return this.polledAvailabilityOptionField;
            }
            set
            {
                this.polledAvailabilityOptionField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string ClassOfService
        //{
        //    get
        //    {
        //        return this.classOfServiceField;
        //    }
        //    set
        //    {
        //        this.classOfServiceField = value;
        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public typeEticketability ETicketability
        {
            get
            {
                return this.eTicketabilityField;
            }
            set
            {
                this.eTicketabilityField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool ETicketabilitySpecified
        //{
        //    get
        //    {
        //        return this.eTicketabilityFieldSpecified;
        //    }
        //    set
        //    {
        //        this.eTicketabilityFieldSpecified = value;
        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Equipment
        {
            get
            {
                return this.equipmentField;
            }
            set
            {
                this.equipmentField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public int MarriageGroup
        //{
        //    get
        //    {
        //        return this.marriageGroupField;
        //    }
        //    set
        //    {
        //        this.marriageGroupField = value;
        //    }
        //}

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool MarriageGroupSpecified
        //{
        //    get
        //    {
        //        return this.marriageGroupFieldSpecified;
        //    }
        //    set
        //    {
        //        this.marriageGroupFieldSpecified = value;
        //    }
        //}

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public int NumberOfStops
        //{
        //    get
        //    {
        //        return this.numberOfStopsField;
        //    }
        //    set
        //    {
        //        this.numberOfStopsField = value;
        //    }
        //}

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool NumberOfStopsSpecified
        //{
        //    get
        //    {
        //        return this.numberOfStopsFieldSpecified;
        //    }
        //    set
        //    {
        //        this.numberOfStopsFieldSpecified = value;
        //    }
        //}

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public bool Seamless
        //{
        //    get
        //    {
        //        return this.seamlessField;
        //    }
        //    set
        //    {
        //        this.seamlessField = value;
        //    }
        //}

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool SeamlessSpecified
        //{
        //    get
        //    {
        //        return this.seamlessFieldSpecified;
        //    }
        //    set
        //    {
        //        this.seamlessFieldSpecified = value;
        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        [System.ComponentModel.DefaultValueAttribute(false)]
        public bool ChangeOfPlane
        {
            get
            {
                return this.changeOfPlaneField;
            }
            set
            {
                this.changeOfPlaneField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string GuaranteedPaymentCarrier
        //{
        //    get
        //    {
        //        return this.guaranteedPaymentCarrierField;
        //    }
        //    set
        //    {
        //        this.guaranteedPaymentCarrierField = value;;
        //    }
        //}

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string HostTokenRef
        //{
        //    get
        //    {
        //        return this.hostTokenRefField;
        //    }
        //    set
        //    {
        //        this.hostTokenRefField = value;
        //    }
        //}

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string ProviderReservationInfoRef
        //{
        //    get
        //    {
        //        return this.providerReservationInfoRefField;
        //    }
        //    set
        //    {
        //        this.providerReservationInfoRefField = value;
        //    }
        //}

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string PassiveProviderReservationInfoRef
        //{
        //    get
        //    {
        //        return this.passiveProviderReservationInfoRefField;
        //    }
        //    set
        //    {
        //        this.passiveProviderReservationInfoRefField = value;
        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool OptionalServicesIndicator
        {
            get
            {
                return this.optionalServicesIndicatorField;
            }
            set
            {
                this.optionalServicesIndicatorField = value;
            }
        }
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool OptionalServicesIndicatorSpecified
        //{
        //    get
        //    {
        //        return this.optionalServicesIndicatorFieldSpecified;
        //    }
        //    set
        //    {
        //        this.optionalServicesIndicatorFieldSpecified = value;
        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AvailabilitySource
        {
            get
            {
                return this.availabilitySourceField;
            }
            set
            {
                this.availabilitySourceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AvailabilityDisplayType
        {
            get
            {
                return this.availabilityDisplayTypeField;
            }
            set
            {
                this.availabilityDisplayTypeField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string APISRequirementsRef
        //{
        //    get
        //    {
        //        return this.aPISRequirementsRefField;
        //    }
        //    set
        //    {
        //        this.aPISRequirementsRefField = value;
        //    }
        //}

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public bool BlackListed
        //{
        //    get
        //    {
        //        return this.blackListedField;
        //    }
        //    set
        //    {
        //        this.blackListedField = value;
        //    }
        //}

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool BlackListedSpecified
        //{
        //    get
        //    {
        //        return this.blackListedFieldSpecified;
        //    }
        //    set
        //    {
        //        this.blackListedFieldSpecified = value;
        //    }
        //}

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string OperationalStatus
        //{
        //    get
        //    {
        //        return this.operationalStatusField;
        //    }
        //    set
        //    {
        //        this.operationalStatusField = value;
        //    }
        //}

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute(DataType = "positiveInteger")]
        //public string NumberInParty
        //{
        //    get
        //    {
        //        return this.numberInPartyField;
        //    }
        //    set
        //    {
        //        this.numberInPartyField = value;
        //    }
        //}
        #endregion
    }
    
    
    #region AirAvailInfo Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.travelport.com/schema/air_v29_0")]
    public partial class AirAvailInfo : object
    {
        #region AirAvailInfo private properties
        private BookingCodeInfo[] bookingCodeInfoField;
        //private AirAvailInfoFareTokenInfo[] fareTokenInfoField;
        #endregion
        
        #region AirAvailInfo private Attribute
        private string providerCodeField;
        private string hostTokenRefField;
        #endregion
        
        #region AirAvailInfo private public
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("BookingCodeInfo")]
        public BookingCodeInfo[] BookingCodeInfo {
            get {
                return this.bookingCodeInfoField;
            }
            set {
                this.bookingCodeInfoField = value;
            }
        }
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("FareTokenInfo")]
        //public AirAvailInfoFareTokenInfo[] FareTokenInfo {
        //    get {
        //        return this.fareTokenInfoField;
        //    }
        //    set {
        //        this.fareTokenInfoField = value;
        //        this.RaisePropertyChanged("FareTokenInfo");
        //    }
        //}
        #endregion
        
        #region AirAvailInfo private public
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ProviderCode {
            get {
                return this.providerCodeField;
            }
            set {
                this.providerCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string HostTokenRef {
            get {
                return this.hostTokenRefField;
            }
            set {
                this.hostTokenRefField = value;
            }
        }
        #endregion
        
    }
    
    #region BookingCodeInfo Class
        /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.travelport.com/schema/air_v29_0")]
    public partial class BookingCodeInfo : object
    {
        #region BookingCodeInfo private properties
        private typeCabinClass cabinClassField;
        private bool cabinClassFieldSpecified;
        private string bookingCountsField;
        #endregion
        
        #region BookingCodeInfo public properties
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public typeCabinClass CabinClass {
            get {
                return this.cabinClassField;
            }
            set {
                this.cabinClassField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool CabinClassSpecified {
            get {
                return this.cabinClassFieldSpecified;
            }
            set {
                this.cabinClassFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BookingCounts {
            get {
                return this.bookingCountsField;
            }
            set {
                this.bookingCountsField = value;
            }
        }
        #endregion
    }
    #endregion

    #endregion
    

    #region FlightDetailsRef Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.travelport.com/schema/air_v29_0")]
    public partial class FlightDetailsRef : object
    {
        private string keyField;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Key {
            get {
                return this.keyField;
            }
            set {
                this.keyField = value;
            }
        }
    }
    #endregion

    #endregion

    #region AvailabilitySource Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.travelport.com/schema/air_v29_0")]
    public enum typeAvailabilitySource {
        
        /// <remarks/>
        AvailStatusTTY,
        
        /// <remarks/>
        CacheClosedStatus,
        
        /// <remarks/>
        CacheAVS,
        
        /// <remarks/>
        DirectAccess,
        
        /// <remarks/>
        CacheDirectAccess,
        
        /// <remarks/>
        CacheSellFailures,
        
        /// <remarks/>
        CacheGUI,
        
        /// <remarks/>
        CacheLastSeatAvail,
        
        /// <remarks/>
        CacheP2PJourney,
        
        /// <remarks/>
        CacheP2PMixClass,
        
        /// <remarks/>
        CacheP2PLink,
        
        /// <remarks/>
        LastSeatAvail,
        
        /// <remarks/>
        TEManualSell,
        
        /// <remarks/>
        CacheOtherVendorsResponse,
        
        /// <remarks/>
        StatusOverlaid,
        
        /// <remarks/>
        CacheSeamless,
        
        /// <remarks/>
        Seamless,
        
        /// <remarks/>
        UnknownSource,
    }
    #endregion


    #region Eticketability Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.travelport.com/schema/air_v29_0")]
    public enum typeEticketability
    {

        /// <remarks/>
        Yes,

        /// <remarks/>
        No,

        /// <remarks/>
        Required,

        /// <remarks/>
        Ticketless,
    }
    #endregion
}
