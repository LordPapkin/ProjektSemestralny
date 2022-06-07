using OrdersManager.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Services
{
    public class SupplierService
    {
        OrdersEntities db = new OrdersEntities();
        public void Save(Supplier supplier)
        {
            db.Supplier.Add(supplier);
            db.SaveChanges();
        }

        public List<Supplier> FindAll()
        {
            return db.Supplier.ToList();
        }

    }
}
