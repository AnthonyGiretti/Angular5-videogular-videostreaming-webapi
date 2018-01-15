using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace StreamingDemoWebAPI
{
    public class AzureVideoStreamService : IAzureVideoStreamService
    {
        private HttpClient _client;

        public AzureVideoStreamService()
        {
            _client = new HttpClient();
        }

        public async Task<Stream> GetVideoByName(string name)
        {
            var urlBlob = string.Empty;
            switch (name)
            {
                case "earth":
                    urlBlob = "https://anthonygiretti.blob.core.windows.net/videos/earth.mp4";
                    break;
                case "nature1":
                    urlBlob = "https://anthonygiretti.blob.core.windows.net/videos/nature1.mp4";
                    break;
                case "nature2":
                default:
                    urlBlob = "https://anthonygiretti.blob.core.windows.net/videos/nature2.mp4";
                    break;

            }

            return await _client.GetStreamAsync(urlBlob);
            
        }

        ~AzureVideoStreamService()
        {
            if (_client != null)
                _client.Dispose();

        }
    }
}
