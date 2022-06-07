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
        public ProductWindow()
        {
            InitializeComponent();
        }
        private decimal tempPriceNetto;
        private double tempVat;

        private void Save()
        {
            tempPriceNetto = Convert.ToDecimal(textBoxPriceNetto.Text);
            tempVat = Convert.ToDouble(textBoxVat.Text)/100f;
            Product product = new Product()
            {                     
                Name = textBoxName.Text,
                PriceNetto = tempPriceNetto,
                VAT = tempVat,
                PriceBrutto = (tempPriceNetto * (decimal)tempVat) + tempPriceNetto
            };
            
            productService.Save(product);
        }

        private void btnAddProduct_Click(object sender, RoutedEventArgs e)
        {
            Save();
            this.Close();
        }

       
    }
}
