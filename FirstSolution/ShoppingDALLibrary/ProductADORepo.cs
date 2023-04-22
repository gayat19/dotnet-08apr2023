using ShoppingModelLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;

namespace ShoppingDALLibrary
{
    public class ProductADORepo : IRepo<int, Product>
    {
        SqlConnection conn;
        IDictionary<int, Product> products = new Dictionary<int, Product>();    
        public ProductADORepo()
        {
            conn = new SqlConnection(@"Data source=DESKTOP-1C1EU5R\SQLSERVER2019G3;user id=sa;password=P@ssw0rd;Initial catalog=dbProduct22Apr2023");
        }
        public Product Add(Product item)
        {
            SqlCommand cmdInsert = new SqlCommand("proc_InsertProduct", conn);
            cmdInsert.CommandType = System.Data.CommandType.StoredProcedure;
            if (conn.State == System.Data.ConnectionState.Open)
                conn.Close();
            conn.Open();
            cmdInsert.Parameters.AddWithValue("@pname", item.Name);
            cmdInsert.Parameters.AddWithValue("@pprice", item.Price);
            cmdInsert.Parameters.Add("@pid",SqlDbType.Int);
            cmdInsert.Parameters[2].Direction = System.Data.ParameterDirection.Output;
            if(cmdInsert.ExecuteNonQuery()>0) {
                item.Id = Convert.ToInt32(cmdInsert.Parameters[2].Value);
                conn.Close();
                return item;
            }
            conn.Close();
            return null;
        }

        public Product Delete(int key)
        {
            throw new NotImplementedException();
        }

        public Product Edit(Product item)
        {
            throw new NotImplementedException();
        }

        public Product Get(int key)
        {
            throw new NotImplementedException();
        }

        public ICollection<Product> GetAll()
        {
            SqlDataAdapter adapter = new SqlDataAdapter("proc_GetAllProducts",conn);
            adapter.SelectCommand.CommandType = System.Data.CommandType.StoredProcedure;
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            Product product;
            foreach (DataRow item in ds.Tables[0].Rows)
            {
                product = new Product
                {
                    Id = Convert.ToInt32(item["ID"]),
                    Name = item[1].ToString(),
                    Price = Convert.ToSingle(item[2])
                };
                products.Add(product.Id, product);
            }
            if(products.Count > 0) 
                return products.Values.ToList();
            return null;
        }
    }
}
