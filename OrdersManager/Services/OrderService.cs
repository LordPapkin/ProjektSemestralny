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
        public void Update(Order order)
        {
            if(order != null)
            {
                Order editOrder = db.Order.Find(order.OrderID);

                if (order.CustomerID != null)
                    editOrder.CustomerID = order.CustomerID;
                if (order.SupplierID != null)
                    editOrder.SupplierID = order.SupplierID;
                if (order.ProductID != null)
                    editOrder.ProductID = order.ProductID;
                if (order.IsPay != null)
                    editOrder.IsPay = order.IsPay;
                if (order.OrderDate != null)
                    editOrder.OrderDate = order.OrderDate;
            }            

            db.SaveChanges();
        }      
        public void Remove()
        {

        }
    }
}
