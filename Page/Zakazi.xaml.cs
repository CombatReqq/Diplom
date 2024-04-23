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
    /// Логика взаимодействия для Zakazi.xaml
    /// </summary>
    public partial class Zakazi 
    {

        public decimal ResultValue { get; set; }
        public Zakazi()
        {
            InitializeComponent();
            UpdateLV();
            Cmb1.SelectedIndex = 0;
            Cmb2.SelectedIndex = 0;


        }
        public void UpdateLV()
        {
            var post = ConDB.GetCont().Заказ.ToList();
            string countRows = post.Count.ToString();
            var post2 = ConDB.GetCont().Клиенты.ToList();
            post2 = post2.Where(x => x.name.ToLower().Contains(Search.Text.ToLower())).ToList();
            var altServ = ConDB.GetCont().alt_serv.ToList();
            var services = ConDB.GetCont().Services.ToList();
            var altTov = ConDB.GetCont().alt_tov.ToList();
            var sklad = ConDB.GetCont().Склад.ToList();

            // Объединение списков post, post2, altServ, services, altTov и sklad
            var combinedList = post.Join(post2, p => p.id_клиента, p2 => p2.id_клиента, (p, p2) => new { Заказ = p, Клиенты = p2 })
            .Join(altServ, c => c.Заказ.id, a => a.id_zakaz, (c, a) => new { Заказ = c.Заказ, Клиенты = c.Клиенты, alt_serv = a })
            .Join(services, c => c.alt_serv.id_serv, s => s.id, (c, s) => new { Заказ = c.Заказ, Клиенты = c.Клиенты, alt_serv = c.alt_serv, Services = s })
            .Join(altTov, c => c.alt_serv.id_serv, t => t.id_tov, (c, t) => new { Заказ = c.Заказ, Клиенты = c.Клиенты, alt_serv = c.alt_serv, Services = c.Services, alt_tov = t })
            .Join(sklad, c => c.alt_tov.id_tov, s => s.id_tov, (c, s) => new { Заказ = c.Заказ, Клиенты = c.Клиенты, alt_serv = c.alt_serv, Services = c.Services, alt_tov = c.alt_tov, Склад = s });

            if (Cmb1.SelectedIndex == 0)
                combinedList = combinedList.OrderBy(x => x.Заказ.date).ToList();
            else
                combinedList = combinedList.OrderByDescending(x => x.Заказ.date).ToList();

            ProductLV.ItemsSource = combinedList.Select(p => new
            {
                id = p.Заказ.id,
                name = p.Клиенты.name,
                discount = p.Services.discount,
                date = p.Заказ.date,
                ResultValue = p.Services.discount * p.Services.price,
            });



        }

        private void Podrob(object sender, RoutedEventArgs e)
        {

        }

        private void SortCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateLV();
        }

        private void FilterCmb_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            UpdateLV();
        }

        private void Del(object sender, RoutedEventArgs e)
        {
            try
            {
                var delProd = ProductLV.SelectedItems.Cast<dynamic>().ToList();

                if (MessageBox.Show($"Вы точно хотите удалить {delProd.Count} записей", "Внимание!", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
                {
                    foreach (var prod in delProd)
                    {

                        var order = ConDB.GetCont().Заказ.Find(prod.id);
                        if (order != null)
                        {
                            ConDB.GetCont().Заказ.Remove(order);
                        }
                    }


                    ConDB.GetCont().SaveChanges();


                    UpdateLV();

                    MessageBox.Show("Данные удалены");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Up(object sender, RoutedEventArgs e)
        {

        }

        private void Search_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Page_lo(object sender, RoutedEventArgs e)
        {

        }

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {

        }

        private void Otchet_Click(object sender, RoutedEventArgs e)
        {

        }

        private void Editbtn_Click(object sender, RoutedEventArgs e)
        {
            Nav.MFrame.Navigate(new Page.Add_zakaz((sender as Button).DataContext as Заказ));
        }
    }
}
