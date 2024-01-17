using System.Collections.Generic;
using System.Linq;

namespace TestNinja.Mocking
{
    public class VideoFilter : IVideoFilter
    {
        public List<Video> GetVideos()  
        {
            using (var context = new VideoContext())
            {
                return (from video in context.Videos
                        where !video.IsProcessed
                        select video).ToList();
            }
        }
    }

    public interface IVideoFilter
    {
        List<Video> GetVideos();
    }
}