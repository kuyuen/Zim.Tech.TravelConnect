﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;
using System.Reflection;

using Zim.Tech.TravelConnect.Flight;
using Zim.Tech.TravelConnect.Common;

namespace Zim.Tech.TravelConnect.Flight
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
        private List<FareQuote.AirPricingSolution> airPricingSolutionList = new List<FareQuote.AirPricingSolution>();
        private List<FareQuote.ErrorMessage> errorMessageList = new List<FareQuote.ErrorMessage>();
        #endregion

        #region Public Properties
        public enum FareType { OneWay = 1, RoundTrip = 2, MultStop = 3 }
        public List<FareQuote.AirPricingSolution> AirPricingSolutions { get { return airPricingSolutionList; } set { airPricingSolutionList = value; } }
        public List<FareQuote.ErrorMessage> ErrorMessages { get { return errorMessageList; } set { errorMessageList = value; } }

        public int RresultCount { get { return AirPricingSolutions.Count(); }}
        #endregion

        #region ErrorMessage
        public class ErrorMessage : Common.ResponseMessage
        {
            public ErrorMessage() { }
            public ErrorMessage(Common.ResponseMessage oResponseMessage)
            {
                #region ErrorMessage Properties Values
                foreach (PropertyInfo prop in oResponseMessage.GetType().GetProperties())
                    GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(oResponseMessage, null), null);
                #endregion
            }

            #region Hide Base Class Properties
            [Obsolete("Don't use this ProviderCode", true)]
            new public string ProviderCode { get; set; }
            #endregion
        }
        #endregion

        #region AirPricingSolution

        public class AirPricingSolution : Flight.AirPricingSolution
        {
            public AirPricingSolution() {}

            public AirPricingSolution(Flight.AirPricingSolution oAirPricingSolution, Flight.AirSegmentList oAirSegmentList, Flight.RouteList oRouteList, Flight.FareInfoList oFareInfoList, Flight.FlightDetailsList oFlightDetailsList)
            {
                List<AirSegment> oFareAirSegmentList = new List<AirSegment>();
                #region AirPricingSolution Properties Values
                foreach (PropertyInfo prop in oAirPricingSolution.GetType().GetProperties())
                    GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(oAirPricingSolution, null), null);
                #endregion

                #region AirSegment List Values
                if (oAirSegmentList.AirSegment.Count > 0)
                {
                    foreach (Flight.Journey journey in oAirPricingSolution.Journey)
                    {
                        foreach (Flight.Journey.typeAirSegmentRef airSegment in journey.AirSegmentRef)
                        {
                            try
                            {
                                var oAirSegment = (from a in oAirSegmentList.AirSegment
                                                   where a.Key == airSegment.Key
                                                   select a).First<Flight.AirSegment>();
                                if (oAirSegment != null)
                                {
                                    if (oAirSegment.AirAvailInfo.Count > 0)
                                        oAirSegment.ProviderCode = oAirSegment.AirAvailInfo[0].ProviderCode;
                                    var oFlightDetails = (from f in oFlightDetailsList.FlightDetails
                                                          where f.Key == oAirSegment.FlightDetailsRef[0].Key
                                                          select f).First<Flight.FlightDetails>();

                                    Journey oJourney = new Journey(oAirSegment);
                                    oJourney.AirSegment.FlightDetails.Add(oFlightDetails);
                                    this.JourneyList.Add(oJourney);

                                    if (oFareAirSegmentList.Contains(oJourney.AirSegment) == false)
                                        oFareAirSegmentList.Add(oJourney.AirSegment);
                                }
                            }
                            catch (Exception ex)
                            {
                                  string errorMessage = ex.Message;
                            }
                        }
                    }
                }
                #endregion

                #region RouteLegList Values
                foreach (Flight.LegRef legref in oAirPricingSolution.LegRef)
                {
                    var oRouteLeg = (from r in oRouteList.Route.Leg
                                       where r.Key == legref.Key
                                       select r).First<Flight.RouteLeg>();
                    if (oRouteLeg != null)
                        this.RouteLegList.Add(oRouteLeg);
                }
                #endregion

                #region AirPricingInfo Values

                foreach (Flight.AirPricingInfo airPricingInfo in oAirPricingSolution.AirPricingInfo)
                {
                    AirPricingInfo oAirPricingInfo = new AirPricingInfo(airPricingInfo, oFareInfoList, oFareAirSegmentList);
                    //oAirPricingInfo.
                    AirPricingInfoList.Add(oAirPricingInfo);

                }
                #endregion
            }

            #region Hide Base Class Properties
            //[Obsolete("Don't use this Journey", true)]
            //new public List<Flight.Journey> Journey { get; set; }
            [Obsolete("Don't use this LegRef", true)]
            new public List<Flight.LegRef> LegRef { get; set; }
            #endregion

            private List<RouteLeg> routeLegListField = new List<RouteLeg>();
            private List<Journey> journeyListField = new List<Journey>();
            private List<AirPricingInfo> airPricingInfoListField = new List<AirPricingInfo>();

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

            public List<AirPricingInfo> AirPricingInfoList
            {
                get
                {
                    return this.airPricingInfoListField;
                }
                set
                {
                    this.airPricingInfoListField = value;
                }
            }

            #region Journey Class
            public class Journey : Flight.Journey
            {

                public Journey(Flight.AirSegment oAirSegment)
                {
                    //foreach (PropertyInfo prop in oAirSegment.GetType().GetProperties())
                    //    AirSegment.GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(oAirSegment, null), null);
                    this.AirSegment = new AirSegment(oAirSegment);
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


                #region Hide Base Class Properties
                [Obsolete("Don't use this AirSegmentRef", true)]
                new public List<typeAirSegmentRef> AirSegmentRef { get; set; }
                #endregion

            }
            #endregion


            #region AirSegment Class
            public class AirSegment : Flight.AirSegment
            {
                public AirSegment() { }

                public AirSegment(Flight.AirSegment oAirSegment)
                {
                    foreach (PropertyInfo prop in oAirSegment.GetType().GetProperties())
                    {
                        try
                        {
                            GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(oAirSegment, null), null);
                        }
                        catch (Exception ex)
                        {
                            string errorMessage = ex.Message;
                        }
                    }
                }

                //public AirSegment(Flight.FlightDetails oFlightDetails)
                //{
                //    this.FlightDetails = oFlightDetails;
                //}

                //private Flight.FlightDetails flightDetailsField = new Flight.FlightDetails();
                //public Flight.FlightDetails FlightDetails
                //{
                //    get
                //    {
                //        return this.flightDetailsField;
                //    }
                //    set
                //    {
                //        this.flightDetailsField = value;
                //    }
                //}


                #region Hide Base Class Properties
                [Obsolete("Don't use this FlightDetailsRef", true)]
                new public List<FlightDetailsRef> FlightDetailsRef { get; set; }
                #endregion
            }
            #endregion


            #region AirPricingInfo Class
            public class AirPricingInfo : Flight.AirPricingInfo
            {
                public AirPricingInfo(Flight.AirPricingInfo oAirPricingInfo, Flight.FareInfoList oFareInfoList, List<AirSegment> oAirSegmentList)
                {
                    #region AirPricingInfo Properties Values
                    foreach (PropertyInfo prop in oAirPricingInfo.GetType().GetProperties())
                        GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(oAirPricingInfo, null), null);
                    #endregion

                    #region BookingInfoList Values
                    foreach (Flight.BookingInfo bookinginfo in oAirPricingInfo.BookingInfo)
                    {
                        BookingInfoList.Add(new AirBookingInfo(bookinginfo));

                        var oFareInfo = (from f in oFareInfoList.FareInfo
                                         where f.Key == bookinginfo.FareInfoRef
                                         select f).First<Flight.FareInfo>();
                        if (oFareInfo != null)
                            this.FareInfoList.Add(oFareInfo);

                        var oAirSegment = (from a in oAirSegmentList
                                         where a.Key == bookinginfo.SegmentRef
                                         select a).First<AirSegment>();
                        if (oAirSegment != null)
                        {
                            //AirSegment FareAirSegment = new AirSegment();
                            this.AirSegmentList.Add(oAirSegment);
                        }
                    }
                    #endregion
                }

                #region Hide Base Class Properties
                [Obsolete("Don't use this FareInfoRef", true)]
                new public List<FareInfoRef> FareInfoRef { get; set; }
                [Obsolete("Don't use this BookingInfo", true)]
                new public List<BookingInfo> BookingInfo { get; set; }
                #endregion

                private List<AirBookingInfo> bookingInfoListField = new List<AirBookingInfo>();
                private List<FareInfo> fareInfoListField = new List<FareInfo>();
                private List<AirSegment> airSegmentListField = new List<AirSegment>();


                public List<AirBookingInfo> BookingInfoList
                {
                    get
                    {
                        return this.bookingInfoListField;
                    }
                    set
                    {
                        this.bookingInfoListField = value;
                    }
                }

                public List<FareInfo> FareInfoList
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


                public List<AirSegment> AirSegmentList
                {
                    get
                    {
                        return this.airSegmentListField;
                    }
                    set
                    {
                        this.airSegmentListField = value;
                    }
                }
            }
            #endregion


            #region AirBookingInfo Class
            public class AirBookingInfo : Flight.BookingInfo
            {
                public AirBookingInfo(Flight.BookingInfo oBookingInfo)
                {
                    #region AirPricingInfo Properties Values
                    foreach (PropertyInfo prop in oBookingInfo.GetType().GetProperties())
                        GetType().GetProperty(prop.Name).SetValue(this, prop.GetValue(oBookingInfo, null), null);
                    #endregion
                }

                #region Hide Base Class Properties
                [Obsolete("Don't use this FareInfoRef", true)]
                new public string FareInfoRef { get; set; }
                [Obsolete("Don't use this SegmentRef", true)]
                new public string SegmentRef { get; set; }
                #endregion
            }
            #endregion

        }
        #endregion


        #region SearchInfo
        public class SearchInfo
        {
            #region Constructors
            public SearchInfo()
            {
            }

            public SearchInfo(string fromCity, string toCity, DateTime frightDate, int adults, int children, bool directFlightOnly, CabinClass frightClass, string specifiedAirline)
                : this(fromCity, toCity, frightDate.ToString(Variables.DATE_FORMAT), adults, children, directFlightOnly, frightClass, specifiedAirline)
            {
            }

            public SearchInfo(string fromCity, string toCity, string frightDate, int adults, int children, bool directFlightOnly, CabinClass frightClass, string specifiedAirline)
            {
                this.m_FromCity = fromCity;
                this.m_ToCity = toCity;
                this.m_FrightDate = frightDate;
                this.m_Adults = adults;
                this.m_Children = children;
                this.m_DirectFlightOnly = directFlightOnly;
                this.m_FrightClass = frightClass;
                this.m_SpecifiedAirline = specifiedAirline;
            }
            #endregion

            #region Properties Variables
            private string m_FromCity = string.Empty;
            private string m_ToCity = string.Empty;
            private string m_FrightDate = string.Empty;
            private int m_Adults = 0;
            private int m_Children = 0;
            private bool m_DirectFlightOnly = false;
            private CabinClass m_FrightClass = CabinClass.Economy;
            private string m_SpecifiedAirline = string.Empty;
            #endregion

            #region Public Properties
            public string FromCity { get { return m_FromCity; } set { m_FromCity = value; } }
            public string ToCity { get { return m_ToCity; } set { m_ToCity = value; } }
            public string StartDate { get { return m_FrightDate; } set { m_FrightDate = value; } }
            public DateTime FrightDate { get { return DateTime.ParseExact(m_FrightDate, Variables.DATE_FORMAT, null); } set { m_FrightDate = value.ToString(Variables.DATE_FORMAT); } }
            public int Adults { get { return m_Adults; } set { m_Adults = value; } }
            public int Children { get { return m_Children; } set { m_Children = value; } }
            public CabinClass FrightClass { get { return m_FrightClass; } set { m_FrightClass = value; } }
            public string SpecifiedAirline { get { return m_SpecifiedAirline; } set { m_SpecifiedAirline = value; } }
            public int TotalSeats { get { return (m_Adults + m_Children); } }
            public bool DirectFlightOnly { get { return m_DirectFlightOnly; } set { m_DirectFlightOnly = value; } }
            public string DirectFlight { get { return (m_DirectFlightOnly == true) ? Variables.YES : Variables.NO; } }
            #endregion

            public enum CabinClass
            {

                /// <remarks/>
                First,

                /// <remarks/>
                Business,

                /// <remarks/>
                Economy,

                /// <remarks/>
                PremiumEconomy,

                /// <remarks/>
                PremiumFirst,
            }
        }
        #endregion
    }

}
