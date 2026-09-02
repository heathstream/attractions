using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class RatingsController : Controller
    {
        readonly ICommentService _service = null;
        readonly ILogger<RatingsController> _logger = null;

        public RatingsController(ICommentService service, ILogger<RatingsController> logger)
        {
            _service = service;
            _logger = logger;
        }
    }
}
