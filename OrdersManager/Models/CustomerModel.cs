using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Models
{
    public class CustomerModel
    {
        public int CustomerID { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string NIP { get; set; }
        public string PhoneNumber { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
    }
}
