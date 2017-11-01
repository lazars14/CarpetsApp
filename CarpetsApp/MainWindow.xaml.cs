using CarpetsApp.dao;
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
        public BillMaxHelper billMaxHelper = new BillMaxHelper();


        public MainWindow()
        {
            InitializeComponent();

            now();

            setupHeader();
            setupWindow();
        }

        private void now()
        {
            billMaxHelper.fillCompanyBills();

            CarpetHelper carpetHelper = new CarpetHelper();
            carpetHelper.setCarpetsForItems();
        }

        private void setupWindow()
        {
            /*Companies = CollectionViewSource.GetDefaultView(ApplicationA.Instance.Companies);
            companies_dg.ItemsSource = Companies;
            companies_dg.IsSynchronizedWithCurrentItem = true;*/

            DateTime today = DateTime.Today;

            List<int> years = new List<int> { today.Year - 1, today.Year, today.Year + 1 };

            List<String> months = new List<string> {"Januar", "Februar", "Mart", "April", "Maj", "Jun", "Jul",
            "Avgust", "Septembar", "Oktobar", "Novembar", "Decembar"};

            year_cb.ItemsSource = years;
            year_cb.SelectedIndex = 1;

            month_cb.ItemsSource = months;
            month_cb.SelectedIndex = today.Month - 1;
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

            companies_dg.IsSynchronizedWithCurrentItem = true;
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
            PrintHelper.printExcelDoc();
        }

        private void book_and_print_btn_Click(object sender, RoutedEventArgs e)
        {
            if(companies_dg.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate da oznacite neku kompaniju!");
            }
            else
            {
                bool valid = false;

                DateTime traffic_month_and_year = new DateTime((int)year_cb.SelectedValue, month_cb.SelectedIndex + 1, 1);

                if (!date_cal.SelectedDate.HasValue)
                {
                    date_cal.SelectedDate = DateTime.Today;
                }

                DateTime bill_date = date_cal.SelectedDate.Value;

                foreach (Company c in companies_dg.SelectedItems)
                {
                    Bill newBill = (Bill) c.Bill.Clone();
                    newBill.BillDate = bill_date;
                    newBill.BillNumForYear = BillMaxHelper.findMaxBillNumForYear(traffic_month_and_year.Year) + 1;
                    newBill.TrafficMonth = MonthHelper.getMonthFromInt(traffic_month_and_year.Month);
                    newBill.TrafficYear = traffic_month_and_year.Year;
                    newBill.Id = ApplicationA.Instance.Bills[ApplicationA.Instance.Bills.Count - 1].Id + 1;

                    valid = BillDao.Add(newBill);
                    if (valid)
                    {
                        ApplicationA.Instance.Bills.Add(newBill);
                        c.Bill = newBill;
                        ApplicationA.WriteToLogActions(newBill.Id, "racun");
                    }

                    foreach(Billitem item in newBill.Items)
                    {
                        valid = BillitemDao.Add(item, newBill);
                        if (valid)
                        {
                            item.Id = BillMaxHelper.findMaxBillItemId(newBill);
                            ApplicationA.WriteToLogActions(item.Id, "stavka racuna");
                        }
                    }

                }

            }
        }

        private void print_bill_button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
