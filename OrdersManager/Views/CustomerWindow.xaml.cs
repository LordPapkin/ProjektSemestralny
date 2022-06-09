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

        private bool Save()
        {
            if(Validation() == true)
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
                return true;
            }
            return false;
        }

        private bool Validation()
        {
            if(textBoxPhoneNumber.Text.Length != 9)
            {
                if (MessageBox.Show("Numer musi zawierać 9 znaków", "Numer telefonu", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                {
                    return false;
                }
              
            }

            return true;
        }

        private void btnAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            if(Save() == true)
            {
                this.Close();
            }
            
        }
    }
}
