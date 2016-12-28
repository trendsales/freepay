using System;
using System.Xml.Serialization;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Freepay
{
    [XmlRoot(Namespace = "http://gw.freepay.dk/WebServices/Public/SubscriptionManager")]
    public class SubscriptionView
    {
        public int SubscriptionID { get; set; }
        public int MerchantID { get; set; }
        public int MerchantNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public int Currency { get; set; }
        public string OrderID { get; set; }
        public string CardType { get; set; }
        public string SourceIP { get; set; }
        public string PANHash { get; set; }
        public DateTime ExpiryDate { get; set; }
        public string Acquirer { get; set; }
    }
}