using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            var formatter = new HtmlFormatter();

            var result = formatter.FormatAsBold("abc");

            //Specific - disable case sensitive
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

            //More general
            //Assert.That(result, Does.StartWith("<strong>").IgnoreCase);
            //Assert.That(result, Does.EndWith("</strong>").IgnoreCase);
            //Assert.That(result, Does.Contain("abc"));
        }
    }
}
