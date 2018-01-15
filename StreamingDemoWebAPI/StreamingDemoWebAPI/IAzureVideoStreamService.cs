using System.IO;
using System.Threading.Tasks;

namespace StreamingDemoWebAPI
{
    public interface IAzureVideoStreamService
    {
        Task<Stream> GetVideoByName(string name);
    }
}