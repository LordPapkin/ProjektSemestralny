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
    /// Interaction logic for ProductUpdateWindow.xaml
    /// </summary>
    public partial class ProductUpdateWindow : Window
    {
        ProductModel _productModel;

        ProductService productService = new ProductService();

        public ProductUpdateWindow(ProductModel model)
        {
            InitializeComponent();
            _productModel = model;
            PrepareToLoad();
        }

        private decimal tempPriceNetto;
        private double tempVat;

        private void PrepareToLoad()
        {
            var product = productService.FindOne(_productModel.ProductID);

            textBoxName.Text = product.Name;
            textBoxPriceNetto.Text = product.PriceNetto.ToString();
            textBoxVat.Text = product.VAT.ToString();
        }

        private void Update()
        {
            tempPriceNetto = Convert.ToDecimal(textBoxPriceNetto.Text);
            tempVat = Convert.ToDouble(textBoxVat.Text) / 100f;
            Product product = new Product()
            {
                ProductID = _productModel.ProductID,
                Name = textBoxName.Text,
                PriceNetto = tempPriceNetto,
                VAT = tempVat,
                PriceBrutto = (tempPriceNetto * (decimal)tempVat) + tempPriceNetto
            };
            productService.Update(product); 
        }

        private void btnUpdateProduct_Click(object sender, RoutedEventArgs e)
        {
            Update();
            this.Close();
        }
    }
}
