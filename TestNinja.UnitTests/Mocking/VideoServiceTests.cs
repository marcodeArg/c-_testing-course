using System.Collections.Generic;
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
        private Mock<IVideoFilter> _mockRepository;

        [SetUp]
        public void SetUp()
        {
            _mockFileReader = new Mock<IFileReader>();
            _mockRepository = new Mock<IVideoFilter>();
            _videoService = new VideoService(_mockFileReader.Object, _mockRepository.Object); 
        }
        
        [Test]
        public void ReadVideoTitle_EmptyVideo_ReturnError()
        {
            _mockFileReader.Setup(fr => fr.Read("video.txt")).Returns("");
            
            var result = _videoService.ReadVideoTitle();
            
            Assert.That(result, Does.Contain("error").IgnoreCase);
        }

        [Test]
        public void GetUnprocessedVideosAsCsv_AllVideosAreProcessed_ReturnEmptyString()
        {
            _mockRepository.Setup(vf => vf.GetVideos()).Returns(new List<Video>());

            var result = _videoService.GetUnprocessedVideosAsCsv();
            
            Assert.That(result, Is.Empty);
        }
        
        [Test]
        public void GetUnprocessedVideosAsCsv_SomeUnprocessedVideos_ReturnCommaSeparatedIds()
        {
            var video1 = new Video { Id = 1};
            var video2 = new Video { Id = 2};

            _mockRepository.Setup(vf => vf.GetVideos()).Returns(new List<Video> { video1, video2 });

            var result = _videoService.GetUnprocessedVideosAsCsv();
            
            Assert.That(result, Is.EqualTo("1,2").IgnoreCase);
        }
        
    }
}