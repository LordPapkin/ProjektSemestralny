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
        UtilityService utilityService = new UtilityService();
        public SupplierWindow()
        {
            InitializeComponent();
        }
        private bool Save()
        {
            if (Validation())
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
                return true;
            }
            return false;
            
        }
        private bool Validation()
        {
            if (String.IsNullOrEmpty(textBoxCompanyName.Text))
            {
                if (MessageBox.Show("No name!", "Company Name", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }

            if (String.IsNullOrEmpty(textBoxAdress.Text))
            {
                if (MessageBox.Show("No adress!", "Adress", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }

            if (String.IsNullOrEmpty(textBoxNIP.Text))
            {
                if (MessageBox.Show("No NIP!", "NIP", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (!utilityService.IsDigitsOnly(textBoxNIP.Text))
            {
                if (MessageBox.Show("NIP contains 10 digits. Enter correct data!", "NIP", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (textBoxNIP.Text.Length != 10)
            {
                if (MessageBox.Show("NIP contains 10 digits. Enter correct data!", "NIP", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }

            if (String.IsNullOrEmpty(textBoxPhoneNumber.Text))
            {
                if (MessageBox.Show("No Phone Number!", "Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (!utilityService.IsDigitsOnly(textBoxPhoneNumber.Text))
            {
                if (MessageBox.Show("Phone number contains 9 digits. Enter correct data!", "Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (textBoxPhoneNumber.Text.Length != 9)
            {
                if (MessageBox.Show("Phone number contains 9 digits. Enter correct data!", "Phone Number", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }

            if (String.IsNullOrEmpty(textBoxBankName.Text))
            {
                if (MessageBox.Show("No Bank Name!", "Bank Account", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }

            if (String.IsNullOrEmpty(textBoxBankAccountNumber.Text))
            {
                if (MessageBox.Show("No Bank Account Number!", "Bank Account", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (!utilityService.IsDigitsOnly(textBoxBankAccountNumber.Text))
            {
                if (MessageBox.Show("Bank Account contains 26 digits. Enter correct data!", "Bank Account", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (textBoxBankAccountNumber.Text.Length != 26)
            {
                if (MessageBox.Show("Bank Account contains 26 digits. Enter correct data!", "Bank Account", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }

            return true;
        }

        private void btnAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            if (Save())
            {
                this.Close();
            }
        }

        
    }
}
