using Microsoft.AspNetCore.Mvc;
using AviaSales.Data;
using AviaSales.Service;

namespace AviaSales.Controllers
{
    [Route("AviaSales/ticket")]
    [ApiController]
    public class PassengerController(PassengerService service):ControllerBase
    {
        private PassengerService _service { get; } = service;

        [HttpGet]
        public async Task<ActionResult<PassengerDTO>> Get([FromBody] List<int> ids)
        {
            var topic =(await _service.Get(_service._dataContext.Passengers, ids))
                .Select(x => x.ToDTO())
                .ToList();

            return Ok(topic);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] List<int> ids)
        {
            var result = await _service.Delete(_service._dataContext.Passengers, ids);

            if (result)
                return Ok(result);
            else
                return BadRequest("No passengers were deleted");
        }

        [HttpPost]
        public async Task<ActionResult> Set([FromBody] List<PassengerDTO> topics)
        {
            var result = await _service.Set(
                _service._dataContext.Passengers, 
                topics.Select(x=>x.ToEntity()).ToList()
                );

            if (result)
                return Ok(result);
            else
                return BadRequest("No passengers were updated");
        }


    }
}
