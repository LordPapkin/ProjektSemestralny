﻿using OrdersManager.Views;
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

namespace OrdersManager
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        OrdersEntities db = new OrdersEntities();
        public MainWindow()
        {            
            InitializeComponent();
            orderGridControl.ItemsSource = db.Order.ToList();
            customerGridControl.ItemsSource = db.Customer.ToList();
            supplierGridControl.ItemsSource = db.Supplier.ToList();
            productGridControl.ItemsSource = db.Product.ToList();
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
            orderGridControl.ItemsSource = db.Order.ToList();
            orderGridControl.Items.Refresh();
        }
        private void btnRefreshCustomer_Click(object sender, RoutedEventArgs e)
        {
            customerGridControl.ItemsSource = db.Customer.ToList();
            customerGridControl.Items.Refresh();
        }

        private void btnRefreshSupplier_Click(object sender, RoutedEventArgs e)
        {
            supplierGridControl.ItemsSource = db.Supplier.ToList();
            supplierGridControl.Items.Refresh();
        }

        private void btnRefreshProduct_Click(object sender, RoutedEventArgs e)
        {
            productGridControl.ItemsSource = db.Product.ToList();
            productGridControl.Items.Refresh();
        }



        private void orderGridControl_MouseDoubleClick(object sender, MouseButtonEventArgs e)
        {
            var selectedItem = orderGridControl.SelectedItem as Order;

            OrderModel model = new OrderModel()
            {
                OrderID = selectedItem.OrderID,
                CustomerID = selectedItem.CustomerID,
                SupplierID = selectedItem.SupplierID,
                ProductID = selectedItem.ProductID,
                IsPaid = selectedItem.IsPay,
                OrderDate = selectedItem.OrderDate
            };

            OrderUpdateWindow orderUpdateWindow = new OrderUpdateWindow(model);
            orderUpdateWindow.ShowDialog();
        }

       
    }
}
