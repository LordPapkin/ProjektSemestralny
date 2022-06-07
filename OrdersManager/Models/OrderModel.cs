using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Models
{
    public class OrderModel
    {
        public int OrderID { get; set; }
        public int CustomerID { get; set; }
        public int SupplierID { get; set; }
        public int ProductID { get; set; }        
        public byte IsPaid { get; set; }
        public DateTime OrderDate { get; set; }
    }
}
