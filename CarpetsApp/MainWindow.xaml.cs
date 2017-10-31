using CarpetsApp.helpers;
using CarpetsApp.model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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

namespace CarpetsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public ICollectionView Companies { get; set; }

        public MainWindow()
        {
            InitializeComponent();

            now();

            setupHeader();
            //setupWindow();
        }

        private void now()
        {
            BillMaxHelper billMaxHelper = new BillMaxHelper();
            billMaxHelper.fillCompanyBills();

            CarpetHelper carpetHelper = new CarpetHelper();
            carpetHelper.setCarpetsForItems();
        }

        private void setupWindow()
        {
            Companies = CollectionViewSource.GetDefaultView(ApplicationA.Instance.Companies);
            companies_dg.ItemsSource = Companies;
            companies_dg.IsSynchronizedWithCurrentItem = true;
        }

        private void setupHeader()
        {
            List<String> headers = new List<string> {"Id", "Zona", "Naziv", "PIB", "Adresa", "Grad", "Kontakt osoba",
                "Kontakt telefon", "Datum potpisivanja", "Nesigurno", "Kompenzacija", "Broj zamena", "Broj tepiha",
                "Broj lokacija", "Poslednji racun"
            };
            List<String> bindings = new List<string> {"Id", "Zone", "Name", "Pib", "Address", "City", "ContactPerson",
            "PhoneNumber", "SigningDate", "Insecure", "Compensation", "NumReplacements", "NumCarpets", "NumLocations",
            "Bill.BillNumForYear"};

            DataGridTextColumn column = new DataGridTextColumn();

            for(int i = 0; i < headers.Count; i++)
            {
                column = new DataGridTextColumn();
                column.Header = headers[i];
                column.Binding = new Binding(bindings[i]);
                companies_dg.Columns.Add(column);
            }

            
            foreach (object c in ApplicationA.Instance.Companies)
            {
                companies_dg.Items.Add(c);
            }
        }

        private void setupData()
        {

        }

        private void mark_all_btn_Click(object sender, RoutedEventArgs e)
        {
            companies_dg.SelectAll();
        }

        private void mark_none_btn_Click(object sender, RoutedEventArgs e)
        {
            companies_dg.UnselectAll();
        }

        private void booking_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void book_and_print_btn_Click(object sender, RoutedEventArgs e)
        {

        }

        private void print_bill_button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
