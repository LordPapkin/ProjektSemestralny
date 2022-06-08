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
        private void Update()
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
        }
        private void btnUpdateCustomer_Click(object sender, RoutedEventArgs e)
        {
            Update();
            this.Close();
        }
    }
}
