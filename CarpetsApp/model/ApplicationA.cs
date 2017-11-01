using CarpetsApp.dao;
using CarpetsApp.helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarpetsApp.model
{
    public class ApplicationA
    {
        public const string CONNECTION_STRING = @"Integrated Security=SSPI;
                                        Initial Catalog=carpets;
                                          Data Source=DUSAN";

        public const string FILE_NAME = @"..\..\Log.txt";
        public const string FILE_NAME_TWO = "C:\\Carpets\\Log.txt";
        public const string FILE_NAME_BILL = @"..\\..\\excelTemplates\\faktura.xlsx";

        public const string FILL_ALL_FIELDS_WARNING = "Morate da popunite sva polja!";

        public const string FILL_FIELD = "Popuniti";

        public const string DATABASE_ERROR_MESSAGE = "Doslo je do greske sa bazom!";

        public ObservableCollection<Company> Companies { get; set; }
        public ObservableCollection<Carpet> Carpets { get; set; }
        public ObservableCollection<Billitem> Billitems { get; set; }
        public ObservableCollection<Bill> Bills { get; set; }

        public BillMaxHelper billMaxHelper = new BillMaxHelper();

        private static ApplicationA instance = new ApplicationA();

        public static ApplicationA Instance
        {
            get
            {
                return instance;
            }
        }

        private ApplicationA()
        {
            Companies = new ObservableCollection<Company>();
            Carpets = new ObservableCollection<Carpet>();
            Bills = new ObservableCollection<Bill>();
            Companies = CompanyDao.Load();
            Carpets = CarpetDao.Load();
            Bills = BillDao.Load();
            //billMaxHelper.fillCompanyBills();
        }

        public static void WriteToLog(string stackTrace)
        {
            using (FileStream fs = new FileStream(FILE_NAME, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                string delimiter = "|";
                string nextLine = "\n";
                sw.Write(DateTime.Now + delimiter + nextLine + stackTrace + nextLine);
            }
        }

        public static void WriteToLogActions(int id, string entity)
        {
            using (FileStream fs = new FileStream(FILE_NAME_TWO, FileMode.Append))
            using (StreamWriter sw = new StreamWriter(fs))
            {
                string delimiter = "|";
                string nextLine = "\n";
                sw.Write(DateTime.Now + delimiter + "Dodata/o je " + entity + " sa id-em " + id + nextLine);
            }
        }
    }
}
