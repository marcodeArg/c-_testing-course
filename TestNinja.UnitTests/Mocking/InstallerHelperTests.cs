using System.Net;
using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class InstallerHelperTests
    {
        private Mock<IFileDownloader> _fileDownloader;
        private InstallerHelper _helper;
        
        [SetUp]
        public void SetUp()
        {
            _fileDownloader = new Mock<IFileDownloader>();
            _helper = new InstallerHelper(_fileDownloader.Object);
        }


        [Test]
        public void DownloadInstaller_DownloadSuccess_ReturnTrue()
        {
            var result = _helper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.True);
        }

        [Test]
        public void DownloadInstaller_DownloadFail_ReturnFalse()
        {
            _fileDownloader.Setup(fd => 
                fd.Download(It.IsAny<string>(), It.IsAny<string>()))
                .Throws<WebException>();

            var result = _helper.DownloadInstaller("customer", "installer");

            Assert.That(result, Is.False);
        }
        
    }
}