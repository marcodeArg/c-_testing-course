using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class HtmlFormatterTests
    {
        [Test]
        public void FormatAsBold_WhenCalled_ShouldEncloseTheStringWithStrongElement()
        {
            var html = new HtmlFormatter();
            var result = html.FormatAsBold("abc");
            
            // Specific assertion
            Assert.That(result, Is.EqualTo("<strong>abc</strong>").IgnoreCase);

            // General assertion
            Assert.That(result, Does.StartWith("<strong>"));
            Assert.That(result, Does.EndWith("</strong>"));
            Assert.That(result, Does.Contain("abc"));
        }
    }
}