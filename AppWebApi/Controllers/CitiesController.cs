using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CitiesController : Controller
    {
        readonly ICommentService _service = null;
        readonly ILogger<CitiesController> _logger = null;

        public CitiesController(ICommentService service, ILogger<CitiesController> logger)
        {
            _service = service;
            _logger = logger;
        }
    }
}
