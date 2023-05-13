using FirstAPI.Filters;
using FirstAPI.Interfaces;
using FirstAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace FirstAPI.Controllers
{
    [Route("[controller]")]
    [ApiController]
    [MyExceptionFilter]
    public class ProductController : ControllerBase
    {
        private readonly IRepo<int, Product> _repo;

        public ProductController(IRepo<int,Product> repo)
        {
            _repo = repo;
        }
        [HttpGet]
        [ProducesResponseType(typeof(ICollection<Product>), StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        
        public async Task<ActionResult<ICollection<Product>>> GET()
        {
            throw new Exception("Check this out");
            //List<Product> products = (await _repo.GetAll()).ToList(); 
            //if(products.Count == 0)
            //{
            //    return NotFound("No products at this moment");
            //}
            //return Ok(products);
        }
        [HttpPost]
        [ServiceFilter(typeof(MyValidationFilter))]
        public async Task<IActionResult> Post(Product product)
        {
            
                Product myProduct = await _repo.Add(product);
                return Created("ProductsHome", product);
        }
    }
}
