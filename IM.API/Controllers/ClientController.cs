using IM.Application.Interfaces.Services;
using IM.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class ClientController : ControllerBase
    {
        private readonly IClientService _service;
        private readonly ILogger<ClientController> _logger;

        public ClientController(IClientService service, ILogger<ClientController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAll(x => x.CreatedBy == GetUserId());
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get([FromQuery] Guid id)
        {

            var result = await _service.GetById(id);
            return Ok(result);
        }

        [HttpPost]
        public async Task<IActionResult> Post([FromBody] ClientViewModel client)
        {
            client.CreatedAt = DateTime.Now;
            client.CreatedBy = GetUserId();

            if (ModelState.IsValid)
            {
                await _service.Insert(client);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromQuery] Guid id, [FromBody] ClientViewModel client)
        {
            if (id != client.Id) return BadRequest();

            client.UpdatedAt = DateTime.Now;
            client.UpdatedBy = GetUserId();

            if (ModelState.IsValid)
            {
                await _service.Update(id, client);
            }

            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromQuery] Guid id)
        {
            await _service.Remove(id);

            return Ok();
        }

        private Guid GetUserId()
        {
            var claims = HttpContext.User.Identities.FirstOrDefault().Claims.ToList();
            var userId = claims.Find(x => x.Type == "id").Value;
            var id = new Guid(userId);
            return id;
        }
    }
}
