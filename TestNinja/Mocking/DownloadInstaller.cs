using System.Net;

namespace TestNinja.Mocking
{
    public class DownloadInstaller : IDownloadInstaller
    {
        public bool Download(string customerName, string installerName, string destination)
        {
            var client = new WebClient();
            try
            {
                client.DownloadFile(
                    string.Format("http://example.com/{0}/{1}",
                        customerName,
                        installerName),
                    destination);

                return true;
            }
            catch (WebException)
            {
                return false; 
            }
        }
    }

    public interface IDownloadInstaller
    {
        bool Download(string customerName, string installerName, string destination);
    }
}