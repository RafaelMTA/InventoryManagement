using IM.Application.ViewModels;
using IM.Application.Interfaces.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;

namespace IM.API.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize]
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
        public async Task<IActionResult> Post([FromBody] ProductViewModel product)
        {
            product.CreatedAt = DateTime.Now;
           
            if (ModelState.IsValid)
            {
                await _service.Insert(product);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromQuery] Guid id, [FromBody] ProductViewModel product)
        {
            if (id != product.Id) return BadRequest();

            product.UpdatedAt = DateTime.Now;

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

        private Guid GetUserId()
        {
            var claims = HttpContext.User.Identities.FirstOrDefault().Claims.ToList();
            var userId = claims.Find(x => x.Type == "id").Value;
            Guid id = new Guid(userId);
            return id;
        }
    }
}
