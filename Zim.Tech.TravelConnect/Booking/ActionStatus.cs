using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;

namespace Zim.Tech.TravelConnect.Booking
{
    #region ActionStatus Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ActionStatus : object
    {
        #region ActionStatus private Attribute
        private string ticketDateField;
        private string keyField;
        private string providerReservationInfoRefField;
        private string queueCategoryField;
        private string airportCodeField;
        private string providerCodeField;
        private string supplierCodeField;
        private string pseudoCityCodeField;
        private string accountCodeField;
        private string elStatField;
        private bool elStatFieldSpecified;
        private bool keyOverrideField;
        private bool keyOverrideFieldSpecified;
        #endregion


        #region ActionStatus public Attribute
        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TicketDate
        {
            get
            {
                return this.ticketDateField;
            }
            set
            {
                this.ticketDateField = value;

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
        public string QueueCategory
        {
            get
            {
                return this.queueCategoryField;
            }
            set
            {
                this.queueCategoryField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AirportCode
        {
            get
            {
                return this.airportCodeField;
            }
            set
            {
                this.airportCodeField = value;

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
        public string AccountCode
        {
            get
            {
                return this.accountCodeField;
            }
            set
            {
                this.accountCodeField = value;

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

}
