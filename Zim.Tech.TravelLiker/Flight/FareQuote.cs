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

        #region Constructors
        public FareQuote()
        {
            //FareQuteType = FareType.OneWay;
            //m_RulesInfo = new List<RulesInfo>();
            //m_ChildRulesInfo = new List<RulesInfo>();
            //m_InfantWOSRulesInfo = new List<RulesInfo>();
            //m_FlightFare = new FareInfo();
            //m_ChildFlightFare = new FareInfo();
            //m_InfantWOSFlightFare = new FareInfo();
            ////Dictionary<string, FlightInfo> m_AvailFlight = new Dictionary<string, FlightInfo>();
            ////AvailFlight = (Dictionary<string, FlightInfo>)m_AvailFlight;
            //List<Dictionary<string, FlightInfo>> m_AvailFlight = new List<Dictionary<string, FlightInfo>>();
            //AvailFlight = (List<Dictionary<string, FlightInfo>>)m_AvailFlight;
        }

        //public FareQuote(FareType m_FareType)
        //{
        //    //m_RulesInfo = new List<RulesInfo>();
        //    //m_ChildRulesInfo = new List<RulesInfo>();
        //    //m_InfantWOSRulesInfo = new List<RulesInfo>();
        //    //m_FlightFare = new FareInfo();
        //    //m_ChildFlightFare = new FareInfo();
        //    //m_InfantWOSFlightFare = new FareInfo();
        //    //if (m_FareType == FareType.OneWay)
        //    //{
        //    //    FareQuteType = FareType.OneWay;
        //    //    //Dictionary<string, FlightInfo> m_AvailFlight = new Dictionary<string, FlightInfo>();
        //    //    //AvailFlight = (Dictionary<string, FlightInfo>)m_AvailFlight;
        //    //    List<Dictionary<string, FlightInfo>> m_AvailFlight = new List<Dictionary<string, FlightInfo>>();
        //    //    AvailFlight = (List<Dictionary<string, FlightInfo>>)m_AvailFlight;
        //    //}
        //    //else // if (m_FareType == FareType.RoundTrip || m_FareType == FareType.MultStop)
        //    //{
        //    //    FareQuteType = m_FareType;
        //    //    List<Dictionary<string, FlightInfo>> m_AvailFlight = new List<Dictionary<string, FlightInfo>>();
        //    //    AvailFlight = (List<Dictionary<string, FlightInfo>>)m_AvailFlight;
        //    //}
        //}
        #endregion

        #region Properties Variables
        private string m_ServiceProvide = string.Empty;
        //private FareInfo m_FlightFare = new FareInfo();
        //private FareInfo m_ChildFlightFare = new FareInfo();
        //private FareInfo m_InfantWOSFlightFare = new FareInfo();
        //private List<RulesInfo> m_RulesInfo = new List<RulesInfo>();
        //private List<RulesInfo> m_ChildRulesInfo = new List<RulesInfo>();
        //private List<RulesInfo> m_InfantWOSRulesInfo = new List<RulesInfo>();

        private int _itemIdx = -1;

        //private object m_AvailFlight = new object();
        //private List<Dictionary<string, FlightInfo>> m_AvailFlight = new List<Dictionary<string, FlightInfo>>();
        #endregion

        #region Public Properties
        //public string ServiceProvide { get { return m_ServiceProvide; } set { m_ServiceProvide = value; } } // Service Provide = Galileo / Nanhwa
        //public enum FareType { OneWay = 1, RoundTrip = 2, MultStop = 3 }
        //public FareType FareQuteType = FareType.OneWay;
        //public List<RulesInfo> RulesInfo { get { return m_RulesInfo; } set { m_RulesInfo = value; } }
        //public List<RulesInfo> ChildRulesInfo { get { return m_ChildRulesInfo; } set { m_ChildRulesInfo = value; } }
        //public List<RulesInfo> InfantWOSRulesInfo { get { return m_InfantWOSRulesInfo; } set { m_InfantWOSRulesInfo = value; } }
        //public FareInfo FlightFare { get { return m_FlightFare; } set { m_FlightFare = value; } }
        //public FareInfo ChildFlightFare { get { return m_ChildFlightFare; } set { m_ChildFlightFare = value; } }
        //public FareInfo InfantWOSFlightFare { get { return m_InfantWOSFlightFare; } set { m_InfantWOSFlightFare = value; } }
        ////public object AvailFlight { get { return m_AvailFlight; } set { m_AvailFlight = value; } }
        //public List<Dictionary<string, FlightInfo>> AvailFlight { get { return m_AvailFlight; } set { m_AvailFlight = value; } }
        //public List<List<FlightInfo>> AvailFlightList
        //{
        //    get
        //    {
        //        List<List<FlightInfo>> tempFlightList = new List<List<FlightInfo>>();
        //        foreach (Dictionary<string, FlightInfo> tempFlightInfo in m_AvailFlight)
        //            tempFlightList.Add(tempFlightInfo.Values.ToList<FlightInfo>());
        //        return tempFlightList;
        //    }
        //}
        //public List<FlightInfo> FromFlightList { get { return (m_AvailFlight.Count > 0) ? m_AvailFlight[0].Values.ToList<FlightInfo>() : new List<FlightInfo>(); } }
        //public List<FlightInfo> ToFlightList { get { return ((m_AvailFlight.Count >= 2) ? m_AvailFlight[1].Values.ToList<FlightInfo>() : null); } }

        //public int ItemIdx { get { return _itemIdx; } set { _itemIdx = value; } }
        #endregion


        public class AirPricingSolution : Flight.AirPricingSolution
        {

            public AirPricingSolution(Flight.AirPricingSolution oAirPricingSolution)
            {
                foreach (FieldInfo prop in oAirPricingSolution.GetType().GetFields())
                    GetType().GetField(prop.Name).SetValue(this, prop.GetValue(oAirPricingSolution));
            }

            private List<RouteLeg> routeLegListField = new List<RouteLeg>();
            private List<Journey> journeyListField;

            public List<RouteLeg> RouteLegList
            {
                get
                {
                    return this.routeLegListField;
                }
                set
                {
                    this.routeLegListField = value;
                }
            }

            public List<Journey> JourneyList
            {
                get
                {
                    return this.journeyListField;
                }
                set
                {
                    this.journeyListField = value;
                }
            }

            public class Journey : Flight.Journey
            {
                private AirSegment airSegmentField;
                public AirSegment AirSegment
                {
                    get
                    {
                        return this.airSegmentField;
                    }
                    set
                    {
                        this.airSegmentField = value;
                    }
                }
            }

            public class BookingInfo : Flight.BookingInfo
            {
                private FareInfo fareInfoField;
                public FareInfo FareInfo
                {
                    get
                    {
                        return this.fareInfoField;
                    }
                    set
                    {
                        this.fareInfoField = value;
                    }
                }

                private AirSegment airSegmentField;
                public AirSegment AirSegment
                {
                    get
                    {
                        return this.airSegmentField;
                    }
                    set
                    {
                        this.airSegmentField = value;
                    }
                }
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
    }

    public class RulesInfo
    { }
}
