using IM.Application.ViewModel;
using IM.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;

namespace IM.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IProductService _service;
        private readonly ILogger<ProductController> _logger;

        public ProductController(IProductService service, ILogger<ProductController> logger)
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
        public async Task<IActionResult> Post([FromBody] ProductViewModel product)
        {
            if (ModelState.IsValid)
            {
                await _service.Insert(product);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromQuery] Guid id, [FromBody] ProductViewModel product)
        {
            if(id != product.Id) return BadRequest();

            if (ModelState.IsValid)
            {
                await _service.Update(id, product);
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
