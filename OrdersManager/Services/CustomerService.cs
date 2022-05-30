﻿using OrdersManager.DataBase;
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
            db.Customers.Add(customer);
            db.SaveChanges();
        }
    }
}
