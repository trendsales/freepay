using System.Collections.Generic;
using System.Net.Http.Formatting;

namespace Freepay
{
    public static class Formatters
    {
        public static IEnumerable<MediaTypeFormatter> Get()
        {
            return new MediaTypeFormatter[] { new XmlMediaTypeFormatter() { UseXmlSerializer = true }, };
        }
    }
}