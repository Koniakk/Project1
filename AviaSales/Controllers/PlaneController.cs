using Microsoft.AspNetCore.Mvc;
using AviaSales.Data;
using AviaSales.Service;
using NewsAPI.Data;

namespace AviaSales.Controllers
{
    [Route("avia_sales/plane")]
    [ApiController]
    public class PlaneController(PlaneService service):ControllerBase
    {
        private PlaneService _service { get; } = service;

        [HttpGet]
        public async Task<ActionResult<PlaneDTO>> Get([FromBody] List<int> ids)
        {
            var topic =(await _service.Get(_service._dataContext.Planes, ids))
                .Select(x => x.ToDTO())
                .ToList();

            return Ok(topic);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] List<int> ids)
        {
            var result = await _service.Delete(_service._dataContext.Planes, ids);

            if (result)
                return Ok(result);
            else
                return BadRequest("No Planes were deleted");
        }

        [HttpPost]
        public async Task<ActionResult> Set([FromBody] List<PlaneDTO> topics)
        {
            var result = await _service.Set(
                _service._dataContext.Planes, 
                topics.Select(x=>x.ToEntity()).ToList()
                );

            if (result)
                return Ok(result);
            else
                return BadRequest("No Planes were updated");
        }


    }
}
