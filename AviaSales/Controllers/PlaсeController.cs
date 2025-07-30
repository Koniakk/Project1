using Microsoft.AspNetCore.Mvc;
using AviaSales.Data;
using AviaSales.Service;
using NewsAPI.Data;

namespace AviaSales.Controllers
{
    [Route("avia_sales/country")]
    [ApiController]
    public class PlaceController(PlaceService service) : ControllerBase
    {
        private PlaceService _service { get; } = service;

        [HttpGet]
        public async Task<ActionResult<PlaceDTO>> Get([FromBody] List<int> ids)
        {
            var topic = (await _service.Get(_service._dataContext.Places, ids))
                .Select(x => x.ToDTO())
                .ToList();

            return Ok(topic);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] List<int> ids)
        {
            var result = await _service.Delete(_service._dataContext.Places, ids);

            if (result)
                return Ok(result);
            else
                return BadRequest("No Places were deleted");
        }

        [HttpPost]
        public async Task<ActionResult> Set([FromBody] List<PlaceDTO> topics)
        {
            var result = await _service.Set(
                _service._dataContext.Places,
                topics.Select(x => x.ToEntity()).ToList()
                );

            if (result)
                return Ok(result);
            else
                return BadRequest("No Places were updated");
        }


    }
}
