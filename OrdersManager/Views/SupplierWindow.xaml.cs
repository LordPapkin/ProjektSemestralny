using OrdersManager.DataBase;
using OrdersManager.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace OrdersManager.Views
{
    /// <summary>
    /// Interaction logic for SupplierWindow.xaml
    /// </summary>
    public partial class SupplierWindow : Window
    {
        SupplierService supplierService = new SupplierService();
        public SupplierWindow()
        {
            InitializeComponent();
        }
        private void Save()
        {
            Supplier supplier = new Supplier()
            {
                CompanyName = textBoxCompanyName.Text,
                Adress = textBoxAdress.Text,
                NIP = textBoxNIP.Text,
                PhoneNumber = textBoxPhoneNumber.Text,
                BankName = textBoxBankName.Text,
                BankAccountNumber = textBoxBankAccountNumber.Text,
            };

            supplierService.Save(supplier);
        }

        private void btnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            Save();
            this.Close();
        }

        
    }
}
