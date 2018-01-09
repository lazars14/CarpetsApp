using CarpetsApp.dao;
using CarpetsApp.helpers;
using CarpetsApp.model;
using LinqKit;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        public ICollectionView CompaniesView { get; set; }
        public ICollectionView BillsView { get; set; }
        public List<Predicate<Bill>> criteria = new List<Predicate<Bill>>();

        public MainWindow()
        {
            InitializeComponent();

            CompaniesView = CollectionViewSource.GetDefaultView(ApplicationA.Instance.Companies);
            BillsView = CollectionViewSource.GetDefaultView(ApplicationA.Instance.Bills);
            //setupTableSourceItems(CompaniesView, companies_dg);
            setupTableSourceItems(BillsView, bills_dg);

            setupBillsAndCarpets();
            cgHelper.setupTable(companies_dg);
            setupComboBoxes();
            cgHelper.setupTableBills(bills_dg, BillsView);
            bill_date_dpick.SelectedDate = DateTime.Now;
        }

        private void setupTableSourceItems(ICollectionView cView, DataGrid dg)
        {
            dg.ItemsSource = cView;
            dg.IsSynchronizedWithCurrentItem = true;
        }

        private void setupBillsAndCarpets()
        {
            billMaxHelper.loadBillItems();
            billMaxHelper.fillCompanyBills();
            billMaxHelper.fillBillCompany();
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

            months_search_cb.ItemsSource = months;
            months_search_cb.SelectedIndex = today.Month - 1;
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
            }
        }

        private void print_bills_btn_Click(object sender, RoutedEventArgs e)
        {
            if (bills_dg.SelectedItems.Count == 0)
            {
                MessageBox.Show("Morate da oznacite neki racun!");
            }
            else
            {
                foreach(Bill b in bills_dg.SelectedItems)
                {
                    //ExcelFileEditHelper.editExcelFile(b.Company, true);
                }
            }
        }

        private void view_bill_btn_Click(object sender, RoutedEventArgs e)
        {
            if (bills_dg.SelectedItems.Count != 1)
            {
                MessageBox.Show("Morate da oznacite jedan racun!");
            }
            else
            {
                // prikaz racuna
                // mogucnost izmene

                // kod kreiranja novog racuna omoguciti chkbox otpremnica
            }
        }

        private void book_existing_bill_Click(object sender, RoutedEventArgs e)
        {
            if (bills_dg.SelectedItems.Count != 1)
            {
                MessageBox.Show("Morate da oznacite jedan racun!");
            }
            else
            {
                // knjizenje tog racuna za tu kompaniju, u slucaju da je atipicna f-ra poslednja
                // i onda postavljam taj racun za kompaniju u tabeli za kompanije
            }
        }

        private void search_btn_Click(object sender, RoutedEventArgs e)
        {
            bool company = company_chkb.IsChecked ?? false;
            bool bill_num = bill_num_chkb.IsChecked ?? false;
            bool year = year_chkb.IsChecked ?? false;
            bool date = date_chkb.IsChecked ?? false;
            bool month = month_chkb.IsChecked ?? false;

            Predicate<Bill> companyPredicate = new Predicate<Bill>(companySearchCondition);
            Predicate<Bill> billNumPredicate = new Predicate<Bill>(billNumSearchCondition);
            Predicate<Bill> yearPredicate = new Predicate<Bill>(yearSearchCondition);
            Predicate<Bill> billDatePredicate = new Predicate<Bill>(billDateSearchCondition);
            Predicate<Bill> monthPredicate = new Predicate<object>(monthSearchCondition);

            /*criteria.Clear();
            BillsView.Filter = null;*/
            // videti da li hoce posle svake pretrage da mora da ponisti ili da moze 7 pretraga za redom


            if (!company && !bill_num && !year && !date && !month)
            {
                MessageBox.Show("Morate da otkacite makar jedan kriterijum da biste pretrazili racun!");
            }
            if (company)
            {
                //predicates = predicates.And(bill => bill.Company.Name.ToLower().Contains(company_txtb.Text.ToLower());
                criteria.Add(new Predicate<Bill>(companyPredicate));
            }
            if (bill_num)
            {
                criteria.Add(new Predicate<Bill>(billNumPredicate));
            }
            if (year)
            {
                int yearInt = int.Parse(year_txtb.Text);
                criteria.Add(new Predicate<Bill>(yearPredicate));
            }
            if (date)
            {
                criteria.Add(new Predicate<Bill>(billDatePredicate));
                // zavrsiti
            }
            if (month)
            {
                criteria.Add(new Predicate<Bill>(monthPredicate));
            }
            
            BillsView.Filter = dynamic_Filter;
        }

        private void cancel_search_btn_Click(object sender, RoutedEventArgs e)
        {
            criteria.Clear();
            BillsView.Filter = null;
        }

        private bool dynamic_Filter(object b)
        {
            Bill bill = b as Bill;
            bool isIn = true;
            isIn = criteria.TrueForAll(x => x(bill));

            return isIn;
        }

        private bool companySearchCondition(object b)
        {
            Bill bill = b as Bill;
            return bill.Company.Name.ToLower().Contains(company_txtb.Text.ToLower());
        }

        private bool billNumSearchCondition(object b)
        {
            Bill bill = b as Bill;
            return bill.BillNum.Equals(bill_num_txtb.Text);
        }

        private bool yearSearchCondition(object b)
        {
            Bill bill = b as Bill;
            int year = int.Parse(year_txtb.Text);
            return bill.TrafficYear == year;
        }

        private bool billDateSearchCondition(object b)
        {
            Bill bill = b as Bill;
            return bill.BillDate == bill_date_dpick.SelectedDate;
        }

        private bool monthSearchCondition(object b)
        {
            Bill bill = b as Bill;
            String month = MonthHelper.getMonthFromInt(months_search_cb.SelectedIndex + 1);
            return bill.TrafficMonth.Equals(month);
        }

        private void bills_dg_AutoGeneratingColumn(object sender, DataGridAutoGeneratingColumnEventArgs e)
        {
            switch ((string)e.Column.Header)
            {
                case "Id":
                    e.Cancel = true;
                    break;
                case "BillNum":
                    e.Column.Header = "Broj racuna";
                    break;
                case "Dispatcher":
                    e.Column.Header = "Otpremnica";
                    break;
                case "BillNumForYear":
                    e.Cancel = true;
                    break;
                case "TrafficMonth":
                    e.Column.Header = "Mesec";
                    break;
                case "TrafficYear":
                    e.Column.Header = "Godina";
                    break;
                case "Company":
                    e.Cancel = true;
                    break;
                case "BillDate":
                    e.Cancel = true;
                    break;
                case "Amount":
                    e.Column.Header = "Iznos";
                    break;
                case "Items":
                    e.Cancel = true;
                    break;
                case "Error":
                    e.Cancel = true;
                    break;
            }
        }
    }
}
