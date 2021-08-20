using System;

namespace data_extractor.Models
{
    public class InputCsvModel
    {
        public string IsMultiFill { get; set; }
        public string ISIN { get; set; }
        public string Currency { get; set; }
        public string Venue { get; set; }
        public string OrderRef { get; set; }
        public string PMID { get; set; }
        public string CFICode { get; set; }
        public string ParticipantCode { get; set; }
        public string TraderID { get; set; }
        public string CounterPartyCode { get; set; }
        public string DecisionTime { get; set; }
        public string ArrivalTime_QuoteTime { get; set; }
        public string FirstFillTime_TradeTime { get; set; }
        public string LastFillTime { get; set; }
        public string Price { get; set; }
        public string Quantity { get; set; }
        public string Side { get; set; }
        public string TradeFlag { get; set; }
        public string SettlementDate { get; set; }
        public string PublicTradeID { get; set; }
        public string UserDefinedFilter { get; set; }
        public string TradingNetworkID { get; set; }
        public string SettlementPeriod { get; set; }
        public string MarketOrderId { get; set; }
        public string ParticipationRate { get; set; }
        public string BenchmarkVenues { get; set; }
        public string BenchmarkType { get; set; }
        public string FlowType { get; set; }
        public string BasketID { get; set; }
        public string MessageType { get; set; }
        public string ParentOrderRef { get; set; }
        public string ExecutionType { get; set; }
        public string LimitPrice { get; set; }
        public string Urgency { get; set; }
        public string AlgoName { get; set; }
        public string AlgoParams { get; set; }
        public string Index { get; set; }
        public string Sector { get; set; }
    }
}
