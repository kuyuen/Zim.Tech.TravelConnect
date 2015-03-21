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
    public partial class FareInfoList
    {
        private List<FareInfo> fareInfoListField = new List<FareInfo>();

        //[System.Xml.Serialization.XmlArrayAttribute(Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        //[System.Xml.Serialization.XmlArrayItemAttribute("FareInfo", typeof(FlightDetails), Form = System.Xml.Schema.XmlSchemaForm.Unqualified, IsNullable = false)]
        [System.Xml.Serialization.XmlElementAttribute("FareInfo", typeof(FareInfo), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
          public List<FareInfo> FareInfo
        {
            get
            {
                return this.fareInfoListField;
            }
            set
            {
                this.fareInfoListField = value;
            }
        }
    }

    #region FareInfo Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.travelport.com/schema/air_v25_0")]
    public partial class FareInfo : object {

        #region FareInfo private Attribute
        private string keyField;
        private string fareBasisField;
        private string passengerTypeCodeField;
        private string originField;
        private string destinationField;
        private string effectiveDateField;
        //private System.DateTime travelDateField;
        private bool travelDateFieldSpecified;
        private System.DateTime departureDateField;
        private bool departureDateFieldSpecified;
        private string amountField;
        //private bool privateFareFieldSpecified;
        private bool negotiatedFareField;
        //private bool negotiatedFareFieldSpecified;
        //private string tourCodeField;
        //private string waiverCodeField;
        private System.DateTime notValidBeforeField;
        //private bool notValidBeforeFieldSpecified;
        private System.DateTime notValidAfterField;
        //private bool notValidAfterFieldSpecified;
        //private string pseudoCityCodeField;
        //private string fareFamilyField;
        //private bool promotionalFareField;
        //private bool promotionalFareFieldSpecified;
        //private string carCodeField;
        //private string valueCodeField;
        //private bool elStatFieldSpecified;
        //private bool keyOverrideField;
        //private bool keyOverrideFieldSpecified;
        //private bool bulkTicketField;
        //private bool bulkTicketFieldSpecified;
        //private bool inclusiveTourField;
        //private bool inclusiveTourFieldSpecified;
        #endregion

        #region FareInfo private properties
        private List<FareSurcharge> fareSurchargeField = new List<FareSurcharge>();
        private BaggageAllowance baggageAllowanceField;
        private FareRuleKey fareRuleKeyField;
        #endregion

        #region FareInfo public Attribute
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
        public string FareBasis
        {
            get
            {
                return this.fareBasisField;
            }
            set
            {
                this.fareBasisField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PassengerTypeCode
        {
            get
            {
                return this.passengerTypeCodeField;
            }
            set
            {
                this.passengerTypeCodeField = value;
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
        public string EffectiveDate
        {
            get
            {
                return this.effectiveDateField;
            }
            set
            {
                this.effectiveDateField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public System.DateTime TravelDate
        //{
        //    get
        //    {
        //        return this.travelDateField;
        //    }
        //    set
        //    {
        //        this.travelDateField = value;
        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool TravelDateSpecified
        {
            get
            {
                return this.travelDateFieldSpecified;
            }
            set
            {
                this.travelDateFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime DepartureDate
        {
            get
            {
                return this.departureDateField;
            }
            set
            {
                this.departureDateField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool DepartureDateSpecified
        {
            get
            {
                return this.departureDateFieldSpecified;
            }
            set
            {
                this.departureDateFieldSpecified = value;
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

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool PrivateFareSpecified
        //{
        //    get
        //    {
        //        return this.privateFareFieldSpecified;
        //    }
        //    set
        //    {
        //        this.privateFareFieldSpecified = value;
        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool NegotiatedFare
        {
            get
            {
                return this.negotiatedFareField;
            }
            set
            {
                this.negotiatedFareField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool NegotiatedFareSpecified
        //{
        //    get
        //    {
        //        return this.negotiatedFareFieldSpecified;
        //    }
        //    set
        //    {
        //        this.negotiatedFareFieldSpecified = value;
        //    }
        //}

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string TourCode
        //{
        //    get
        //    {
        //        return this.tourCodeField;
        //    }
        //    set
        //    {
        //        this.tourCodeField = value;
        //    }
        //}

        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string WaiverCode
        //{
        //    get
        //    {
        //        return this.waiverCodeField;
        //    }
        //    set
        //    {
        //        this.waiverCodeField = value;
        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime NotValidBefore
        {
            get
            {
                return this.notValidBeforeField;
            }
            set
            {
                this.notValidBeforeField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool NotValidBeforeSpecified
        //{
        //    get
        //    {
        //        return this.notValidBeforeFieldSpecified;
        //    }
        //    set
        //    {
        //        this.notValidBeforeFieldSpecified = value;
        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime NotValidAfter
        {
            get
            {
                return this.notValidAfterField;
            }
            set
            {
                this.notValidAfterField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool NotValidAfterSpecified
        //{
        //    get
        //    {
        //        return this.notValidAfterFieldSpecified;
        //    }
        //    set
        //    {
        //        this.notValidAfterFieldSpecified = value;
        //    }
        //}

        /*
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string PseudoCityCode
        {
            get
            {
                return this.pseudoCityCodeField;
            }
            set
            {
                this.pseudoCityCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string FareFamily
        {
            get
            {
                return this.fareFamilyField;
            }
            set
            {
                this.fareFamilyField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool PromotionalFare
        {
            get
            {
                return this.promotionalFareField;
            }
            set
            {
                this.promotionalFareField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PromotionalFareSpecified
        {
            get
            {
                return this.promotionalFareFieldSpecified;
            }
            set
            {
                this.promotionalFareFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CarCode
        {
            get
            {
                return this.carCodeField;
            }
            set
            {
                this.carCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ValueCode
        {
            get
            {
                return this.valueCodeField;
            }
            set
            {
                this.valueCodeField = value;
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool BulkTicket
        {
            get
            {
                return this.bulkTicketField;
            }
            set
            {
                this.bulkTicketField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool BulkTicketSpecified
        {
            get
            {
                return this.bulkTicketFieldSpecified;
            }
            set
            {
                this.bulkTicketFieldSpecified = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool InclusiveTour
        {
            get
            {
                return this.inclusiveTourField;
            }
            set
            {
                this.inclusiveTourField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InclusiveTourSpecified
        {
            get
            {
                return this.inclusiveTourFieldSpecified;
            }
            set
            {
                this.inclusiveTourFieldSpecified = value;
            }
        }
        */
        #endregion        

        #region FareInfo public properties
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public List<FareSurcharge> FareSurcharge
        {
            get
            {
                return this.fareSurchargeField;
            }
            set
            {
                this.fareSurchargeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public BaggageAllowance BaggageAllowance
        {
            get
            {
                return this.baggageAllowanceField;
            }
            set
            {
                this.baggageAllowanceField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public FareRuleKey FareRuleKey
        {
            get
            {
                return this.fareRuleKeyField;
            }
            set
            {
                this.fareRuleKeyField = value;
            }
        }
        #endregion
    }
    #endregion
    

    #region FareSurcharge Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.travelport.com/schema/air_v25_0")]
    public partial class FareSurcharge : object 
    {
        
        #region FareSurcharge private properties
        private string keyField;
        private string typeField;
        private string amountField;
        private string segmentRefField;
        private string couponRefField;
        private bool elStatFieldSpecified;
        private bool keyOverrideField;
        private bool keyOverrideFieldSpecified;
        #endregion
        
        #region FareSurcharge public properties
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
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Type {
            get {
                return this.typeField;
            }
            set {
                this.typeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Amount {
            get {
                return this.amountField;
            }
            set {
                this.amountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string SegmentRef {
            get {
                return this.segmentRefField;
            }
            set {
                this.segmentRefField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string CouponRef {
            get {
                return this.couponRefField;
            }
            set {
                this.couponRefField = value;
            }
        }
                
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ElStatSpecified {
            get {
                return this.elStatFieldSpecified;
            }
            set {
                this.elStatFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool KeyOverride {
            get {
                return this.keyOverrideField;
            }
            set {
                this.keyOverrideField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool KeyOverrideSpecified {
            get {
                return this.keyOverrideFieldSpecified;
            }
            set {
                this.keyOverrideFieldSpecified = value;
            }
        }
        #endregion
    }
    #endregion    


    #region BaggageAllowance Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v25_0")]
    public partial class BaggageAllowance : object
    {
        #region FlightDetails private properties
        private string numberOfPiecesField;
        private typeWeight maxWeightField;
        #endregion

        #region FlightDetails public properties
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public string NumberOfPieces
        {
            get
            {
                return this.numberOfPiecesField;
            }
            set
            {
                this.numberOfPiecesField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public typeWeight MaxWeight
        {
            get
            {
                return this.maxWeightField;
            }
            set
            {
                this.maxWeightField = value;
            }
        }
        #endregion

    }

    #region Weight Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.travelport.com/schema/air_v25_0")]
    public partial class typeWeight : object
    {
        #region typeWeight private properties
        private string valueField;
        private typeUnitWeight unitField;
        private bool unitFieldSpecified;
        #endregion

        #region typeWeight public properties
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public typeUnitWeight Unit
        {
            get
            {
                return this.unitField;
            }
            set
            {
                this.unitField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool UnitSpecified
        {
            get
            {
                return this.unitFieldSpecified;
            }
            set
            {
                this.unitFieldSpecified = value;
            }
        }
        #endregion
    }
    #endregion

    #region typeUnitWeight Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace = "http://www.travelport.com/schema/air_v25_0")]
    public enum typeUnitWeight
    {

        /// <remarks/>
        Kilograms,

        /// <remarks/>
        Pounds,
    }
    #endregion
    #endregion


    #region FareRuleKey Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v25_0")]
    public partial class FareRuleKey : object
    {
        #region FareRuleKey private properties
        private string fareInfoRefField;
        private string providerCodeField;
        private string valueField;
        #endregion

        #region FareRuleKey public properties
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

        /// <remarks/>
        [System.Xml.Serialization.XmlTextAttribute()]
        public string Value
        {
            get
            {
                return this.valueField;
            }
            set
            {
                this.valueField = value;
            }
        }
        #endregion
    }  
    #endregion    
}
