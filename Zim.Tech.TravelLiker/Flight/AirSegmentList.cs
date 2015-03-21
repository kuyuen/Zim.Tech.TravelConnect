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
    public partial class AirSegmentList
    {
        private List<AirSegment> airSegmentListField = new List<AirSegment>();

        //[System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        //[System.Xml.Serialization.XmlArrayItemAttribute("FareInfo", typeof(FlightDetails), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        [System.Xml.Serialization.XmlElementAttribute("AirSegment", typeof(AirSegment), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<AirSegment> FareInfo
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
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.travelport.com/schema/air_v25_0")]
    public partial class AirSegment : object
    {
        #region AirSegment private properties
        //private AirAvailInfo[] airAvailInfoField;
        //private FlightDetailsRef[] flightDetailsRefField;
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
        private typeAvailabilitySource availabilitySourceField;
        //private bool availabilitySourceFieldSpecified;
        //private string aPISRequirementsRefField;
        //private bool blackListedField;
        //private bool blackListedFieldSpecified;
        //private string operationalStatusField;
        //private string numberInPartyField;
        #endregion

        #region FareInfo public properties
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("AirAvailInfo", Order = 2)]
        //public AirAvailInfo[] AirAvailInfo
        //{
        //    get
        //    {
        //        return this.airAvailInfoField;
        //    }
        //    set
        //    {
        //        this.airAvailInfoField = value;
        //    }
        ////}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("FlightDetailsRef", Order = 4)]
        //public FlightDetailsRef[] FlightDetailsRef
        //{
        //    get
        //    {
        //        return this.flightDetailsRefField;
        //    }
        //    set
        //    {
        //        this.flightDetailsRefField = value;
        //    }
        //}
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

        ///*
        //public typeBaseAirSegment()
        //{
        //    this.changeOfPlaneField = false;
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute(Order = 0)]
        //public SponsoredFltInfo SponsoredFltInfo
        //{
        //    get
        //    {
        //        return this.sponsoredFltInfoField;
        //    }
        //    set
        //    {
        //        this.sponsoredFltInfoField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute(Order = 1)]
        //public CodeshareInfo CodeshareInfo
        //{
        //    get
        //    {
        //        return this.codeshareInfoField;
        //    }
        //    set
        //    {
        //        this.codeshareInfoField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("FlightDetails", Order = 3)]
        //public FlightDetails[] FlightDetails
        //{
        //    get
        //    {
        //        return this.flightDetailsField;
        //    }
        //    set
        //    {
        //        this.flightDetailsField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("AlternateLocationDistanceRef", Order = 5)]
        //public AlternateLocationDistanceRef[] AlternateLocationDistanceRef
        //{
        //    get
        //    {
        //        return this.alternateLocationDistanceRefField;
        //    }
        //    set
        //    {
        //        this.alternateLocationDistanceRefField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute(Order = 6)]
        //public Connection Connection
        //{
        //    get
        //    {
        //        return this.connectionField;
        //    }
        //    set
        //    {
        //        this.connectionField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("SellMessage", Namespace = "http://www.travelport.com/schema/common_v25_0", Order = 7)]
        //public string[] SellMessage
        //{
        //    get
        //    {
        //        return this.sellMessageField;
        //    }
        //    set
        //    {
        //        this.sellMessageField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public bool OpenSegment
        //{
        //    get
        //    {
        //        return this.openSegmentField;
        //    }
        //    set
        //    {
        //        this.openSegmentField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool OpenSegmentSpecified
        //{
        //    get
        //    {
        //        return this.openSegmentFieldSpecified;
        //    }
        //    set
        //    {
        //        this.openSegmentFieldSpecified = value;
        //    }
        //}
        //*/

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public int Group
        //{
        //    get
        //    {
        //        return this.groupField;
        //    }
        //    set
        //    {
        //        this.groupField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string Carrier
        //{
        //    get
        //    {
        //        return this.carrierField;
        //    }
        //    set
        //    {
        //        this.carrierField = value;
        //    }
        //}
        ///*
        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public typeCabinClass CabinClass
        //{
        //    get
        //    {
        //        return this.cabinClassField;
        //    }
        //    set
        //    {
        //        this.cabinClassField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool CabinClassSpecified
        //{
        //    get
        //    {
        //        return this.cabinClassFieldSpecified;
        //    }
        //    set
        //    {
        //        this.cabinClassFieldSpecified = value;
        //    }
        //}
        //*/
        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string FlightNumber
        //{
        //    get
        //    {
        //        return this.flightNumberField;
        //    }
        //    set
        //    {
        //        this.flightNumberField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string Origin
        //{
        //    get
        //    {
        //        return this.originField;
        //    }
        //    set
        //    {
        //        this.originField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string Destination
        //{
        //    get
        //    {
        //        return this.destinationField;
        //    }
        //    set
        //    {
        //        this.destinationField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string DepartureTime
        //{
        //    get
        //    {
        //        return this.departureTimeField;
        //    }
        //    set
        //    {
        //        this.departureTimeField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string ArrivalTime
        //{
        //    get
        //    {
        //        return this.arrivalTimeField;
        //    }
        //    set
        //    {
        //        this.arrivalTimeField = value;
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string FlightTime
        //{
        //    get
        //    {
        //        return this.flightTimeField;
        //    }
        //    set
        //    {
        //        this.flightTimeField = value;
        //    }
        //}

        ///// <remarks/>
        ////[System.Xml.Serialization.XmlAttributeAttribute()]
        ////public string TravelTime
        ////{
        ////    get
        ////    {
        ////        return this.travelTimeField;
        ////    }
        ////    set
        ////    {
        ////        this.travelTimeField = value;
        ////    }
        ////}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        //public string Distance
        //{
        //    get
        //    {
        //        return this.distanceField;
        //    }
        //    set
        //    {
        //        this.distanceField = value;
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("ProviderCode");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("SupplierCode");
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string ParticipantLevel
        //{
        //    get
        //    {
        //        return this.participantLevelField;
        //    }
        //    set
        //    {
        //        this.participantLevelField = value;
        //        this.RaisePropertyChanged("ParticipantLevel");
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public bool LinkAvailability
        //{
        //    get
        //    {
        //        return this.linkAvailabilityField;
        //    }
        //    set
        //    {
        //        this.linkAvailabilityField = value;
        //        this.RaisePropertyChanged("LinkAvailability");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("LinkAvailabilitySpecified");
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string PolledAvailabilityOption
        //{
        //    get
        //    {
        //        return this.polledAvailabilityOptionField;
        //    }
        //    set
        //    {
        //        this.polledAvailabilityOptionField = value;
        //        this.RaisePropertyChanged("PolledAvailabilityOption");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("ClassOfService");
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public typeEticketability ETicketability
        //{
        //    get
        //    {
        //        return this.eTicketabilityField;
        //    }
        //    set
        //    {
        //        this.eTicketabilityField = value;
        //        this.RaisePropertyChanged("ETicketability");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("ETicketabilitySpecified");
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string Equipment
        //{
        //    get
        //    {
        //        return this.equipmentField;
        //    }
        //    set
        //    {
        //        this.equipmentField = value;
        //        this.RaisePropertyChanged("Equipment");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("MarriageGroup");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("MarriageGroupSpecified");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("NumberOfStops");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("NumberOfStopsSpecified");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("Seamless");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("SeamlessSpecified");
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //[System.ComponentModel.DefaultValueAttribute(false)]
        //public bool ChangeOfPlane
        //{
        //    get
        //    {
        //        return this.changeOfPlaneField;
        //    }
        //    set
        //    {
        //        this.changeOfPlaneField = value;
        //        this.RaisePropertyChanged("ChangeOfPlane");
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string GuaranteedPaymentCarrier
        //{
        //    get
        //    {
        //        return this.guaranteedPaymentCarrierField;
        //    }
        //    set
        //    {
        //        this.guaranteedPaymentCarrierField = value;
        //        this.RaisePropertyChanged("GuaranteedPaymentCarrier");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("HostTokenRef");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("ProviderReservationInfoRef");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("PassiveProviderReservationInfoRef");
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public bool OptionalServicesIndicator
        //{
        //    get
        //    {
        //        return this.optionalServicesIndicatorField;
        //    }
        //    set
        //    {
        //        this.optionalServicesIndicatorField = value;
        //        this.RaisePropertyChanged("OptionalServicesIndicator");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("OptionalServicesIndicatorSpecified");
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public typeAvailabilitySource AvailabilitySource
        //{
        //    get
        //    {
        //        return this.availabilitySourceField;
        //    }
        //    set
        //    {
        //        this.availabilitySourceField = value;
        //        this.RaisePropertyChanged("AvailabilitySource");
        //    }
        //}

        ///// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool AvailabilitySourceSpecified
        //{
        //    get
        //    {
        //        return this.availabilitySourceFieldSpecified;
        //    }
        //    set
        //    {
        //        this.availabilitySourceFieldSpecified = value;
        //        this.RaisePropertyChanged("AvailabilitySourceSpecified");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("APISRequirementsRef");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("BlackListed");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("BlackListedSpecified");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("OperationalStatus");
        //    }
        //}

        ///// <remarks/>
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
        //        this.RaisePropertyChanged("NumberInParty");
        //    }
        //}
        #endregion
    }
    #endregion
}
