using Moq;
using NUnit.Framework;
using TestNinja.Mocking;

namespace TestNinja.UnitTests.Mocking
{
    [TestFixture]
    public class VideoServiceTests
    {
        private VideoService _videoService;
        private Mock<IFileReader> _mockFileReader;
        private Mock<IVideoFilter> _mockVideoFilter;

        [SetUp]
        public void SetUp()
        {
            _mockFileReader = new Mock<IFileReader>();
            _mockVideoFilter = new Mock<IVideoFilter>();
            _videoService = new VideoService(_mockFileReader.Object, _mockVideoFilter.Object); 
        }
        
        [Test]
        public void ReadVideoTitle_EmptyVideo_ReturnError()
        {
            _mockFileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            
            var result = _videoService.ReadVideoTitle();
            
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_NoVideoUnprocessed_ReturnEmptyString()
        {
            
        }
        
    }
}