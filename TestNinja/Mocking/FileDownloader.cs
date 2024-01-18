using System.Net;

namespace TestNinja.Mocking
{
    public class FileDownloader : IFileDownloader
    {
        public void Download(string url, string destination)
        {
            var client = new WebClient();
            client.DownloadFile(url, destination);
        }
    }

    public interface IFileDownloader
    {
        void Download(string url, string destination);
    }
}