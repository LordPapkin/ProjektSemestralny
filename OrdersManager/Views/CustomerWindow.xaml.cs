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
    /// Interaction logic for CustomerWindow.xaml
    /// </summary>
    public partial class CustomerWindow : Window
    {
        CustomerService customerService = new CustomerService();
        public CustomerWindow()
        {
            InitializeComponent();
        }

        private void Save()
        {
            Customer customer = new Customer()
            {
                CompanyName = textBoxCompanyName.Text,
                Adress = textBoxAdress.Text,
                NIP = textBoxNIP.Text,
                PhoneNumber = textBoxPhoneNumber.Text,
                BankName = textBoxBankName.Text,
                BankAccountNumber = textBoxBankAccountNumber.Text,
            };

            customerService.Save(customer);
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            Save();
            this.Close();
        }
    }
}
