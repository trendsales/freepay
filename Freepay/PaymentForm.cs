using System.Collections.Generic;

namespace Freepay
{
    public class PaymentForm
    {
        private readonly List<Field> fields = new List<Field>();
        public IEnumerable<Field> Fields => fields; 
        public string PostUrl { get; set; }

        public void AddField(string name, string value)
        {
            fields.Add(new Field() { Name = name, Value = value} );
        }
    }
}
