using OrdersManager.DataBase;
using OrdersManager.Models;
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
        public void Delete(int id)
        {
            Product product = db.Product.Find(id);
            db.Product.Remove(product);
            db.SaveChanges();
        }
        public List<ProductModel> PrepareToShow()
        {
            List<Product> items = db.Product.ToList();
            List<ProductModel> products = new List<ProductModel>();
            foreach (var item in items)
            {
                ProductModel product = new ProductModel()
                {
                    ProductID = item.ProductID,
                    Name = item.Name,
                    PriceNetto = item.PriceNetto,
                    VAT = item.VAT,
                    PriceBrutto = item.PriceBrutto,
                };
                products.Add(product);
            }
            return products;
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
