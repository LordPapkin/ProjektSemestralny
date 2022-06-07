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
    /// Interaction logic for OrderWindow.xaml
    /// </summary>
    public partial class OrderWindow : Window
    {
        CustomerService customerService = new CustomerService();
        SupplierService supplierService = new SupplierService();
        ProductService productService = new ProductService();
        OrderService orderService = new OrderService();

        public OrderWindow()
        {
            InitializeComponent();
            PrepareComboBoxes();
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {

        }

        private void PrepareComboBoxes()
        {
            comboBoxCustomer.ItemsSource = customerService.FindAll();
            comboBoxSupplier.ItemsSource = supplierService.FindAll();
            comboBoxProduct.ItemsSource = productService.FindAll();
        }

        private void comboBoxCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItem = comboBoxCustomer.SelectedItem as Customer;
            if(selectedItem != null)
            {
                textBoxCustomerAdress.Text = selectedItem.Adress;
                textBoxCustomerNIP.Text = selectedItem.NIP;
                textBoxCustomerPhoneNumber.Text = selectedItem.PhoneNumber;
                textBoxCustomerBankName.Text = selectedItem.BankName;
                textBoxCustomerBankAccountNumber.Text = selectedItem.BankAccountNumber;
            }
        }
    }
}
