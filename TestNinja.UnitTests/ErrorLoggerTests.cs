using System;
using NUnit.Framework;
using TestNinja.Fundamentals;

namespace TestNinja.UnitTests
{
    [TestFixture]
    public class ErrorLoggerTests
    {

        [Test]
        public void Log_WhenCalled_SetLastErrorProperty()
        {
            var logger = new ErrorLogger();
            logger.Log("a");
            Assert.That(logger.LastError, Is.EqualTo("a"));
        }

        [Test]
        [TestCase(null)]
        [TestCase("")]
        [TestCase(" ")]
        public void Log_InvalidError_ThrowArgumentNullException(string errorMsg)
        {
            var logger = new ErrorLogger();
            Assert.That(() => logger.Log(errorMsg), Throws.ArgumentNullException);
        }

        [Test]
        public void Log_ValidError_RiseErrorLoggedEvent()
        {
            var logger = new ErrorLogger();
            
            var id = Guid.Empty;
            logger.ErrorLogged += (sender, args) => { id = args; };
            logger.Log("a");

            Assert.That(id, Is.Not.EqualTo(Guid.Empty));
        }
    }
}