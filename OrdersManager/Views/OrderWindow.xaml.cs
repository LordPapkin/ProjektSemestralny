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

        public event Action RefreshOrder;

        public OrderWindow()
        {
            InitializeComponent();
            PrepareComboBoxes();
        }

        private void btnAddOrder_Click(object sender, RoutedEventArgs e)
        {
            if (Save())
            {
                this.Close();
            }
        }

        private bool Save()
        {
            if (Validation())
            {
                var supplierId = comboBoxSupplier.SelectedItem as Supplier;
                var customerId = comboBoxCustomer.SelectedItem as Customer;
                var productId = comboBoxProduct.SelectedItem as Product;
                Order order = new Order()
                {
                    SupplierID = supplierId.SupplierID,
                    CustomerID = customerId.CustomerID,
                    ProductID = productId.ProductID,
                    IsPay = Convert.ToByte(checkBoxOrderPaid.IsChecked.Value),
                    OrderDate = datePickerOrderDate.SelectedDate.Value
                };

                orderService.Save(order);
                return true;
            }
            return false;
        }
        private bool Validation()
        {
            if(comboBoxCustomer.SelectedItem == null)
            {
                if (MessageBox.Show("Select customer!", "Customer", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (comboBoxSupplier.SelectedItem == null)
            {
                if (MessageBox.Show("Select supplier!", "Supplier", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (comboBoxProduct.SelectedItem == null)
            {
                if (MessageBox.Show("Select product!", "Product", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (checkBoxOrderPaid.IsChecked != true)
            {
                if (MessageBox.Show("Chceck checkbox!", "Płatność", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }            
            if(datePickerOrderDate.SelectedDate == null)
            {
                if (MessageBox.Show("No date!", "DATA", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if(datePickerOrderDate.SelectedDate < DateTime.Today)
            {
                if (MessageBox.Show("Wrong date!", "DATA", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            return true;
        }
        private void PrepareComboBoxes()
        {
            comboBoxCustomer.ItemsSource = customerService.FindAll();
            comboBoxSupplier.ItemsSource = supplierService.FindAll();
            comboBoxProduct.ItemsSource = productService.FindAll();
        }

        private void comboBoxCustomer_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItemCustomer = comboBoxCustomer.SelectedItem as Customer;
            if(selectedItemCustomer != null)
            {
                textBoxCustomerAdress.Text = selectedItemCustomer.Adress;
                textBoxCustomerNIP.Text = selectedItemCustomer.NIP;
                textBoxCustomerPhoneNumber.Text = selectedItemCustomer.PhoneNumber;
                textBoxCustomerBankName.Text = selectedItemCustomer.BankName;
                textBoxCustomerBankAccountNumber.Text = selectedItemCustomer.BankAccountNumber;
            }
        }

        private void comboBoxSupplier_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItemSupplier = comboBoxSupplier.SelectedItem as Supplier;
            if(selectedItemSupplier != null)
            {
                textBoxSupplierAdress.Text = selectedItemSupplier.Adress;
                textBoxSupplierNIP.Text = selectedItemSupplier.NIP;
                textBoxSupplierPhoneNumber.Text = selectedItemSupplier.PhoneNumber;
                textBoxSupplierBankName.Text = selectedItemSupplier.BankName;
                textBoxSupplierBankAccountNumber.Text = selectedItemSupplier.BankAccountNumber;
            }
        }

        private void comboBoxProduct_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            var selectedItemProduct = comboBoxProduct.SelectedItem as Product;
            if(selectedItemProduct != null)
            {
                textBoxProductPriceNetto.Text = selectedItemProduct.PriceNetto.ToString();
                textBoxProductVat.Text = selectedItemProduct.VAT.ToString();
            }
        }
    }
}
