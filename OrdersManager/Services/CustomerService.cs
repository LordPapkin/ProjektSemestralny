using OrdersManager.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Services
{
    public class CustomerService
    {
        OrdersEntities db = new OrdersEntities();
        public void Save(Customer customer)
        {
            db.Customer.Add(customer);
            db.SaveChanges();
        }

        public List<Customer> FindAll()
        {
            return db.Customer.ToList();
        }

        public Customer FindOne(int id)
        {
            return db.Customer.Find(id);
        }
    }
}
