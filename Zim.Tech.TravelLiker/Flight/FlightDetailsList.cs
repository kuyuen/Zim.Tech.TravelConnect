using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;

namespace Zim.Tech.TravelLiker.Flight
{    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class FlightDetailsList : object
    {
        private List<FlightDetails> flightDetailsListField = new List<FlightDetails>();

        [System.Xml.Serialization.XmlElementAttribute("FlightDetails", typeof(FlightDetails), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<FlightDetails> FlightDetails
        {
            get
            {
                return this.flightDetailsListField;
            }
            set
            {
                this.flightDetailsListField = value;
            }
        }
    }

    #region FlightDetails Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v29_0")]
    public partial class FlightDetails : object
    {
        #region FlightDetails private properties
        private string keyField;
        private string originField;
        private string destinationField;
        private string departureTimeField;
        private string arrivalTimeField;
        private string flightTimeField;
        private string travelTimeField;
        private string distanceField;
        private string equipmentField;
        private string onTimePerformanceField;
        private string originTerminalField;
        private string destinationTerminalField;
        private bool elStatFieldSpecified;
        private bool keyOverrideField;
        private bool keyOverrideFieldSpecified;
        #endregion

        #region FlightDetails public properties
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
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
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
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
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
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "integer")]
        public string OnTimePerformance
        {
            get
            {
                return this.onTimePerformanceField;
            }
            set
            {
                this.onTimePerformanceField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string OriginTerminal
        {
            get
            {
                return this.originTerminalField;
            }
            set
            {
                this.originTerminalField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string DestinationTerminal
        {
            get
            {
                return this.destinationTerminalField;
            }
            set
            {
                this.destinationTerminalField = value;
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
}
