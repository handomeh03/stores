using Stores.DataAccess;
using Stores.Models;

namespace Stores.BusinessLogic.Product
{
    public class ProductService
    {
        private readonly ProductRepository _productRepository;

        public ProductService(ProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        public async Task<IEnumerable<Models.Product>> GetAllProductsAsync()
        {
            return await _productRepository.GetAllProductsAsync();
        }

        public async Task<Models.Product?> GetProductByIdAsync(int id)
        {
            return await _productRepository.GetProductByIdAsync(id);
        }

        public async Task<Models.Product> CreateProductAsync(CreateProductDto dto)
        {
            var productEntity = new Models.Product
            {
                Name = dto.Name,
                Price = dto.Price,
                Description = dto.Description,
                Stock = dto.Stock
            };

            return await _productRepository.CreateProductAsync(productEntity);
        }

        public async Task<bool> UpdateProductAsync(int id, UpdateProductDto dto)
        {
            var existingProduct = await _productRepository.GetProductByIdAsync(id);
            if (existingProduct == null)
            {
                return false; 
            }

           
            existingProduct.Name = dto.Name ?? existingProduct.Name;
            existingProduct.Price = dto.Price ?? existingProduct.Price;
            existingProduct.Description = dto.Description ?? existingProduct.Description;
            existingProduct.Stock = dto.Stock ?? existingProduct.Stock;

            await _productRepository.UpdateProductAsync(existingProduct);
            return true;
        }

        public async Task<bool> DeleteProductAsync(int id)
        {
            return await _productRepository.DeleteProductAsync(id);
        }
    }
}