using PP.Appdata;
using PP.Page;
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

namespace PP
{

    
    public partial class MainWindow : Window
    {
       
        public MainWindow()
        {
                InitializeComponent();
                Appdata.Nav.MFrame = MainFrame;
                Appdata.Nav.MFrame.Navigated += MFrame_Navigated; // Add this line
                Appdata.Nav.MFrame.Navigate(new Page.Autoris());
              
            
        }
        private void MFrame_Navigated(object sender, NavigationEventArgs e)
        {
            if (MainFrame.Content is Page.Autoris)
            {
                Manual.Visibility = Visibility.Collapsed;
                BackBTN.Visibility = Visibility.Collapsed;
                AddZakazGO.Visibility = Visibility.Collapsed;
                LogOut.Visibility = Visibility.Collapsed;
                SkladGO.Visibility = Visibility.Collapsed;
                ZakazGO.Visibility = Visibility.Collapsed;
                UserStatGO.Visibility = Visibility.Collapsed;
                UserAddGO.Visibility = Visibility.Collapsed;
            }
            else
            {
                Manual.Visibility = Visibility.Visible;
                BackBTN.Visibility = Visibility.Visible;
                AddZakazGO.Visibility = Visibility.Visible;
                LogOut.Visibility = Visibility.Visible;
                SkladGO.Visibility = Visibility.Visible;
                ZakazGO.Visibility = Visibility.Visible;
                UserStatGO.Visibility = Visibility.Visible;
                UserAddGO.Visibility = Visibility.Visible;
            }
        }

        private void Logout(object sender, RoutedEventArgs e)
        {
            Log.timeEnd = DateTime.Now;

            using (var context = ConDB.GetCont())
            {
                context.session.Add(new session
                {
                    id_user = Log.userId,
                    start_session = Log.timeStart,
                    end_session = Log.timeEnd
                });
                context.SaveChanges();
               
            }

            Appdata.Nav.MFrame.Navigate(new Page.Autoris());
        }

        private void Back(object sender, RoutedEventArgs e)
        {
            if (Nav.MFrame.CanGoBack)
            {
                Nav.MFrame.GoBack();
            }
        }

        private void Sprav (object sender, RoutedEventArgs e)
        {
              Appdata.Nav.MFrame.Navigate(new Page.Sprav_Info());
        }

        private void UserStatGO_Click(object sender, RoutedEventArgs e)
        {
            Appdata.Nav.MFrame.Navigate(new Page.Stat());
        }

        private void ZakazGO_Click(object sender, RoutedEventArgs e)
        {
            Appdata.Nav.MFrame.Navigate(new Page.Zakazi());
        }

        private void AddZakazGO_Click(object sender, RoutedEventArgs e)
        {
            var zakaz = new Заказ();
            // Заполнение свойств объекта zakaz
            Appdata.Nav.MFrame.Navigate(new Page.Add_zakaz(zakaz));
        }

        private void SkladGO_Click(object sender, RoutedEventArgs e)
        {
            Appdata.Nav.MFrame.Navigate(new Page.Sklad());
        }

        private void UserAddGO_Click(object sender, RoutedEventArgs e)
        {
            Appdata.Nav.MFrame.Navigate(new Page.Add_user());
        }

        private void Manual_Click(object sender, RoutedEventArgs e)
        {
            Appdata.Nav.MFrame.Navigate(new Page.Sprav_Info());
        }
    }
}
