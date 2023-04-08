using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public interface IRepo
    {
        Product Get(int id);
        Product[] GetAll();
        Product Edit(Product product);
        Product Add(Product product);
        Product Delete(int id);
    }
}
