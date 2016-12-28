using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace Freepay.Tests
{
    [TestFixture]
    public class CurrencyTests
    {
        [Test]
        public void DKK()
        {
            Assert.AreEqual(208, (int)Currency.DKK);
        }

        [Test]
        public void EUR()
        {
            Assert.AreEqual(978, (int)Currency.EUR);
        }

        [Test]
        public void SEK()
        {
            Assert.AreEqual(752, (int)Currency.SEK);
        }

        [Test]
        public void NOK()
        {
            Assert.AreEqual(578, (int)Currency.NOK);
        }
    }
}
