using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Reflection;
using Zim.Tech.TravelLiker.Common;

namespace Zim.Tech.TravelLiker.Flight
{
    public class FareQuote
    {

        #region Properties Variables
        private string m_ServiceProvide = string.Empty;
        private FareInfo m_FlightFare = new FareInfo();
        private FareInfo m_ChildFlightFare = new FareInfo();
        private FareInfo m_InfantWOSFlightFare = new FareInfo();
        private List<RulesInfo> m_RulesInfo = new List<RulesInfo>();
        private List<RulesInfo> m_ChildRulesInfo = new List<RulesInfo>();
        private List<RulesInfo> m_InfantWOSRulesInfo = new List<RulesInfo>();

        private int _itemIdx = -1;

        //private object m_AvailFlight = new object();
        private List<Dictionary<string, FlightInfo>> m_AvailFlight = new List<Dictionary<string, FlightInfo>>();
        #endregion

        #region Public Properties
        public string ServiceProvide { get { return m_ServiceProvide; } set { m_ServiceProvide = value; } } // Service Provide = Galileo / Nanhwa
        public enum FareType { OneWay = 1, RoundTrip = 2, MultStop = 3 }
        public FareType FareQuteType = FareType.OneWay;
        public List<RulesInfo> RulesInfo { get { return m_RulesInfo; } set { m_RulesInfo = value; } }
        public List<RulesInfo> ChildRulesInfo { get { return m_ChildRulesInfo; } set { m_ChildRulesInfo = value; } }
        public List<RulesInfo> InfantWOSRulesInfo { get { return m_InfantWOSRulesInfo; } set { m_InfantWOSRulesInfo = value; } }
        public FareInfo FlightFare { get { return m_FlightFare; } set { m_FlightFare = value; } }
        public FareInfo ChildFlightFare { get { return m_ChildFlightFare; } set { m_ChildFlightFare = value; } }
        public FareInfo InfantWOSFlightFare { get { return m_InfantWOSFlightFare; } set { m_InfantWOSFlightFare = value; } }
        //public object AvailFlight { get { return m_AvailFlight; } set { m_AvailFlight = value; } }
        public List<Dictionary<string, FlightInfo>> AvailFlight { get { return m_AvailFlight; } set { m_AvailFlight = value; } }
        public List<List<FlightInfo>> AvailFlightList
        {
            get
            {
                List<List<FlightInfo>> tempFlightList = new List<List<FlightInfo>>();
                foreach (Dictionary<string, FlightInfo> tempFlightInfo in m_AvailFlight)
                    tempFlightList.Add(tempFlightInfo.Values.ToList<FlightInfo>());
                return tempFlightList;
            }
        }
        public List<FlightInfo> FromFlightList { get { return (m_AvailFlight.Count > 0) ? m_AvailFlight[0].Values.ToList<FlightInfo>() : new List<FlightInfo>(); } }
        public List<FlightInfo> ToFlightList { get { return ((m_AvailFlight.Count >= 2) ? m_AvailFlight[1].Values.ToList<FlightInfo>() : null); } }

        public int ItemIdx { get { return _itemIdx; } set { _itemIdx = value; } }
        #endregion

        #region Constructors
        public FareQuote()
        {
            FareQuteType = FareType.OneWay;
            m_RulesInfo = new List<RulesInfo>();
            m_ChildRulesInfo = new List<RulesInfo>();
            m_InfantWOSRulesInfo = new List<RulesInfo>();
            m_FlightFare = new FareInfo();
            m_ChildFlightFare = new FareInfo();
            m_InfantWOSFlightFare = new FareInfo();
            //Dictionary<string, FlightInfo> m_AvailFlight = new Dictionary<string, FlightInfo>();
            //AvailFlight = (Dictionary<string, FlightInfo>)m_AvailFlight;
            List<Dictionary<string, FlightInfo>> m_AvailFlight = new List<Dictionary<string, FlightInfo>>();
            AvailFlight = (List<Dictionary<string, FlightInfo>>)m_AvailFlight;
        }

        public FareQuote(FareType m_FareType)
        {
            m_RulesInfo = new List<RulesInfo>();
            m_ChildRulesInfo = new List<RulesInfo>();
            m_InfantWOSRulesInfo = new List<RulesInfo>();
            m_FlightFare = new FareInfo();
            m_ChildFlightFare = new FareInfo();
            m_InfantWOSFlightFare = new FareInfo();
            if (m_FareType == FareType.OneWay)
            {
                FareQuteType = FareType.OneWay;
                //Dictionary<string, FlightInfo> m_AvailFlight = new Dictionary<string, FlightInfo>();
                //AvailFlight = (Dictionary<string, FlightInfo>)m_AvailFlight;
                List<Dictionary<string, FlightInfo>> m_AvailFlight = new List<Dictionary<string, FlightInfo>>();
                AvailFlight = (List<Dictionary<string, FlightInfo>>)m_AvailFlight;
            }
            else // if (m_FareType == FareType.RoundTrip || m_FareType == FareType.MultStop)
            {
                FareQuteType = m_FareType;
                List<Dictionary<string, FlightInfo>> m_AvailFlight = new List<Dictionary<string, FlightInfo>>();
                AvailFlight = (List<Dictionary<string, FlightInfo>>)m_AvailFlight;
            }
        }
        #endregion

        public string GetValue(string m_Name)
        {
            PropertyInfo info = this.GetType().GetProperty(m_Name);
            if (info != null)
            {
                object val = info.GetValue(this, null);
                return (string)val;
            }
            else
            {
                return string.Empty;
            }
        }


        public class SearchInfo
        {
            #region Constructors
            public SearchInfo()
            {
            }
            #endregion

            #region Properties Variables
            private string m_FromCity = string.Empty;
            private string m_ToCity = string.Empty;
            private string m_FrightDate = string.Empty;
            private int m_Adults = 0;
            private int m_Children = 0;
            private int m_InfantWOS = 0;
            private bool m_DirectFlightOnly = false;
            private string m_FrightClass = string.Empty;
            private string m_SpecifiedAirline = string.Empty;
            #endregion

            #region Public Properties
            public string FromCity { get { return m_FromCity; } set { m_FromCity = value; } }
            public string ToCity { get { return m_ToCity; } set { m_ToCity = value; } }
            public string StartDate { get { return m_FrightDate; } set { m_FrightDate = value; } }
            public DateTime FrightDate { get { return DateTime.ParseExact(m_FrightDate, Variables.DATE_FORMAT, null); } set { m_FrightDate = value.ToString(Variables.DATE_FORMAT); } }
            public int Adults { get { return m_Adults; } set { m_Adults = value; } }
            public int Children { get { return m_Children; } set { m_Children = value; } }
            public int InfantWOS { get { return m_InfantWOS; } set { m_InfantWOS = value; } }
            public string FrightClass { get { return m_FrightClass; } set { m_FrightClass = value; } }
            public string SpecifiedAirline { get { return m_SpecifiedAirline; } set { m_SpecifiedAirline = value; } }
            public int TotalSeats { get { return (m_Adults + m_Children); } }
            public bool DirectFlightOnly { get { return m_DirectFlightOnly; } set { m_DirectFlightOnly = value; } }
            public string DirectFlight { get { return (m_DirectFlightOnly == true) ? Variables.YES : Variables.NO; } }
            #endregion
        }

        public class FareInfo
        {
            public FareInfo() { }

            public string GetValue(string m_Name)
            {
                PropertyInfo info = this.GetType().GetProperty(m_Name);
                if (info != null)
                {
                    object val = info.GetValue(this, null);
                    return (string)val;
                }
                else
                {
                    return string.Empty;
                }
            }

            public void SetValue(string m_Name, object m_Value)
            {
                PropertyInfo info = this.GetType().GetProperty(m_Name);
                if (info != null)
                {
                    info.SetValue(this, m_Value, null);
                }
            }


            #region Properties Variables
            private string m_UniqueKey = string.Empty;             // UniqueKey
            private string m_QuoteNum = string.Empty;             // QuoteNum
            private string m_QuoteType = string.Empty;             // QuoteType
            private string m_LastTkDt = string.Empty;             // LastTkDt
            private string m_QuoteDt = string.Empty;             // QuoteDt
            private string m_IntlSaleInd = string.Empty;             // IntlSaleInd
            private string m_BaseFareCurrency = string.Empty;             // BaseFareCurrency
            private string m_BaseFareAmt = string.Empty;             // BaseFareAmt
            private string m_LowestOrNUCFare = string.Empty;             // LowestOrNUCFare
            private string m_BaseDecPos = string.Empty;             // BaseDecPos
            private string m_EquivCurrency = string.Empty;             // EquivCurrency
            private string m_EquivAmt = string.Empty;             // EquivAmt
            private string m_EquivDecPos = string.Empty;             // EquivDecPos
            private string m_TotCurrency = string.Empty;             // TotCurrency
            private string m_TotAmt = string.Empty;             // TotAmt
            private string m_TotDecPos = string.Empty;             // TotDecPos
            private string m_ITNum = string.Empty;             // ITNum
            private string m_RteBasedQuote = string.Empty;             // RteBasedQuote
            private string m_M0 = string.Empty;             // M0
            private string m_M5 = string.Empty;             // M5
            private string m_M10 = string.Empty;             // M10
            private string m_M15 = string.Empty;             // M15
            private string m_M20 = string.Empty;             // M20
            private string m_M25 = string.Empty;             // M25
            private string m_Spare1 = string.Empty;             // Spare1
            private string m_PrivFQd = string.Empty;             // PrivFQd
            private string m_PFOverrides = string.Empty;             // PFOverrides
            private string m_FlatFQd = string.Empty;             // FlatFQd
            private string m_DirMinApplied = string.Empty;             // DirMinApplied
            private string m_VATIncInd = string.Empty;             // VATIncInd
            private string m_PenApplies = string.Empty;             // PenApplies
            private string m_Spare2 = string.Empty;             // Spare2
            private string m_QuoteBasis = string.Empty;             // QuoteBasis
            private List<TaxData> m_TaxDataAry = new List<TaxData>();             // TaxDataAry

            private int m_MarkupFareAmt = 0;             //  Markup FareAmt
            private string m_MarkupFareFormula = string.Empty;             // m_Markup FareFormula
            #endregion

            #region Public Properties
            public string UniqueKey { get { return m_UniqueKey; } set { m_UniqueKey = value; } }
            public string QuoteNum { get { return m_QuoteNum; } set { m_QuoteNum = value; } }
            public string QuoteType { get { return m_QuoteType; } set { m_QuoteType = value; } }
            public string LastTkDt { get { return m_LastTkDt; } set { m_LastTkDt = value; } }
            public string QuoteDt { get { return m_QuoteDt; } set { m_QuoteDt = value; } }
            public string IntlSaleInd { get { return m_IntlSaleInd; } set { m_IntlSaleInd = value; } }
            public string BaseFareCurrency { get { return m_BaseFareCurrency; } set { m_BaseFareCurrency = value; } }
            public string BaseFareAmt { get { return m_BaseFareAmt; } set { m_BaseFareAmt = value; } }
            public string LowestOrNUCFare { get { return m_LowestOrNUCFare; } set { m_LowestOrNUCFare = value; } }
            public string BaseDecPos { get { return m_BaseDecPos; } set { m_BaseDecPos = value; } }
            public string EquivCurrency { get { return m_EquivCurrency; } set { m_EquivCurrency = value; } }
            public string EquivAmt { get { return m_EquivAmt; } set { m_EquivAmt = value; } }
            public string EquivDecPos { get { return m_EquivDecPos; } set { m_EquivDecPos = value; } }
            public string TotCurrency { get { return m_TotCurrency; } set { m_TotCurrency = value; } }
            public string TotAmt { get { return m_TotAmt; } set { m_TotAmt = value; } }
            public string TotDecPos { get { return m_TotDecPos; } set { m_TotDecPos = value; } }
            public string ITNum { get { return m_ITNum; } set { m_ITNum = value; } }
            public string RteBasedQuote { get { return m_RteBasedQuote; } set { m_RteBasedQuote = value; } }
            public string M0 { get { return m_M0; } set { m_M0 = value; } }
            public string M5 { get { return m_M5; } set { m_M5 = value; } }
            public string M10 { get { return m_M10; } set { m_M10 = value; } }
            public string M15 { get { return m_M15; } set { m_M15 = value; } }
            public string M20 { get { return m_M20; } set { m_M20 = value; } }
            public string M25 { get { return m_M25; } set { m_M25 = value; } }
            public string Spare1 { get { return m_Spare1; } set { m_Spare1 = value; } }
            public string PrivFQd { get { return m_PrivFQd; } set { m_PrivFQd = value; } }
            public string PFOverrides { get { return m_PFOverrides; } set { m_PFOverrides = value; } }
            public string FlatFQd { get { return m_FlatFQd; } set { m_FlatFQd = value; } }
            public string DirMinApplied { get { return m_DirMinApplied; } set { m_DirMinApplied = value; } }
            public string VATIncInd { get { return m_VATIncInd; } set { m_VATIncInd = value; } }
            public string PenApplies { get { return m_PenApplies; } set { m_PenApplies = value; } }
            public string Spare2 { get { return m_Spare2; } set { m_Spare2 = value; } }
            public string QuoteBasis { get { return m_QuoteBasis; } set { m_QuoteBasis = value; } }
            public List<TaxData> TaxDataAry { get { return m_TaxDataAry; } set { m_TaxDataAry = value; } }

            public int BaseFareAmount { get { return Convert.ToInt32(m_BaseFareAmt); } }

            public int MarkupFareAmount { get { return m_MarkupFareAmt; } set { m_MarkupFareAmt = value; } }
            public string MarkupFareFormula { get { return m_MarkupFareFormula; } set { m_MarkupFareFormula = value; } }

            public int TotalAmount { get { return Convert.ToInt32(m_TotAmt); } }
            public int TotalTaxAmt
            {
                get
                {
                    if (m_TaxDataAry.Count == 0)
                        return 0;
                    else
                    {
                        int m_TotalTaxAmt = 0;
                        foreach (TaxData taxData in TaxDataAry)
                            m_TotalTaxAmt += taxData.Amount;
                        return m_TotalTaxAmt;
                    }
                }
            }
            #endregion

            [Serializable]
            [XmlRoot("TaxData")]
            public class TaxData
            {
                public TaxData() { }

                public string GetValue(string m_Name)
                {
                    PropertyInfo info = this.GetType().GetProperty(m_Name);
                    if (info != null)
                    {
                        object val = info.GetValue(this, null);
                        return (string)val;
                    }
                    else
                    {
                        return string.Empty;
                    }
                }

                #region Properties Variables
                private string m_Country = string.Empty;         // Country
                private int m_Amount = 0;                        // Amount
                #endregion

                #region Public Properties
                public string Country { get { return m_Country; } set { m_Country = value; } }
                public int Amount { get { return m_Amount; } set { m_Amount = value; } }
                #endregion
            }

        }

        public class FlightInfo
        {
            public FlightInfo() { }

            public string GetValue(string m_Name)
            {
                PropertyInfo info = this.GetType().GetProperty(m_Name);
                if (info != null)
                {
                    object val = info.GetValue(this, null);
                    return (string)val;
                }
                else
                {
                    return string.Empty;
                }
            }

            public void SetValue(string m_Name, object m_Value)
            {
                PropertyInfo info = this.GetType().GetProperty(m_Name);
                if (info != null)
                {
                    info.SetValue(this, (string)m_Value, null);
                }
            }

            #region Properties Variables
            #region AvailFlt Properties Variables
            private string m_AirV = string.Empty;             // AirV
            private string m_FltNum = string.Empty;             // FltNum
            private string m_OpSuf = string.Empty;             // OpSuf
            private string m_StartDt = string.Empty;             // StartDt
            private string m_StartAirp = string.Empty;             // StartAirp
            private string m_EndAirp = string.Empty;             // EndAirp
            private string m_StartTm = string.Empty;             // StartTm
            private string m_EndTm = string.Empty;             // EndTm
            private string m_DayChg = string.Empty;             // DayChg
            private string m_Conx = string.Empty;             // Conx
            private string m_AirpChg = string.Empty;             // AirpChg
            private string m_Equip = string.Empty;             // Equip
            private string m_Spare1 = string.Empty;             // Spare1
            private string m_NumStops = string.Empty;             // NumStops
            private string m_OpAirVInd = string.Empty;             // OpAirVInd
            private string m_Perf = string.Empty;             // Perf
            private string m_LinkSellAgrmnt = string.Empty;             // LinkSellAgrmnt
            private string m_DispOption = string.Empty;             // DispOption
            private string m_InsideAvailOption = string.Empty;             // InsideAvailOption
            private string m_GenTrafRestriction = string.Empty;             // GenTrafRestriction
            private string m_DaysOperates = string.Empty;             // DaysOperates
            private string m_JrnyTm = string.Empty;             // JrnyTm
            private string m_EndDt = string.Empty;             // EndDt
            private string m_OpAirV = string.Empty;             // OpAirV
            private string m_OpFltDesignator = string.Empty;             // OpFltDesignator
            private string m_OpFltSuf = string.Empty;             // OpFltSuf
            private string m_StartTerminal = string.Empty;             // StartTerminal
            private string m_EndTerminal = string.Empty;             // EndTerminal
            private string m_FltTm = string.Empty;             // FltTm
            private string m_LSAInd = string.Empty;             // LSAInd
            private string m_GalileoAirVInd = string.Empty;             // GalileoAirVInd
            private string m_ETktEligibility = string.Empty;             // ETktEligibility
            private string m_ScheduleLevelCarrier = string.Empty;             // ScheduleLevelCarrier
            private string m_FrstDwnlnStp = string.Empty;             // FrstDwnlnStp
            private string m_LastDwnlnStp = string.Empty;             // LastDwnlnStp
            private string m_SponsoredFltInd = string.Empty;             // SponsoredFltInd
            private string m_SponsoredFltLineNum = string.Empty;             // SponsoredFltLineNum
            private string m_NeutralFltLineNum = string.Empty;             // NeutralFltLineNum
            private string m_SponsoredFltKey = string.Empty;             // SponsoredFltKey
            private string m_AvailSource = string.Empty;             // AvailSource
            private string m_CodeShareSrc = string.Empty;             // CodeShareSrc
            private string m_AdditionalSrvcs = string.Empty;             // AdditionalSrvcs
            private string m_Airline = string.Empty;             // Airline
            private string m_StartCity = string.Empty;             // StartCity
            private string m_EndCity = string.Empty;             // EndCity
            private string m_StartAirport = string.Empty;             // StartAirport
            private string m_EndAirport = string.Empty;             // EndAirport
            #endregion

            #region FltAvailStatus Properties Variables
            private string m_Status = string.Empty;             // Status
            private string m_First = string.Empty;             // First
            private string m_Business = string.Empty;             // Business
            private string m_Coach = string.Empty;             // Coach
            private string m_MoreClasses = string.Empty;             // MoreClasses
            #endregion

            private string m_BIC = string.Empty;             // BIC
            #endregion

            #region Public Properties
            #region AvailFlt Public Properties
            public string Flight { get { return m_AirV + m_FltNum; } }
            public string AirV { get { return m_AirV; } set { m_AirV = value; } }
            public string FltNum { get { return m_FltNum; } set { m_FltNum = value; } }
            public string OpSuf { get { return m_OpSuf; } set { m_OpSuf = value; } }
            public string StartDt { get { return m_StartDt; } set { m_StartDt = value; } }
            public string StartAirp { get { return m_StartAirp; } set { m_StartAirp = value; } }
            public string EndAirp { get { return m_EndAirp; } set { m_EndAirp = value; } }
            public string StartTm { get { return m_StartTm; } set { m_StartTm = value; } }
            public string EndTm { get { return m_EndTm; } set { m_EndTm = value; } }
            public string DayChg { get { return m_DayChg; } set { m_DayChg = value; } }
            public string Conx { get { return m_Conx; } set { m_Conx = value; } }
            public string AirpChg { get { return m_AirpChg; } set { m_AirpChg = value; } }
            public string Equip { get { return m_Equip; } set { m_Equip = value; } }
            public string Spare1 { get { return m_Spare1; } set { m_Spare1 = value; } }
            public string NumStops { get { return m_NumStops; } set { m_NumStops = value; } }
            public string OpAirVInd { get { return m_OpAirVInd; } set { m_OpAirVInd = value; } }
            public string Perf { get { return m_Perf; } set { m_Perf = value; } }
            public string LinkSellAgrmnt { get { return m_LinkSellAgrmnt; } set { m_LinkSellAgrmnt = value; } }
            public string DispOption { get { return m_DispOption; } set { m_DispOption = value; } }
            public string InsideAvailOption { get { return m_InsideAvailOption; } set { m_InsideAvailOption = value; } }
            public string GenTrafRestriction { get { return m_GenTrafRestriction; } set { m_GenTrafRestriction = value; } }
            public string DaysOperates { get { return m_DaysOperates; } set { m_DaysOperates = value; } }
            public string JrnyTm { get { return m_JrnyTm; } set { m_JrnyTm = value; } }
            public string EndDt { get { return m_EndDt; } set { m_EndDt = value; } }
            public string OpAirV { get { return m_OpAirV; } set { m_OpAirV = value; } }
            public string OpFltDesignator { get { return m_OpFltDesignator; } set { m_OpFltDesignator = value; } }
            public string OpFltSuf { get { return m_OpFltSuf; } set { m_OpFltSuf = value; } }
            public string StartTerminal { get { return m_StartTerminal; } set { m_StartTerminal = value; } }
            public string EndTerminal { get { return m_EndTerminal; } set { m_EndTerminal = value; } }
            public string FltTm { get { return m_FltTm; } set { m_FltTm = value; } }
            public string LSAInd { get { return m_LSAInd; } set { m_LSAInd = value; } }
            public string GalileoAirVInd { get { return m_GalileoAirVInd; } set { m_GalileoAirVInd = value; } }
            public string ETktEligibility { get { return m_ETktEligibility; } set { m_ETktEligibility = value; } }
            public string ScheduleLevelCarrier { get { return m_ScheduleLevelCarrier; } set { m_ScheduleLevelCarrier = value; } }
            public string FrstDwnlnStp { get { return m_FrstDwnlnStp; } set { m_FrstDwnlnStp = value; } }
            public string LastDwnlnStp { get { return m_LastDwnlnStp; } set { m_LastDwnlnStp = value; } }
            public string SponsoredFltInd { get { return m_SponsoredFltInd; } set { m_SponsoredFltInd = value; } }
            public string SponsoredFltLineNum { get { return m_SponsoredFltLineNum; } set { m_SponsoredFltLineNum = value; } }
            public string NeutralFltLineNum { get { return m_NeutralFltLineNum; } set { m_NeutralFltLineNum = value; } }
            public string SponsoredFltKey { get { return m_SponsoredFltKey; } set { m_SponsoredFltKey = value; } }
            public string AvailSource { get { return m_AvailSource; } set { m_AvailSource = value; } }
            public string CodeShareSrc { get { return m_CodeShareSrc; } set { m_CodeShareSrc = value; } }
            public string AdditionalSrvcs { get { return m_AdditionalSrvcs; } set { m_AdditionalSrvcs = value; } }
            public string Airline { get { return m_Airline; } set { m_Airline = value; } }
            public string StartCity { get { return m_StartCity; } set { m_StartCity = value; } }
            public string EndCity { get { return m_EndCity; } set { m_EndCity = value; } }
            public string StartAirport { get { return (string.IsNullOrEmpty(m_StartAirport) == true) ? m_StartAirport : m_StartAirport.Replace("Arpt", "Airport").Replace("Intl", "International"); } set { m_StartAirport = value; } }
            public string EndAirport { get { return (string.IsNullOrEmpty(m_EndAirport) == true) ? m_EndAirport : m_EndAirport.Replace("Arpt", "Airport").Replace("Intl", "International"); } set { m_EndAirport = value; } }
            //public DateTime StartDateTime { get { return CommonUtility.getDateTime(m_StartDt + Convert.ToInt16(m_StartTm).ToString("0000")); } }
            //public DateTime EndDateTime { get { return CommonUtility.getDateTime(m_EndDt + Convert.ToInt16(m_EndTm).ToString("0000")); } }
            //public string Duration { get { return CommonUtility.convertMinutesToHoursMinutes(Convert.ToDouble(FltTm)); } }

            #endregion

            #region FltAvailStatus Public Properties
            public string Status { get { return m_Status; } set { m_Status = value; } }
            public string First { get { return m_First; } set { m_First = value; } }
            public string Business { get { return m_Business; } set { m_Business = value; } }
            public string Coach { get { return m_Coach; } set { m_Coach = value; } }
            public string MoreClasses { get { return m_MoreClasses; } set { m_MoreClasses = value; } }

            public bool FirstClass { get { return (m_First == "A"); } }
            public bool BusinessClass { get { return (m_Business == "A"); } }
            public bool EconomyClass { get { return (m_Coach == "A"); } }
            #endregion

            public string BIC { get { return m_BIC; } set { m_BIC = value; } }
            //public string BookingIndicatorCode { get { switch(m_BIC) { case "C" : return "Business Class"; case "Y" : return "Economy Class";  case "F" : return "First Class"; default: return m_BIC; }; } }

            #endregion
        }

    }

    public class RulesInfo
    { }
}
