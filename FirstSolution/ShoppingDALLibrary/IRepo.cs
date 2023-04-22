using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShoppingDALLibrary
{
    public interface IRepo<K,T>
    {
        Product Get(K key);
        ICollection<T> GetAll();
        T Edit(T item);
        T Add(T item);
        T Delete(K key);
    }
}
