//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace OrdersManager.DataBase
{
    using System;
    using System.Collections.Generic;
    
    public partial class Supplier
    {
        public Supplier()
        {
            this.Order = new HashSet<Order>();
        }
    
        public int SupplierID { get; set; }
        public string CompanyName { get; set; }
        public string Adress { get; set; }
        public string NIP { get; set; }
        public string PhoneNumber { get; set; }
        public string BankName { get; set; }
        public string BankAccountNumber { get; set; }
    
        public virtual ICollection<Order> Order { get; set; }
    }
}