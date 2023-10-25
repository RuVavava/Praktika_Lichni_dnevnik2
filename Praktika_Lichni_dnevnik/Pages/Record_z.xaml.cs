using Microsoft.Win32;
using Praktika_Lichni_dnevnik.DB;
using System;
using System.IO;
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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Praktika_Lichni_dnevnik.Pages
{
    /// <summary>
    /// Логика взаимодействия для Record.xaml
    /// </summary>
    public partial class Record_z : Page
    {
        public static List<Mood> moods { get; set; }

        public static User user1;

        public Record_z(User user)
        {
            InitializeComponent();
            user1 = user;

            moods = new List<Mood>
                (Praktika_Lichni_dnevnik.DB.DbConnection.PrLd_DBEntities.Mood.ToList());
            this.DataContext = this;
        }

        private void Dobavit_photo(object sender, RoutedEventArgs e)
        {
            Record record = new Record();

            OpenFileDialog openFileDialog = new OpenFileDialog()
            {
                Filter = "*.png|*.png|*.jpg|*.jpg|*.jpeg|*.jpeg"
            };

            if (openFileDialog.ShowDialog().GetValueOrDefault())
            {
                record.Img_record = File.ReadAllBytes(openFileDialog.FileName);

                var m = vibor_mood.SelectedItem as Mood;
                record.ID_mood = m.ID_mood;
                record.Date_record = Convert.ToDateTime(vibor_date.Text.Trim());
                record.ID_user = user1.ID_user;
                record.Description_record = vibor_text.Text.Trim();
                PhotoImage.Source = new BitmapImage(new Uri(openFileDialog.FileName));

                DbConnection.PrLd_DBEntities.Record.Add(record);
                DbConnection.PrLd_DBEntities.SaveChanges();
                NavigationService.Navigate(new Obzor_zapis(user1));

            }
            else
                MessageBox.Show("Не вышло");
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
                NavigationService.Navigate(new Obzor_zapis(user1));
        }
    }
}
