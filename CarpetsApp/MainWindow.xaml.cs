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
        public BillMaxHelper billMaxHelper = new BillMaxHelper();
        public CarpetHelper carpetHelper = new CarpetHelper();
        public CompaniesGridHelper cgHelper = new CompaniesGridHelper();
        public BusinessLogicHelper businessLogic = new BusinessLogicHelper();

        public MainWindow()
        {
            InitializeComponent();

            setupBillsAndCarpets();
            cgHelper.setupTable(companies_dg);
            setupComboBoxes();
        }

        private void setupBillsAndCarpets()
        {
            billMaxHelper.fillCompanyBills();
            carpetHelper.setCarpetsForItems();
        }

        private void setupComboBoxes()
        {
            List<String> months = new List<string> {"Januar", "Februar", "Mart", "April", "Maj", "Jun", "Jul",
            "Avgust", "Septembar", "Oktobar", "Novembar", "Decembar"};

            DateTime today = DateTime.Today;

            List<int> years = new List<int> { today.Year - 1, today.Year, today.Year + 1 };

            year_cb.ItemsSource = years;
            year_cb.SelectedIndex = 1;

            month_cb.ItemsSource = months;
            month_cb.SelectedIndex = today.Month - 1;
        }

        private void mark_all_btn_Click(object sender, RoutedEventArgs e)
        {
            companies_dg.SelectAll();
        }

        private void mark_none_btn_Click(object sender, RoutedEventArgs e)
        {
            companies_dg.UnselectAll();
        }

        private void book_and_print_btn_Click(object sender, RoutedEventArgs e)
        {
            if(companies_dg.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate da oznacite neku kompaniju!");
            }
            else
            {
                DateTime traffic_month_and_year = new DateTime((int)year_cb.SelectedValue, month_cb.SelectedIndex + 1, 1);

                if (!date_cal.SelectedDate.HasValue)
                {
                    date_cal.SelectedDate = DateTime.Today;
                }

                DateTime bill_date = date_cal.SelectedDate.Value;

                bool print = false;

                Button btn = (Button)sender;
                string btn_name = btn.Name;

                if (btn_name == "book_and_print_btn")
                {
                    print = true;
                }

                bool good = businessLogic.createBills(companies_dg, bill_date, traffic_month_and_year, print);

                // to do
            }
        }
    }
}
