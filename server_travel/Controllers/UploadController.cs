using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_travel.Interfaces;

namespace server_travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UploadController : ControllerBase
    {
        private readonly IUpLoadService _upLoadService;
        public UploadController(IUpLoadService upLoadService)
        {
            _upLoadService = upLoadService;
        }

        [HttpPost]
        [Route("image/{id}")]
        public async Task<IActionResult> Index(IFormFile image)
        {
            if (image == null)
            {
                return BadRequest("Vui lòng gửi file đính kèm");
            }

            var imageUrl = await _upLoadService.UploadImageAsync(image);
            return Ok(imageUrl);
        }
    }
}
