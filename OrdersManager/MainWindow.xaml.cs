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
            customerGridControl.ItemsSource = db.Customers.ToList();
        }

        private void btnOrder_Click(object sender, RoutedEventArgs e)
        {
            OrderWindow orderWindow = new OrderWindow();
            orderWindow.ShowDialog();
        }

        private void btnOpenAddCustomer_Click(object sender, RoutedEventArgs e)
        {
            CustomerWindow customerWindow = new CustomerWindow();
            customerWindow.ShowDialog();
        }

        public void RefreshCustomer()
        {
            customerGridControl.ItemsSource = db.Customers.ToList();
            customerGridControl.Items.Refresh();
        }
    }
}
