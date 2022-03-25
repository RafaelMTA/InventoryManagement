using IM.Application.Interfaces.Services;
using IM.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
    public class SupplierController : ControllerBase
    {
        private readonly ISupplierService _service;
        private readonly ILogger<SupplierController> _logger;

        public SupplierController(ISupplierService service, ILogger<SupplierController> logger)
        {
            _service = service;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
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
        public async Task<IActionResult> Post([FromBody] SupplierViewModel supplier)
        {
            supplier.CreatedBy = GetUserId();
            supplier.CreatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _service.Insert(supplier);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromQuery] Guid id, [FromBody] SupplierViewModel supplier)
        {
            if (id != supplier.Id) return BadRequest();

            supplier.UpdatedBy = GetUserId();
            supplier.UpdatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _service.Update(id, supplier);
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
