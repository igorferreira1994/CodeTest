using Microsoft.AspNetCore.Mvc;
using CodeTest.Application.Service;

namespace CodeTest.Controllers
{
    public class HomeController : Controller
    {
        private readonly ICnabService _service;

        public HomeController(ICnabService service)
        {
            _service = service;
        }

        [HttpGet("/upload-cnab")]
        public IActionResult Upload()
        {
            return View("Upload");
        }

        [HttpPost("/upload-cnab")]
        public async Task<IActionResult> UploadCnab(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                ViewBag.Message = "invalid file.";
                return View("Upload");
            }

            using var stream = file.OpenReadStream();
            await _service.ProcessCnabFileAsync(stream);

            ViewBag.Message = "Process successful.";
            return View("Upload");
        }
    }
}
