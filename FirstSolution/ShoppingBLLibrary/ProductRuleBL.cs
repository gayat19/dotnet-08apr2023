using ShoppingDALLibrary;
using ShoppingModelLibrary;

namespace ShoppingBLLibrary
{
    public class ProductRuleBL
    {
        private readonly IRepo<int,Product> _repo;

        public ProductRuleBL()
        {
            
        }
        public ProductRuleBL(IRepo<int, Product> repo)
        {
            _repo = repo;   
        }
        public List<Product> GetAll()
        {
            return _repo.GetAll().ToList();
        }
        public Product Add(Product product)
        {
            return _repo.Add(product);
        }
    }
}