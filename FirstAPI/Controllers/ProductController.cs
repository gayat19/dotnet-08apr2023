using FirstAPI.Interfaces;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace FirstAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class ProductController : ControllerBase
    {
        private readonly IRepo<int, Product> _repo;

        public ProductController(IRepo<int,Product> repo)
        {
            _repo = repo;
        }
        [HttpGet]

        public async Task<ICollection<Product>> GET()
        {
            List<Product> products = (await _repo.GetAll()).ToList(); ;
            return products;
        }
        [HttpPost]

        public async Task<Product> Post(Product product)
        {
            Product myProduct = await _repo.Add(product);
            return product;
        }
    }
}
