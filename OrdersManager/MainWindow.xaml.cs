using OrdersManager.Views;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using OrdersManager.DataBase;
using OrdersManager.Models;
using OrdersManager.Services;

namespace OrdersManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OrdersEntities db = new OrdersEntities();

        CustomerService customerService = new CustomerService();
        SupplierService supplierService = new SupplierService();
        ProductService productService = new ProductService();
        OrderService orderService = new OrderService();        

        public MainWindow()
        {            
            InitializeComponent();
            orderGridControl.ItemsSource = orderService.PrepareDataToShow();
            customerGridControl.ItemsSource = customerService.PrepareDataToShow();
            supplierGridControl.ItemsSource = supplierService.PrepareDataToShow();
            productGridControl.ItemsSource = productService.PrepareToShow();           
        }       

        private void RefreshCustomer()
        {
            customerGridControl.ItemsSource = customerService.PrepareDataToShow();
            customerGridControl.Items.Refresh();
        }
        private void RefreshSupplier()
        {
            supplierGridControl.ItemsSource = supplierService.PrepareDataToShow();
            supplierGridControl.Items.Refresh();
        }
        private void RefreshProduct()
        {
            productGridControl.ItemsSource = productService.PrepareToShow();
            productGridControl.Items.Refresh();
        }
        private void RefreshOrder()
        {
            orderGridControl.ItemsSource = orderService.PrepareDataToShow();
            orderGridControl.Items.Refresh();
        }



        private void btnOpenAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow customerWindow = new CustomerWindow();
            customerWindow.ShowDialog();
        }

        private void btnOpenAddSupplier_Click(object sender, RoutedEventArgs e)
        {
            SupplierWindow supplierWindow = new SupplierWindow();
            supplierWindow.ShowDialog();
        }
        private void btnOpenAddProduct_Click(object sender, RoutedEventArgs e)
        {
            ProductWindow productWindow = new ProductWindow();
            productWindow.ShowDialog();
        }
        private void btnOpenAddOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.ShowDialog();
        }  




        private void btnRefreshOrder_Click(object sender, RoutedEventArgs e)
        {
            RefreshOrder();
        }
        private void btnRefreshCustomer_Click(object sender, RoutedEventArgs e)
        {
            RefreshCustomer();
        }
        private void btnRefreshSupplier_Click(object sender, RoutedEventArgs e)
        {
            RefreshSupplier();
        }
        private void btnRefreshProduct_Click(object sender, RoutedEventArgs e)
        {
            RefreshProduct();
        }



        private void orderGridControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            OrderModel selectedItem = orderGridControl.SelectedItem as OrderModel;
            OrderUpdateWindow orderUpdateWindow = new OrderUpdateWindow(selectedItem);
            orderUpdateWindow.ShowDialog();
        }

        private void customerGridControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            CustomerModel selectedItem = customerGridControl.SelectedItem as CustomerModel;
            CustomerUpdateWindow customerUpdateWindow = new CustomerUpdateWindow(selectedItem);
            customerUpdateWindow.ShowDialog();
        }

        private void supplierGridControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            SupplierModel selectedItem = supplierGridControl.SelectedItem as SupplierModel;
            SupplierUpdateWindow supplierUpdateWindow = new SupplierUpdateWindow(selectedItem);
            supplierUpdateWindow.ShowDialog();
        }

        private void productGridControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            ProductModel selectedItem = productGridControl.SelectedItem as ProductModel;
            ProductUpdateWindow productUpdateWindow = new ProductUpdateWindow(selectedItem);
            productUpdateWindow.ShowDialog();
        }


        private void btnOpenRemoveCustomer_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = customerGridControl.SelectedItem as Customer;

            if(selectedItem != null)
            {
                customerService.Delete(selectedItem.CustomerID); 
                RefreshCustomer();
            }
        }

        private void btnOpenRemoveOrder_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = orderGridControl.SelectedItem as OrderModel;

            if(selectedItem != null)
            {
                orderService.Delete(selectedItem.OrderID);
                RefreshOrder();
            }
        }

        private void btnOpenRemoveSupplier_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = supplierGridControl.SelectedItem as Supplier;

            if(selectedItem != null)
            {
                supplierService.Delete(selectedItem.SupplierID);
                RefreshSupplier();
            }
        }

        private void btnOpenRemoveProduct_Click(object sender, RoutedEventArgs e)
        {
            var selectedItem = productGridControl.SelectedItem as Product;

            if(selectedItem != null)
            {
                productService.Delete(selectedItem.ProductID);
                RefreshProduct();
            }
        }
    }
}
