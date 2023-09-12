using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using server_travel.Interfaces;
using server_travel.Models;

namespace server_travel.Controllers.admin
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

        [HttpPost]
        [Route("Gallery")]
        public async Task<IActionResult> uploadGallery(IFormFile image)
        {
            if (image == null)
            {
                return BadRequest("Vui lòng gửi file đính kèm");

            }
            var img = await _upLoadService.UploadImageGallery(image);
            return Ok(img);
        }

        [HttpGet]
        [Route("Gallery")]
        public async Task<List<ImageViewModel>> GetGallery()
        {
            var data = await _upLoadService.GetImageGallery();
            return data;
        }
    }
}
