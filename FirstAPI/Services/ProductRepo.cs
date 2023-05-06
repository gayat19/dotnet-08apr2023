using FirstAPI.Interfaces;
using FirstAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;

namespace FirstAPI.Services
{
    public class ProductRepo : IRepo<int, Product>
    {
        private readonly ShopContext _context;
        private readonly ILogger<ProductRepo> _logger;

        public ProductRepo(ShopContext context,ILogger<ProductRepo> logger)
        {
            _context = context;
            _logger = logger;
        }
        public async Task<Product> Add(Product item)
        {
            try
            {
                await _context.AddAsync(item);
                await _context.SaveChangesAsync();
                throw new Exception("Check");
                return item;
            }
            catch (Exception e)
            {
                _logger.LogError(e.Message);
            }
            return null;
        }

        public async Task<Product> Delete(int key)
        {
            Product product = await Get(key);
            if(product != null)
            {
                _context.Remove(product);
                _context.SaveChangesAsync();
            }
            return product;
        }

        public async Task<Product> Get(int key)
        {
            Product product = await _context.Products.SingleOrDefaultAsync(p=>p.Id==key);
            return product;
        }

        public async Task<ICollection<Product>> GetAll()
        {
            List<Product> products = await _context.Products.ToListAsync();
            return products;
        }

        public async Task<Product> Update(Product item)
        {
            Product product = await Get(item.Id);
            if (product != null)
            {
                product.Name = item.Name;
                product.Price = item.Price;
                product.Quantity = item.Quantity;
                _context.SaveChangesAsync();
            }
            return product;
        }
    }
}
