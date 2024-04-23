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
    /// Логика взаимодействия для Autoris.xaml
    /// </summary>
    public partial class Autoris
    {
        public Autoris()
        {
            InitializeComponent();
        }
      
        private void Log_BTN(object sender, RoutedEventArgs e)
        {
            if (ConDB.GetCont().user.Any(x => x.username == Login.Text && x.password == passwordBox.Password))
            {

                Log.curUser = ConDB.GetCont().user.FirstOrDefault(x => x.username == Login.Text && x.password == passwordBox.Password);
                Log.timeStart = DateTime.Now;
                Log.isLoggedIn = true;
                Log.userId = ConDB.GetCont().user.FirstOrDefault(x => x.username == Login.Text && x.password == passwordBox.Password)?.id_user ?? 0;
                Nav.MFrame.Navigate(new Page.Glav());

            }
            else
            {
                errorMessage.Visibility = Visibility.Visible;
                MessageBox.Show("Неверный логин или пароль");
            }
        }
    }
}
