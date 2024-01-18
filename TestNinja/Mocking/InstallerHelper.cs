using System.Net;

namespace TestNinja.Mocking
{
    public class InstallerHelper
    {
        private string _setupDestinationFile;
        private IDownloadInstaller _downloadInstaller;
        
        public InstallerHelper(IDownloadInstaller dw = null)
        {
            _downloadInstaller = dw ?? new DownloadInstaller();
        }

        public bool DownloadInstaller(string customerName, string installerName)
        {
            return _downloadInstaller.Download(customerName, installerName, _setupDestinationFile);
        }
    }
}