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
        public void Update(Supplier supplier)
        {
            if(supplier != null)
            {
                Supplier editSupplier = db.Supplier.Find(supplier.SupplierID);

                if(supplier.SupplierID != null)
                    editSupplier.SupplierID = supplier.SupplierID;
                if (supplier.CompanyName != null)
                    editSupplier.CompanyName = supplier.CompanyName;
                if (supplier.Adress != null)
                    editSupplier.Adress = supplier.Adress;
                if (supplier.NIP != null)
                    editSupplier.NIP = supplier.NIP;
                if (supplier.PhoneNumber != null)
                    editSupplier.PhoneNumber = supplier.PhoneNumber;
                if (supplier.BankName != null)
                    editSupplier.BankName = supplier.BankName;
                if (supplier.BankAccountNumber != null)
                    editSupplier.BankAccountNumber = supplier.BankAccountNumber;
            }

            db.SaveChanges();
        }
        public List<Supplier> FindAll()
        {
            return db.Supplier.ToList();
        }
        public Supplier FindOne(int id)
        {
            return db.Supplier.Find(id);
        }

    }
}
