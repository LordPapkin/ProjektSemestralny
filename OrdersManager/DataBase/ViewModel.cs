using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.Entity;
using System.Linq;

namespace OrdersManager.DataBase
{
    public class ViewModel 
    {
        OrdersEntities dbcontext = new OrdersEntities();




        public List<Customer> Customers { get; set; }



        /*public ObservableCollection<Invoice> Invoices
        {
            get
            {
                return GetValue<ObservableCollection<Invoice>>();
            }

            set
            {
                SetValue(value);
            }
        }
        public ObservableCollection<OurCompany> OurCompanies
        {
            get => GetValue<ObservableCollection<OurCompany>>();
            set => SetValue(value);
        }
        public ObservableCollection<ForeignCompany> ForeignCompanies
        {
            get => GetValue<ObservableCollection<ForeignCompany>>();
            set => SetValue(value);
        }*/



        public ViewModel()
        {
            

           Customers = dbcontext.Customers.ToList();
                
            
        }
    }
}
