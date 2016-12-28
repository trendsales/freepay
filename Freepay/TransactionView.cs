using System;
using System.Xml.Serialization;
// ReSharper disable InconsistentNaming
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Freepay
{
    [XmlRoot(Namespace = "http://gw.freepay.dk/WebServices/Public/Management")]
    public class TransactionView
    {
        public int TransactionID { get; set; }
        public int MerchantID { get; set; }
        public int MerchantNumber { get; set; }
        public DateTime DateCreated { get; set; }
        public DateTime DateAuthorized { get; set; }
        public DateTime DateCaptured { get; set; }
        public int Currency { get; set; }
        public string OrderID { get; set; }
        public string CardType { get; set; }
        public string SourceIP { get; set; }
        public int AuthorizationAmount { get; set; }
        public bool IsCaptured { get; set; }
        public int CaptureAmount { get; set; }
        public int CaptureErrorCode { get; set; }
        public DateTime DateEarliestCapture { get; set; }
        public bool IsAwaitingApproval { get; set; }
        public string PANHash { get; set; }
        public string Acquirer { get; set; }
    }
}