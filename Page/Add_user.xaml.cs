using PP;
using PP.Appdata;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
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
    
    public partial class Add_user
    {
        public Add_user()
        {
            InitializeComponent();
        }

        private void AddUserButton_Click(object sender, RoutedEventArgs e)
        {
             using (var context = ConDB.GetCont())
    {
        var user = new user
        {
            id_user = Convert.ToInt16(idTextBox.Text),
            username = UsernameTextBox.Text,
            password = PasswordTextBox.Text,
            FIO = FIOTextBox.Text,
            role = RoleComboBox.SelectedItem.ToString()
        };

        context.user.Add(user);
        context.SaveChanges();
    }
        }
    }

 
}



