using OrdersManager.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Services
{
    public class OrderService
    {
        OrdersEntities db = new OrdersEntities();
        public void Save(Order order)
        {
            db.Order.Add(order);
            db.SaveChanges();
        }
    }
}
