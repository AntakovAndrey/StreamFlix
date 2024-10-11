using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.FileProviders;
using System.Net;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorrentController : ControllerBase
    {
        [HttpPost]
        public async Task<IActionResult> UploadTorrentFile(IFormFile file) 
        {
            string torrentFilePath = Path.Combine("uploads", file.FileName);

            using (var stream = new FileStream(torrentFilePath, FileMode.OpenOrCreate))
            {
                 file.CopyTo(stream);
            }

            return Ok(file);
        } 
    }
}
