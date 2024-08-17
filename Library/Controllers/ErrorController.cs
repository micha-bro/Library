using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    public class ErrorController : Controller
    {
        [Route("/error")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public IActionResult HandleError()
        {
            return Problem();
        }
    }
}
