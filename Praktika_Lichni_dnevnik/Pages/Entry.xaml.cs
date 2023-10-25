using Praktika_Lichni_dnevnik.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
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

namespace Praktika_Lichni_dnevnik.Pages
{
    /// <summary>
    /// Логика взаимодействия для Entry.xaml
    /// </summary>
    public partial class Entry : Page
    {
        public static List<User> entry { get; set; }

        public Entry()
        {
            InitializeComponent();
        }

        private void login_Btn_Click(object sender, RoutedEventArgs e)
        {
            string login = Convert.ToString(login_Tb.Text.Trim());
            string password = Convert.ToString(password_Tb.Password.Trim());

            var users = DbConnection.PrLd_DBEntities.User.ToList();
            var user = users.FirstOrDefault(i => i.Login_user == login && i.Password_user == password);
            if (user != null)
                NavigationService.Navigate(new Record_z(user));
            else
                MessageBox.Show("Введенные данные некорректны!");
        }
    }
}
