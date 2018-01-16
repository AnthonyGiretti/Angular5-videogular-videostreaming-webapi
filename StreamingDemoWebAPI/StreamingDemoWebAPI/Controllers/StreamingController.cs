using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace StreamingDemoWebAPI.Controllers
{
    [Route("api/[controller]")]
    public class StreamingController : Controller
    {
        private IAzureVideoStreamService _streamingService;

        public StreamingController(IAzureVideoStreamService streamingService)
        {
            _streamingService = streamingService;
        }

        [HttpGet("{name}")]
        public async Task<FileStreamResult> Get(string name)
        {
            var stream = await _streamingService.GetVideoByName(name);
            return new FileStreamResult(stream, "video/mp4");
        }
    }
}
