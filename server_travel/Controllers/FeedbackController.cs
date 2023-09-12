using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using server_travel.Dtos.Feedback;
using server_travel.Interfaces;

namespace server_travel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FeedbackController : ControllerBase
    {
        private readonly IFeedbackService _feedbackService;
        public FeedbackController(IFeedbackService feedbackService)
        {
            _feedbackService = feedbackService;
        }
        [HttpPost]
        public async Task<IActionResult> Create([FromForm] FeedbackCreateRequest request)
        {
            try{
                var feedbackId = await _feedbackService.Create(request);
                if(feedbackId == null)
                {
                    return BadRequest();
                }
                return Ok(feedbackId);
            }catch(Exception ex)
            {
                return StatusCode(500, ex.Message);
            }
        }
        [HttpGet]
        public async Task<IActionResult> GetAll(){
            try{
                var data = await _feedbackService.GetAll();
                if(data == null){
                    return BadRequest();
                }
                return Ok(data);
            }catch(Exception ex){
                return StatusCode(500, ex.Message);
            }
        }

        
    }
}
