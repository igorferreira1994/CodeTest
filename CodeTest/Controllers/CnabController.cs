using CodeTest.Application.Service;
using CodeTest.Domain;
using Microsoft.AspNetCore.Mvc;

namespace CodeTest.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CnabController : ControllerBase
    {
        private readonly ICnabService _service;
        public CnabController(ICnabService service)
        {
            _service = service;
        }

        [HttpPost("upload")]
        public async Task<IActionResult> Upload(IFormFile file)
        {
            using var stream = file.OpenReadStream();
            await _service.ProcessCnabFileAsync(stream);
            return Ok("Process successful.");
        }

        [HttpGet("stores")]
        public async Task<IActionResult> GetByStore()
        {
            var result = await _service.GetStoreSummariesAsync();
            return Ok(result);
        }

    }
}
