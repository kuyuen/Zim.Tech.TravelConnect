using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;

namespace Zim.Tech.TravelLiker.Hotel
{
    
    #region HotelSearchResult Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/hotel_v29_0")]
    public partial class HotelSearchResult : object
    {

        #region HotelSearchResult private properties
        private HotelProperty hotelPropertyField;
        private List<RateInfo> rateInfoField;
        //private MediaItem mediaItemField;
        #endregion

        #region HotelSearchResult public properties
        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute()]
        public HotelProperty HotelProperty
        {
            get
            {
                return this.hotelPropertyField;
            }
            set
            {
                this.hotelPropertyField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("HotelSearchError")]
        //public typeResultMessage[] HotelSearchError
        //{
        //    get
        //    {
        //        return this.hotelSearchErrorField;
        //    }
        //    set
        //    {
        //        this.hotelSearchErrorField = value;
        //    }
        //}

        /// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("CorporateDiscountID", Namespace = "http://www.travelport.com/schema/common_v29_0")]
        //public CorporateDiscountID[] CorporateDiscountID
        //{
        //    get
        //    {
        //        return this.corporateDiscountIDField;
        //    }
        //    set
        //    {
        //        this.corporateDiscountIDField = value;
        //    }
        //}

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("RateInfo")]
        public List<RateInfo> RateInfo
        {
            get
            {
                return this.rateInfoField;
            }
            set
            {
                this.rateInfoField = value;
            }
        }

        /// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.travelport.com/schema/common_v29_0")]
        //public MediaItem MediaItem
        //{
        //    get
        //    {
        //        return this.mediaItemField;
        //    }
        //    set
        //    {
        //        this.mediaItemField = value;
        //    }
        //}
        #endregion

    }
    #endregion


    #region HotelProperty Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.travelport.com/schema/hotel_v29_0")]
    public partial class HotelProperty : object {
        
        #region HotelProperty private properties
        private List<string> propertyAddressField;   
        private Distance distanceField;        
        private Amenities amenitiesField;        
        #endregion

        #region HotelProperty private Attribute
        //private PhoneNumber[] phoneNumberField;        
        //private CoordinateLocation coordinateLocationField;     
        //private HotelRating[] hotelRatingField;        
        private string hotelChainField;        
        private string hotelCodeField;        
        private string hotelLocationField;        
        private string nameField;        
        private string vendorLocationKeyField;        
        private string hotelTransportationField;        
        private typeReserveRequirement reserveRequirementField;        
        //private bool reserveRequirementFieldSpecified;        
        private string participationLevelField;        
        private typeHotelAvailability availabilityField;        
        //private bool availabilityFieldSpecified;        
        //private bool featuredPropertyField;        
        //private bool featuredPropertyFieldSpecified;        
        //private string keyField;        
        //private bool preferredOptionField;        
        //private bool preferredOptionFieldSpecified;        
        //private bool moreRatesField;        
        //private bool moreRatesFieldSpecified;        
        //private typeNetTransCommission netTransCommissionIndField;        
        //private bool netTransCommissionIndFieldSpecified;
        #endregion

        #region HotelProperty public Attribute
        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute()]
        [System.Xml.Serialization.XmlArrayItemAttribute("Address")]
        public List<string> PropertyAddress
        {
            get
            {
                return this.propertyAddressField;
            }
            set
            {
                this.propertyAddressField = value;
            }
        }

        //[System.Xml.Serialization.XmlElementAttribute(Namespace = "http://www.travelport.com/schema/common_v29_0")]
        public Distance Distance
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
        //[System.Xml.Serialization.XmlArrayAttribute()]
        //[System.Xml.Serialization.XmlArrayItemAttribute("Amenity")]
        public Amenities Amenities
        {
            get
            {
                return this.amenitiesField;
            }
            set
            {
                this.amenitiesField = value;
            }
        }
        #endregion

        #region HotelProperty public properties
        /// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("PhoneNumber", Namespace="http://www.travelport.com/schema/common_v29_0")]
        //public PhoneNumber[] PhoneNumber {
        //    get {
        //        return this.phoneNumberField;
        //    }
        //    set {
        //        this.phoneNumberField = value;
        //    }
        //}
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute(Namespace="http://www.travelport.com/schema/common_v29_0")]
        //public CoordinateLocation CoordinateLocation {
        //    get {
        //        return this.coordinateLocationField;
        //    }
        //    set {
        //        this.coordinateLocationField = value;
        //    }
        //}
        
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlElementAttribute("HotelRating")]
        //public HotelRating[] HotelRating {
        //    get {
        //        return this.hotelRatingField;
        //    }
        //    set {
        //        this.hotelRatingField = value;
        //    }
        //}
                
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string HotelChain {
            get {
                return this.hotelChainField;
            }
            set {
                this.hotelChainField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string HotelCode {
            get {
                return this.hotelCodeField;
            }
            set {
                this.hotelCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string HotelLocation {
            get {
                return this.hotelLocationField;
            }
            set {
                this.hotelLocationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Name {
            get {
                return this.nameField;
            }
            set {
                this.nameField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string VendorLocationKey {
            get {
                return this.vendorLocationKeyField;
            }
            set {
                this.vendorLocationKeyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string HotelTransportation {
            get {
                return this.hotelTransportationField;
            }
            set {
                this.hotelTransportationField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public typeReserveRequirement ReserveRequirement {
            get {
                return this.reserveRequirementField;
            }
            set {
                this.reserveRequirementField = value;
            }
        }
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool ReserveRequirementSpecified {
        //    get {
        //        return this.reserveRequirementFieldSpecified;
        //    }
        //    set {
        //        this.reserveRequirementFieldSpecified = value;
        //    }
        //}
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ParticipationLevel {
            get {
                return this.participationLevelField;
            }
            set {
                this.participationLevelField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public typeHotelAvailability Availability {
            get {
                return this.availabilityField;
            }
            set {
                this.availabilityField = value;
            }
        }
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool AvailabilitySpecified {
        //    get {
        //        return this.availabilityFieldSpecified;
        //    }
        //    set {
        //        this.availabilityFieldSpecified = value;
        //    }
        //}
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public bool FeaturedProperty {
        //    get {
        //        return this.featuredPropertyField;
        //    }
        //    set {
        //        this.featuredPropertyField = value;
        //    }
        //}
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool FeaturedPropertySpecified {
        //    get {
        //        return this.featuredPropertyFieldSpecified;
        //    }
        //    set {
        //        this.featuredPropertyFieldSpecified = value;
        //    }
        //}
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public string Key {
        //    get {
        //        return this.keyField;
        //    }
        //    set {
        //        this.keyField = value;
        //    }
        //}
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public bool PreferredOption {
        //    get {
        //        return this.preferredOptionField;
        //    }
        //    set {
        //        this.preferredOptionField = value;
        //    }
        //}
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool PreferredOptionSpecified {
        //    get {
        //        return this.preferredOptionFieldSpecified;
        //    }
        //    set {
        //        this.preferredOptionFieldSpecified = value;
        //    }
        //}
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public bool MoreRates {
        //    get {
        //        return this.moreRatesField;
        //    }
        //    set {
        //        this.moreRatesField = value;
        //    }
        //}
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool MoreRatesSpecified {
        //    get {
        //        return this.moreRatesFieldSpecified;
        //    }
        //    set {
        //        this.moreRatesFieldSpecified = value;
        //    }
        //}
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //public typeNetTransCommission NetTransCommissionInd {
        //    get {
        //        return this.netTransCommissionIndField;
        //    }
        //    set {
        //        this.netTransCommissionIndField = value;
        //    }
        //}
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlIgnoreAttribute()]
        //public bool NetTransCommissionIndSpecified {
        //    get {
        //        return this.netTransCommissionIndFieldSpecified;
        //    }
        //    set {
        //        this.netTransCommissionIndFieldSpecified = value;
        //    }
        //}
        #endregion
    }
    #endregion


    #region RateInfo Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    [System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.travelport.com/schema/hotel_v29_0")]
    public partial class RateInfo : object {
        
        private string minimumAmountField;        
        private string approximateMinimumAmountField;        
        private bool minAmountRateChangedField;        
        private bool minAmountRateChangedFieldSpecified;        
        private string maximumAmountField;        
        private string approximateMaximumAmountField;        
        private bool maxAmountRateChangedField;        
        private bool maxAmountRateChangedFieldSpecified;        
        private string minimumStayAmountField;        
        private string approximateMinimumStayAmountField;        
        private string approximateAverageMinimumAmountField;
        private string commissionField;        
        private string rateSupplierField;
        private string rateSupplierLogoField;
        private typeHotelPaymentType paymentTypeField;        
        private bool paymentTypeFieldSpecified;        
        private bool minInPolicyField;       
        private bool minInPolicyFieldSpecified;        
        private int minPolicyCodeField;        
        private bool minPolicyCodeFieldSpecified;        
        private bool maxInPolicyField;        
        private bool maxInPolicyFieldSpecified;        
        private int maxPolicyCodeField;        
        private bool maxPolicyCodeFieldSpecified;
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MinimumAmount {
            get {
                return this.minimumAmountField;
            }
            set {
                this.minimumAmountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ApproximateMinimumAmount {
            get {
                return this.approximateMinimumAmountField;
            }
            set {
                this.approximateMinimumAmountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool MinAmountRateChanged {
            get {
                return this.minAmountRateChangedField;
            }
            set {
                this.minAmountRateChangedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinAmountRateChangedSpecified {
            get {
                return this.minAmountRateChangedFieldSpecified;
            }
            set {
                this.minAmountRateChangedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MaximumAmount {
            get {
                return this.maximumAmountField;
            }
            set {
                this.maximumAmountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ApproximateMaximumAmount {
            get {
                return this.approximateMaximumAmountField;
            }
            set {
                this.approximateMaximumAmountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool MaxAmountRateChanged {
            get {
                return this.maxAmountRateChangedField;
            }
            set {
                this.maxAmountRateChangedField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaxAmountRateChangedSpecified {
            get {
                return this.maxAmountRateChangedFieldSpecified;
            }
            set {
                this.maxAmountRateChangedFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string MinimumStayAmount {
            get {
                return this.minimumStayAmountField;
            }
            set {
                this.minimumStayAmountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ApproximateMinimumStayAmount {
            get {
                return this.approximateMinimumStayAmountField;
            }
            set {
                this.approximateMinimumStayAmountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string ApproximateAverageMinimumAmount {
            get {
                return this.approximateAverageMinimumAmountField;
            }
            set {
                this.approximateAverageMinimumAmountField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Commission {
            get {
                return this.commissionField;
            }
            set {
                this.commissionField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string RateSupplier {
            get {
                return this.rateSupplierField;
            }
            set {
                this.rateSupplierField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute(DataType="anyURI")]
        public string RateSupplierLogo {
            get {
                return this.rateSupplierLogoField;
            }
            set {
                this.rateSupplierLogoField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public typeHotelPaymentType PaymentType {
            get {
                return this.paymentTypeField;
            }
            set {
                this.paymentTypeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool PaymentTypeSpecified {
            get {
                return this.paymentTypeFieldSpecified;
            }
            set {
                this.paymentTypeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool MinInPolicy {
            get {
                return this.minInPolicyField;
            }
            set {
                this.minInPolicyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinInPolicySpecified {
            get {
                return this.minInPolicyFieldSpecified;
            }
            set {
                this.minInPolicyFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int MinPolicyCode {
            get {
                return this.minPolicyCodeField;
            }
            set {
                this.minPolicyCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MinPolicyCodeSpecified {
            get {
                return this.minPolicyCodeFieldSpecified;
            }
            set {
                this.minPolicyCodeFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool MaxInPolicy {
            get {
                return this.maxInPolicyField;
            }
            set {
                this.maxInPolicyField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaxInPolicySpecified {
            get {
                return this.maxInPolicyFieldSpecified;
            }
            set {
                this.maxInPolicyFieldSpecified = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public int MaxPolicyCode {
            get {
                return this.maxPolicyCodeField;
            }
            set {
                this.maxPolicyCodeField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool MaxPolicyCodeSpecified {
            get {
                return this.maxPolicyCodeFieldSpecified;
            }
            set {
                this.maxPolicyCodeFieldSpecified = value;
            }
        }
        
    }
    #endregion


    #region Distance Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.travelport.com/schema/common_v29_0")]
    public partial class Distance : object {
        
        private DistanceUnits unitsField;
        private string valueField;
        private string directionField;
        
        public Distance() {
            this.unitsField = DistanceUnits.MI;
        }
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute()]
        //[System.ComponentModel.DefaultValueAttribute(DistanceUnits.MI)]
        public DistanceUnits Units {
            get {
                return this.unitsField;
            }
            set {
                this.unitsField = value;
            }
        }
        
        /// <remarks/>
        //[System.Xml.Serialization.XmlAttributeAttribute(DataType="integer")]
        public string Value {
            get {
                return this.valueField;
            }
            set {
                this.valueField = value;
            }
        }
        
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string Direction {
            get {
                return this.directionField;
            }
            set {
                this.directionField = value;
            }
        }
    }

    #region DistanceUnits Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.travelport.com/schema/common_v29_0")]
    public enum DistanceUnits {
        
        /// <remarks/>
        MI,
        
        /// <remarks/>
        KM,
    }
    #endregion 
    #endregion


    #region Amenities Class
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class Amenities : object
    {
        private List<Amenity> amenityListField = new List<Amenity>();

        [System.Xml.Serialization.XmlElementAttribute("Amenity", typeof(Amenity), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<Amenity> Amenity
        {
            get
            {
                return this.amenityListField;
            }
            set
            {
                this.amenityListField = value;
            }
        }
    }

    #region Amenity Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType=true, Namespace="http://www.travelport.com/schema/hotel_v29_0")]
    public partial class Amenity : object
    {

        private string codeField;

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

    }
    #endregion
    #endregion


    #region ReserveRequirement Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.travelport.com/schema/common_v29_0")]
    public enum typeReserveRequirement {
        
        /// <remarks/>
        Deposit,
        
        /// <remarks/>
        Guarantee,
        
        /// <remarks/>
        Other,
    }
    #endregion


    #region HotelAvailability Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    //[System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.travelport.com/schema/hotel_v29_0")]
    public enum typeHotelAvailability {
        
        /// <remarks/>
        Available,
        
        /// <remarks/>
        NotAvailable,
        
        /// <remarks/>
        AvailableForOtherRates,
        
        /// <remarks/>
        OnRequest,
        
        /// <remarks/>
        Unknown,
    }
    #endregion


    #region HotelPaymentType Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Xml.Serialization.XmlTypeAttribute(Namespace="http://www.travelport.com/schema/hotel_v29_0")]
    public enum typeHotelPaymentType {
        
        /// <remarks/>
        PrePay,
        
        /// <remarks/>
        PostPay,
    }
    #endregion
}
