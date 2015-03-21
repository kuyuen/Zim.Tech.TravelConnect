using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Zim.Tech.TravelLiker.Flight
{
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v25_0")]
    public class RouteList : object
    {
        private Route routeListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlElementAttribute("Route", typeof(Route), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public Route Route
        {
            get
            {
                return this.routeListField;
            }
            set
            {
                this.routeListField = value;
            }
        }

    }

    #region Route Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v25_0")]
    public partial class Route : object
    {
        private string keyField;
        private List<RouteLeg> legField = new List<RouteLeg>();

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
        [System.Xml.Serialization.XmlElementAttribute("Leg", typeof(RouteLeg), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<RouteLeg> Leg
        {
            get
            {
                return this.legField;
            }
            set
            {
                this.legField = value;
            }
        }

    }
    #endregion


    #region RouteLeg Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v25_0")]
    public partial class RouteLeg : object
    {
        private string keyField;
        private int groupField;
        private string originField;
        private string destinationField;

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

    }
    #endregion
}
