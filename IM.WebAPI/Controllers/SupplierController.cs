using IM.Application.Interfaces.Services;
using IM.Application.ViewModel;
using Microsoft.AspNetCore.Mvc;

namespace IM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
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
        public async Task<IActionResult> Get()
        {
            var result = await _service.GetAll();
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
    }
}
