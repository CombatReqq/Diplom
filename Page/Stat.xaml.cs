using PP.Appdata;
using System;
using PP;
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
    /// Логика взаимодействия для Stat.xaml
    /// </summary>
    public partial class Stat 
    {
        public Stat()
        {
            InitializeComponent();
            using (var context = ConDB.GetCont())
            {
                var sessions = context.session.ToList();
                sessionDataGrid.ItemsSource = sessions;
            }
        }
    }
}
