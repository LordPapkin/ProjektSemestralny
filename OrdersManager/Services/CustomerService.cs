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
        public void Update(Customer customer)
        {
            if(customer != null)
            {
                Customer editCustomer = db.Customer.Find(customer.CustomerID);

                if(customer.CustomerID != null)
                    editCustomer.CustomerID = customer.CustomerID;
                if(customer.CompanyName != null)
                    editCustomer.CompanyName = customer.CompanyName;
                if (customer.Adress != null)
                    editCustomer.Adress = customer.Adress;
                if (customer.NIP != null)
                    editCustomer.NIP = customer.NIP;
                if(customer.PhoneNumber != null)
                    editCustomer.PhoneNumber = customer.PhoneNumber;
                if (customer.BankName != null)
                    editCustomer.BankName = customer.BankName;
                if(customer.BankAccountNumber != null)
                    editCustomer.BankAccountNumber = customer.BankAccountNumber;
            }

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
