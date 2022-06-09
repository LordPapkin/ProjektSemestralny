using OrdersManager.DataBase;
using OrdersManager.Models;
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
        public void Delete(int id)
        {
            Supplier supplier = db.Supplier.Find(id);
            db.Supplier.Remove(supplier);
            db.SaveChanges();
        }
        public List<SupplierModel> PrepareDataToShow()
        {
            List<Supplier> items = db.Supplier.ToList();
            List<SupplierModel> suppliers = new List<SupplierModel>();

            foreach (Supplier item in items)
            {
                SupplierModel supplier = new SupplierModel()
                {
                    SupplierID = item.SupplierID,
                    CompanyName = item.CompanyName,
                    Adress = item.Adress,
                    NIP = item.NIP,
                    PhoneNumber = item.PhoneNumber,
                    BankName = item.BankName,
                    BankAccountNumber = item.BankAccountNumber,
                };

                suppliers.Add(supplier);
            }

            return suppliers;
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
