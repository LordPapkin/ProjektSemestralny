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
        public void Update(Product product)
        {
            if(product != null)
            {
                Product editProduct = db.Product.Find(product.ProductID);

                if(product.ProductID != null)
                    editProduct.ProductID = product.ProductID;
                if(product.Name != null)
                    editProduct.Name = product.Name;
                if (product.PriceNetto != null)
                    editProduct.PriceNetto = product.PriceNetto;
                if (product.VAT != null)
                    editProduct.VAT = product.VAT;
                if(product.PriceBrutto != null)
                    editProduct.PriceBrutto = product.PriceBrutto;
            }

            db.SaveChanges();
        }
        public List<Product> FindAll()
        {
            return db.Product.ToList();
        }

        public Product FindOne(int id)
        {
            return db.Product.Find(id);
        }
    }
}
