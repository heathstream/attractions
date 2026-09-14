using DbModels;
using Microsoft.AspNetCore.Mvc;
using Models.Dto;
using Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class UsersController : Controller
    {
        readonly IUserService _service = null;
        readonly ILogger<UsersController> _logger = null;

        [HttpGet()]
        [ProducesResponseType(typeof(ResponseListDto<UserDbm>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Read(int page, int pageSize)
        {
            try
            {
                var responseList = await _service.ReadAsync(page, pageSize);
                if (responseList == null || responseList.ItemsInDatabase == 0)
                    throw new Exception("Could not find any users in the database! :(");
                return Ok(responseList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        [ProducesResponseType(typeof(ResponseItemDto<UserDbm>), 200)]
        public async Task<IActionResult> ReadItem(string idOrName)
        {
            try
            {
                var responseItem = await _service.ReadItemAsync(idOrName);

                if (responseItem == null)
                    throw new Exception("Could not find a user by that name or id! :(");

                return Ok(responseItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete()]
        [ProducesResponseType(typeof(ResponseItemDto<UserDbm>), 200)]
        public async Task<IActionResult> DeleteItem(string idOrName)
        {
            try
            {
                var responseItem = await _service.DeleteAsync(idOrName);

                if (responseItem == null)
                    throw new Exception("Could not find a user by that name or id! :(");

                return Ok(responseItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public UsersController(IUserService service, ILogger<UsersController> logger)
        {
            _service = service;
            _logger = logger;
        }
    }
}
