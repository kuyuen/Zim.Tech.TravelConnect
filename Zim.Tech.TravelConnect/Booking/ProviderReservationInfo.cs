using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;

namespace Zim.Tech.TravelConnect.Booking
{
    #region ProviderReservationInfo Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class ProviderReservationInfo : object
    {
        #region ProviderReservationInfo private Attribute
        private string keyField;
        private string providerCodeField;
        private string locatorCodeField;
        private System.DateTime createDateField;
        private System.DateTime hostCreateDateField;
        private bool hostCreateDateFieldSpecified;
        private System.DateTime modifiedDateField;
        private bool importedField;
        private bool importedFieldSpecified;
        private string ticketingModifiersRefField;
        private bool inQueueModeField;
        private bool inQueueModeFieldSpecified;
        private string groupRefField;
        private bool elStatFieldSpecified;
        private bool keyOverrideField;
        private bool keyOverrideFieldSpecified;
        private string owningPCCField;
        #endregion

        #region ProviderReservationInfo public Attribute
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
        public System.DateTime CreateDate
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
        [System.Xml.Serialization.XmlAttributeAttribute(DataType = "date")]
        public System.DateTime HostCreateDate
        {
            get
            {
                return this.hostCreateDateField;
            }
            set
            {
                this.hostCreateDateField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool HostCreateDateSpecified
        {
            get
            {
                return this.hostCreateDateFieldSpecified;
            }
            set
            {
                this.hostCreateDateFieldSpecified = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime ModifiedDate
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

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool Imported
        {
            get
            {
                return this.importedField;
            }
            set
            {
                this.importedField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool ImportedSpecified
        {
            get
            {
                return this.importedFieldSpecified;
            }
            set
            {
                this.importedFieldSpecified = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string TicketingModifiersRef
        {
            get
            {
                return this.ticketingModifiersRefField;
            }
            set
            {
                this.ticketingModifiersRefField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public bool InQueueMode
        {
            get
            {
                return this.inQueueModeField;
            }
            set
            {
                this.inQueueModeField = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlIgnoreAttribute()]
        public bool InQueueModeSpecified
        {
            get
            {
                return this.inQueueModeFieldSpecified;
            }
            set
            {
                this.inQueueModeFieldSpecified = value;

            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string GroupRef
        {
            get
            {
                return this.groupRefField;
            }
            set
            {
                this.groupRefField = value;

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
        public string OwningPCC
        {
            get
            {
                return this.owningPCCField;
            }
            set
            {
                this.owningPCCField = value;

            }
        }

        #endregion
    }

    #endregion
}

