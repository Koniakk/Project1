using Microsoft.AspNetCore.Mvc;
using AviaSales.Data;
using AviaSales.Service;
using NewsAPI.Data;

namespace AviaSales.Controllers
{
    [Route("AviaSales/Country")]
    [ApiController]
    public class CountryController(CountryService service):ControllerBase
    {
        private CountryService _service { get; } = service;

        [HttpGet]
        public async Task<ActionResult<CountryDTO>> Get([FromBody] List<int> ids)
        {
            var topic =(await _service.Get(_service._dataContext.Countries, ids))
                .Select(x => x.ToDTO())
                .ToList();

            return Ok(topic);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] List<int> ids)
        {
            var result = await _service.Delete(_service._dataContext.Countries, ids);

            if (result)
                return Ok(result);
            else
                return BadRequest("No countries were deleted");
        }

        [HttpPost]
        public async Task<ActionResult> Set([FromBody] List<CountryDTO> topics)
        {
            var result = await _service.Set(
                _service._dataContext.Countries, 
                topics.Select(x=>x.ToEntity()).ToList()
                );

            if (result)
                return Ok(result);
            else
                return BadRequest("No countries were updated");
        }


    }
}
