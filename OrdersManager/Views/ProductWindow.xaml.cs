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
    /// Interaction logic for ProductWindow.xaml
    /// </summary>
    public partial class ProductWindow : Window
    {
        ProductService productService = new ProductService();
        UtilityService utilityService = new UtilityService();
        public ProductWindow()
        {
            InitializeComponent();
        }
        private decimal tempPriceNetto;
        private double tempVat;

        private bool Save()
        {
            if (Validation())
            {
                tempPriceNetto = Convert.ToDecimal(textBoxPriceNetto.Text);
                tempVat = Convert.ToDouble(textBoxVat.Text) / 100f;
                Product product = new Product()
                {
                    Name = textBoxName.Text,
                    PriceNetto = tempPriceNetto,
                    VAT = tempVat,
                    PriceBrutto = (tempPriceNetto * (decimal)tempVat) + tempPriceNetto
                };

                productService.Save(product);
                return true;
            }
            return false;
        }
        private bool Validation()
        {
            if (String.IsNullOrEmpty(textBoxName.Text))
            {
                if (MessageBox.Show("No name!", "Name", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }

            if (String.IsNullOrEmpty(textBoxPriceNetto.Text))
            {
                if (MessageBox.Show("No price!", "Price", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (!utilityService.IsDigitsOnly(textBoxPriceNetto.Text))
            {
                if (MessageBox.Show("Price contains only digits. Enter correct data!", "Price", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }

            if (String.IsNullOrEmpty(textBoxVat.Text))
            {
                if (MessageBox.Show("No VAT!", "VAT", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (!utilityService.IsDigitsOnly(textBoxVat.Text))
            {
                if (MessageBox.Show("VAT contains only digits. Enter correct data!", "VAT", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            if (textBoxVat.Text == "23" || textBoxVat.Text == "8" || textBoxVat.Text == "5" || textBoxVat.Text == "0")
            {
                return true;
            }
            else
            {
                if (MessageBox.Show("VAT value can be only 23/8/5/0", "VAT", MessageBoxButton.OK, MessageBoxImage.Warning) == MessageBoxResult.OK)
                    return false;
            }
            return true;
        }
        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            if (Save())
            {
                this.Close();
            }
        }

       
    }
}
