using Praktika_Lichni_dnevnik.DB;
using System;
using System.Collections.Generic;
using System.Data.Common;
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

namespace Praktika_Lichni_dnevnik.Pages
{
    /// <summary>
    /// Логика взаимодействия для Obzor_zapis.xaml
    /// </summary>
    public partial class Obzor_zapis : Page
    {
        public static List<Record> records { get; set; }
        public static List<Mood> moods { get; set; }

        public static User user2;
        public Obzor_zapis(User user1)
        {
            InitializeComponent();
            oobzor_list.ItemsSource = Praktika_Lichni_dnevnik.DB.DbConnection.PrLd_DBEntities.Record.ToList();
            user2 = user1;

            records = Praktika_Lichni_dnevnik.DB.DbConnection.PrLd_DBEntities.Record.ToList();

            records = new List<Record>
                (Praktika_Lichni_dnevnik.DB.DbConnection.PrLd_DBEntities.Record.ToList());

            moods = new List<Mood>
                (Praktika_Lichni_dnevnik.DB.DbConnection.PrLd_DBEntities.Mood.ToList());
            this.DataContext = this;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            var sorting = sorting_cb.Text;


            if (sorting == "Сначала новые")
            {
                records = Praktika_Lichni_dnevnik.DB.DbConnection.PrLd_DBEntities.Record.OrderByDescending(x => x.ID_record).ToList();
                this.DataContext = this;
            }
            else
            {
                records = Praktika_Lichni_dnevnik.DB.DbConnection.PrLd_DBEntities.Record.OrderBy(x => x.ID_record).ToList();
                this.DataContext = this;
            }

            oobzor_list.ItemsSource = records;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            var poisk = poisk_cb.Text;
            records = records.Where(x => x.Description_record == poisk).ToList();
            oobzor_list.ItemsSource = records;
        }
    }
}
