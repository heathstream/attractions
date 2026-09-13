using DbModels;
using Microsoft.AspNetCore.Mvc;
using Models;
using Services;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AppWebApi.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class AttractionsController : Controller
    {
        readonly IAttractionService _service = null;
        readonly ILogger<AttractionsController> _logger = null;

        [HttpGet()]
        [ProducesResponseType(typeof(ResponseListDto<AttractionDbm>), 200)]
        [ProducesResponseType(typeof(string), 400)]
        public async Task<IActionResult> Attractions(int page, int pageSize)
        {
            try
            {
                var items = await _service.ReadAttractionsAsync();
                var responseList = new ResponseListDto<AttractionDbm>()
                {
                    Items = items.Skip(page * pageSize).Take(pageSize).ToList(),
                    Page = page,
                    PageSize = pageSize,
                    ItemsInDatabase = items.Count(),
                };
                return Ok(responseList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet()]
        [ProducesResponseType(typeof(ResponseItemDto<AttractionDbm>), 200)]
        public async Task<IActionResult> Attraction(string idOrName)
        {
            try
            {
                var itemCount = _service.ReadAttractionsAsync().Result.Count();
                var item = await _service.ReadAttractionAsync(idOrName);
                if (item == null)
                    throw new Exception("Could not find an attraction by that name or id! :(");

                var responseItem = new ResponseItemDto<AttractionDbm>()
                {
                    Item = item,
                    ItemsInDatabase = itemCount,
                };

                return Ok(responseItem);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        public AttractionsController(
            IAttractionService service,
            ILogger<AttractionsController> logger
        )
        {
            _service = service;
            _logger = logger;
        }
    }
}
