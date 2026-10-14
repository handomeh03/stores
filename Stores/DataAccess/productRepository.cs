using Microsoft.EntityFrameworkCore;
using stores.data;
using Stores.Models;

namespace Stores.DataAccess
{
    public class ProductRepository
    {
        private readonly AppDbContext _context;

        public ProductRepository(AppDbContext context)
        {
            _context = context;
        }

        
        public async Task<Product> CreateProductAsync(Product product)
        {
            await _context.products.AddAsync(product);
            await _context.SaveChangesAsync();
            return product;
        }

        
        public async Task<Product?> GetProductByIdAsync(int id)
        {
            return await _context.products.FindAsync(id);
        }

        
        public async Task<IEnumerable<Product>> GetAllProductsAsync()
        {
            return await _context.products.ToListAsync();
        }

        
        public async Task UpdateProductAsync(Product product)
        {
            _context.products.Update(product);
            await _context.SaveChangesAsync();
        }

        
        public async Task<bool> DeleteProductAsync(int id)
        {
            var product = await _context.products.FindAsync(id);
            if (product == null)
            {
                return false; 
            }

            _context.products.Remove(product);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}