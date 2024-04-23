using PP.Appdata;
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

namespace PP.Page
{
    /// <summary>
    /// Логика взаимодействия для Sklad.xaml
    /// </summary>
    public partial class Sklad
    {
        public Sklad()
        {
            InitializeComponent();
            UpdateLV();
        }
        public void UpdateLV()
        {
            var products = ConDB.GetCont().Склад.ToList();
            string countRows = products.Count.ToString();
            products = products.Where(x => x.name.ToLower().Contains(Search.Text.ToLower())).ToList();
           
            ProductLV.ItemsSource = products;

        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }
    }
}
