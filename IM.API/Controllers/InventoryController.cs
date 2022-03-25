using IM.Application.Interfaces.Services;
using IM.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class InventoryController : ControllerBase
    {
        private readonly IInventoryService _service;
        private readonly ILogger<InventoryController> _logger;

        public InventoryController(IInventoryService service, ILogger<InventoryController> logger)
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
        public async Task<IActionResult> Post([FromBody] InventoryViewModel inventory)
        {
            inventory.CreatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _service.Insert(inventory);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromQuery] Guid id, [FromBody] InventoryViewModel inventory)
        {
            if (id != inventory.Id) return BadRequest();

            inventory.UpdatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _service.Update(id, inventory);
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
            Guid id = new Guid(userId);
            return id;
        }
    }
}
