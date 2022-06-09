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
    /// Interaction logic for CustomerUpdateWindow.xaml
    /// </summary>
    public partial class CustomerUpdateWindow : Window
    {
        CustomerModel _customerModel;

        CustomerService customerService = new CustomerService();
        UtilityService utilityService = new UtilityService();

        public CustomerUpdateWindow(CustomerModel model)
        {
            InitializeComponent();
            _customerModel = model;
            PrepareToLoad();
        }
        private void PrepareToLoad()
        {
            var customer = customerService.FindOne(_customerModel.CustomerID);

            textBoxCompanyName.Text = customer.CompanyName;
            textBoxAdress.Text = customer.Adress;
            textBoxNIP.Text = customer.NIP;
            textBoxPhoneNumber.Text = customer.PhoneNumber;
            textBoxBankName.Text = customer.BankName;
            textBoxBankAccountNumber.Text = customer.BankAccountNumber;
        }
        private bool Update()
        {
            if (Validation())
            {
                Customer customer = new Customer()
                {
                    CustomerID = _customerModel.CustomerID,
                    CompanyName = textBoxCompanyName.Text,
                    Adress = textBoxAdress.Text,
                    NIP = textBoxNIP.Text,
                    PhoneNumber = textBoxPhoneNumber.Text,
                    BankName = textBoxBankName.Text,
                    BankAccountNumber = textBoxBankAccountNumber.Text
                };
                customerService.Update(customer);
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
        private void btnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            if (Update())
            {
                this.Close();
            }           
        }
    }
}
