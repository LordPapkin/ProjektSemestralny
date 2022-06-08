using OrdersManager.DataBase;
using OrdersManager.Models;
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
    /// Interaction logic for SupplierUpdateWindow.xaml
    /// </summary>
    public partial class SupplierUpdateWindow : Window
    {
        SupplierModel _supplierModel;

        SupplierService supplierService = new SupplierService();
        public SupplierUpdateWindow(SupplierModel model)
        {
            InitializeComponent();
            _supplierModel = model;
            PrepareToLoad();
        }
        private void PrepareToLoad()
        {
            var supplier = supplierService.FindOne(_supplierModel.SupplierID);

            textBoxCompanyName.Text = supplier.CompanyName;
            textBoxAdress.Text = supplier.Adress;
            textBoxNIP.Text = supplier.NIP;
            textBoxPhoneNumber.Text = supplier.PhoneNumber;
            textBoxBankName.Text = supplier.BankName;
            textBoxBankAccountNumber.Text = supplier.BankAccountNumber;
        }
        private void Update()
        {
            Supplier supplier = new Supplier()
            {
                SupplierID = _supplierModel.SupplierID,
                CompanyName = textBoxCompanyName.Text,
                Adress = textBoxAdress.Text,
                NIP = textBoxNIP.Text,
                PhoneNumber = textBoxPhoneNumber.Text,
                BankName = textBoxBankName.Text,
                BankAccountNumber = textBoxBankAccountNumber.Text
            };
            supplierService.Update(supplier);
        }

        private void btnUpdateSupplier_Click(object sender, RoutedEventArgs e)
        {
            Update();
            this.Close();
        }
    }
}
