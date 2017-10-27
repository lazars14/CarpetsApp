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

namespace CarpetsApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
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
