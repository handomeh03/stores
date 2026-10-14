using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Stores.BusinessLogic.Product;

namespace Stores.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController : Controller
    {
        private readonly ProductService _productService;

        public ProductController(ProductService productService)
        {
            _productService = productService;
        }

        [HttpGet]
        [Authorize(Roles = "storeOwner")]
        public async Task<IActionResult> GetAllProducts()
        {
            var products = await _productService.GetAllProductsAsync();
            if (products == null  )
            {
                return NotFound(new { message ="Products Not Found"});
            }
            return Ok(new { data = products });
        }

        [HttpGet("{id}")]
        [Authorize(Roles = "storeOwner")]
        public async Task<IActionResult> GetProductById(int id)
        {
            var product = await _productService.GetProductByIdAsync(id);
            if (product == null)
            {
                return NotFound(new {  message = "Product not found" });
            }

            return Ok(new {  data = product });
        }

        [HttpPost]
        [Authorize(Roles = "storeOwner")]
        public async Task<IActionResult> CreateProduct([FromBody] CreateProductDto dto)
        {
            var createdProduct = await _productService.CreateProductAsync(dto);
            return Ok(new {  message = "Product created successfully", data = createdProduct });
        }

        [HttpPut("{id}")]
        [Authorize(Roles = "storeOwner")]
        public async Task<IActionResult> UpdateProduct(int id, [FromBody] UpdateProductDto dto)
        {
            var updated = await _productService.UpdateProductAsync(id, dto);
            if (!updated)
            {
                return NotFound(new { success = false, message = "Product not found" });
            }

            return Ok(new { success = true, message = "Product updated successfully" });
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = "storeOwner")]
        public async Task<IActionResult> DeleteProduct(int id)
        {
            var deleted = await _productService.DeleteProductAsync(id);
            if (!deleted)
            {
                return NotFound(new {  message = "Product not found" });
            }

            return Ok(new {  message = "Product deleted successfully" });
        }
    }
}