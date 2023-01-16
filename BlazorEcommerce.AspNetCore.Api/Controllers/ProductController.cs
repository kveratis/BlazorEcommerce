using BlazorEcommerce.AspNetCore.Api.Domain;
using Microsoft.AspNetCore.Mvc;

namespace BlazorEcommerce.AspNetCore.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public sealed class ProductController : ControllerBase
    {
        private readonly DataContext _context;
        private readonly ILogger<ProductController> _logger;

        public ProductController(DataContext context, ILogger<ProductController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<ActionResult<List<Product>>> GetProducts()
        {
            var products = await _context.Products.ToListAsync();
            return Ok(products);
        }
    }
}
