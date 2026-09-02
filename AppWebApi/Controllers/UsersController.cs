using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        readonly ICommentService _service = null;
        readonly ILogger<UsersController> _logger = null;

        public UsersController(ICommentService service, ILogger<UsersController> logger)
        {
            _service = service;
            _logger = logger;
        }
    }
}
