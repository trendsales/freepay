using System.Xml.Serialization;
// ReSharper disable UnusedAutoPropertyAccessor.Global
// ReSharper disable InconsistentNaming

namespace Freepay
{
    [XmlRoot(Namespace = "http://gw.freepay.dk/WebServices/Public/SubscriptionManager")]
    public class AuthorizationResult
    {
        public bool IsSuccess { get; set; }
        public int TransactionID { get; set; }
        public int ErrorCode { get; set; }
    }

}