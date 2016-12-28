using System.Xml.Serialization;
// ReSharper disable UnusedAutoPropertyAccessor.Global

namespace Freepay
{
    [XmlRoot(Namespace = "http://gw.freepay.dk/WebServices/Public/Management")]
    public class TransactionResult
    {
        public int AcquirerStatusCode { get; set; }
        public bool IsSuccess { get; set; }
    }
}