using Microsoft.AspNetCore.Mvc;
using MonoTorrent.Client;

namespace Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TorrentController : ControllerBase
    {
        [HttpOptions]
        public IActionResult Options()
        {
            return Ok();
        }
        
        [HttpPost]
        public async Task<IActionResult> UploadTorrentFile(IFormFile file) 
        {
            Console.WriteLine($"File received. Filename: {file.FileName}");
            string torrentFilePath = Path.Combine("uploads", file.FileName);
            using (var stream = new FileStream(torrentFilePath, FileMode.OpenOrCreate))
            {
                 file.CopyTo(stream);
            }
            string resultFilePath = await StartTorrentDownload(torrentFilePath);
            Console.WriteLine($"http://localhost:5000/api/Torrent/stream?fileName={Uri.EscapeDataString(resultFilePath)}");
            return new JsonResult($"http://localhost:5000/api/Torrent/stream?fileName={Uri.EscapeDataString(resultFilePath)}");
        }

        [HttpGet("stream")]
        public async Task<IActionResult> StreamVideo(string fileName)
        {
            string videoPath=Path.Combine("./downloads/", fileName);
            var fileStream = new FileStream(videoPath, FileMode.Open, FileAccess.Read, FileShare.Read);
            var response = new FileStreamResult(fileStream, "video/mp4");
            response.EnableRangeProcessing = true;
            return response;
        }

        private async Task<string> StartTorrentDownload(string torrentFilePath)
        {
            var engine = new ClientEngine();
            var torrentManager = await engine.AddAsync(torrentFilePath,"./downloads/");
            await torrentManager.StartAsync();
            while(torrentManager.Progress<5)
            {
                await Task.Delay(100);
            }
            return torrentManager.Files.First(f=>f.Path.EndsWith(".mp4")).Path;
        }
    }
}
