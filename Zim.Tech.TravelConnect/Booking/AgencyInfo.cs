using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml.Serialization;
using System.Reflection;

namespace Zim.Tech.TravelConnect.Booking
{
    #region AgencyInfo Class
    /// <remarks/>
    [System.CodeDom.Compiler.GeneratedCodeAttribute("System.Xml", "4.0.30319.34230")]
    [System.SerializableAttribute()]
    [System.Diagnostics.DebuggerStepThroughAttribute()]
    [System.ComponentModel.DesignerCategoryAttribute("code")]
    public partial class AgencyInfo : object
    {
        private List<AgentAction> agentActionListField = new List<AgentAction>();

        [System.Xml.Serialization.XmlElementAttribute("AgentAction", typeof(AgentAction), Form = System.Xml.Schema.XmlSchemaForm.Unqualified)]
        public List<AgentAction> AgentAction
        {
            get
            {
                return this.agentActionListField;
            }
            set
            {
                this.agentActionListField = value;
            }
        }
    }

    public partial class AgentAction : object
    {

        private string agentCodeField;
        private string branchCodeField;
        private string agencyCodeField;
        private string agentSineField;
        private System.DateTime eventTimeField;


        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AgentCode
        {
            get
            {
                return this.agentCodeField;
            }
            set
            {
                this.agentCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string BranchCode
        {
            get
            {
                return this.branchCodeField;
            }
            set
            {
                this.branchCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AgencyCode
        {
            get
            {
                return this.agencyCodeField;
            }
            set
            {
                this.agencyCodeField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public string AgentSine
        {
            get
            {
                return this.agentSineField;
            }
            set
            {
                this.agentSineField = value;
            }
        }

        /// <remarks/>
        [System.Xml.Serialization.XmlAttributeAttribute()]
        public System.DateTime EventTime
        {
            get
            {
                return this.eventTimeField;
            }
            set
            {
                this.eventTimeField = value;
            }
        }

    }

    #endregion
}
