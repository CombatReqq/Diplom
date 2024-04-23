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
    /// Логика взаимодействия для Add_zakaz.xaml
    /// </summary>
    public partial class Add_zakaz
    {
        Заказ zakaz;
        bool checnullzakaz = false;
        public Add_zakaz(Заказ zakaz)
        {
            InitializeComponent();
            if (zakaz == null)
            {
                zakaz = new Заказ();
                checnullzakaz = true;
            }
            f.SelectedDate = DateTime.Now;


            this.zakaz = zakaz;
            zakaz.date = f.SelectedDate != null ? f.SelectedDate.Value : DateTime.Now;
            DataContext = zakaz;
            FillCategoryComboBox();
        }
        private void FillCategoryComboBox()
        {


            var companies = ConDB.GetCont().Клиенты.ToList();


            categoryComboBox.Items.Clear();


            foreach (var company in companies)
            {
                categoryComboBox.Items.Add(new ComboBoxItem { Content = company.name, Tag = company.id_клиента });
            }

        }

        private void backbtn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void SaveBtm_Click(object sender, RoutedEventArgs e)
        {
            zakaz.date = f.SelectedDate != null && f.SelectedDate != DateTime.MinValue ? f.SelectedDate.Value : DateTime.Now;
            DataContext = zakaz;

            if (checnullzakaz) ConDB.GetCont().Заказ.Add(zakaz);
            ComboBoxItem selectedCategoryItem = (ComboBoxItem)categoryComboBox.SelectedItem;
            int selectedCategoryId = (int)selectedCategoryItem.Tag;


            zakaz.id_клиента = selectedCategoryId;

            try
            {
                ConDB.GetCont().SaveChanges();
                MessageBox.Show("Данные сохранены");
                Appdata.Nav.MFrame.Navigate(new Page.Zakazi());
            }
            catch
            {
                MessageBox.Show("Ошибка сохранения", "", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}