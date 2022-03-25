using IM.Application.Interfaces.Services;
using IM.Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace IM.API.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    [Authorize]
    public class OrderController : Controller
    {
        private readonly IOrderService _service;
        private readonly ILogger<OrderController> _logger;

        public OrderController(IOrderService service, ILogger<OrderController> logger)
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
        public async Task<IActionResult> Post([FromBody] OrderViewModel order)
        {
            order.CreatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _service.Insert(order);
            }

            return Ok();
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put([FromQuery] Guid id, [FromBody] OrderViewModel order)
        {
            if (id != order.Id) return BadRequest();

            order.UpdatedAt = DateTime.Now;

            if (ModelState.IsValid)
            {
                await _service.Update(id, order);
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
