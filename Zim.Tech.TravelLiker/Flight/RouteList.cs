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
        private typeRoute routeListField;

        /// <remarks/>
        [System.Xml.Serialization.XmlArrayAttribute()]
        public typeRoute Route
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

        /// <remarks/>
        [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
        [System.SerializableAttribute()]
        [System.Diagnostics.DebuggerStepThroughAttribute()]
        [System.ComponentModel.DesignerCategoryAttribute("code")]
        //[System.Xml.Serialization.XmlTypeAttribute(AnonymousType = true, Namespace = "http://www.travelport.com/schema/air_v25_0")]
        public partial class typeRoute : object
        {

            //private typeLeg[] legField;

            private string keyField;

            /// <remarks/>
            //[System.Xml.Serialization.XmlElementAttribute("Leg")]
            //public typeLeg[] Leg
            //{
            //    get
            //    {
            //        return this.legField;
            //    }
            //    set
            //    {
            //        this.legField = value;
            //    }
            //}

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
        public partial class typeLeg : object
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
    }
}
