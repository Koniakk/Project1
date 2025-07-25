using Microsoft.AspNetCore.Mvc;
using AviaSales.Data;
using AviaSales.Service;

namespace AviaSales.Controllers
{
    [Route("avia_sales/ticket")]
    [ApiController]
    public class TicketController(TicketService service):ControllerBase
    {
        private TicketService _service { get; } = service;

        [HttpGet]
        public async Task<ActionResult<TicketDTO>> Get([FromBody] List<int> ids)
        {
            var topic =(await _service.Get(_service._dataContext.Tickets, ids))
                .Select(x => x.ToDTO())
                .ToList();

            return Ok(topic);
        }

        [HttpDelete]
        public async Task<ActionResult> Delete([FromBody] List<int> ids)
        {
            var result = await _service.Delete(_service._dataContext.Tickets, ids);

            if (result)
                return Ok(result);
            else
                return BadRequest("No tickets were deleted");
        }

        [HttpPost]
        public async Task<ActionResult> Set([FromBody] List<TicketDTO> topics)
        {
            var result = await _service.Set(
                _service._dataContext.Tickets, 
                topics.Select(x=>x.ToEntity()).ToList()
                );

            if (result)
                return Ok(result);
            else
                return BadRequest("No tickets were updated");
        }


    }
}
