using OrdersManager.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Services
{
    public class ProductService
    {
        OrdersEntities db = new OrdersEntities();
        public void Save(Product product)
        {
            db.Product.Add(product);
            db.SaveChanges();
        }

        public List<Product> FindAll()
        {
            return db.Product.ToList();
        }
    }
}
