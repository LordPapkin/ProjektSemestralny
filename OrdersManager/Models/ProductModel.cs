using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OrdersManager.Models
{
    public class ProductModel
    {
        public int ProductID { get; set; }
        public string Name { get; set; }
        public decimal PriceNetto { get; set; }
        public double VAT { get; set; }
        public decimal PriceBrutto { get; set; }
    }
}
