using BLL.DTOs;
using BLL.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Swapno.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly ProductService _service;

        public ProductController(ProductService service)
        {
            _service = service;
        }

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            var data = await _service.GetAllAsync();
            return Ok(data);
        }

        [HttpPost]
        public async Task<IActionResult> Create(ProductDto dto)
        {
            try
            {
                var data = await _service.CreateProductAsync(dto);
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Update(int id, ProductDto dto)
        {
            try
            {
                var data = await _service.UpdateProductAsync(id, dto);
                if (data == null) return NotFound("Product not found");
                return Ok(data);
            }
            catch (System.Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        // সার্চ API: api/product/search?name=apple&min=10&max=500
        [HttpGet("search")]
        public async Task<IActionResult> Search([FromQuery] string? name, [FromQuery] double? min, [FromQuery] double? max)
        {
            var data = await _service.SearchAsync(name, min, max);
            return Ok(data);
        }

        [HttpGet("expiry-report")]
        public async Task<IActionResult> GetExpiryReport()
        {
            var data = await _service.GetExpiryReportAsync();

            if (data == null || data.Count == 0)
                return Ok(new { message = "No products are expiring within 7 days." });

            return Ok(data);
        }
    }
}
