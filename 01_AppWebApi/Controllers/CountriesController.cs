using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class CountriesController : Controller
    {
        readonly ICommentService _service = null;
        readonly ILogger<CountriesController> _logger = null;

        public CountriesController(ICommentService service, ILogger<CountriesController> logger)
        {
            _service = service;
            _logger = logger;
        }
    }
}
