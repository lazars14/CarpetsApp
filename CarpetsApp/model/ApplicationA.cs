using CarpetsApp.dao;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetsApp.model
{
    public class ApplicationA
    {
        public const string CONNECTION_STRING = @"Integrated Security=SSPI;
                                          Initial Catalog=carpets;
                                          Data Source=DUSAN";

        public const string FILE_NAME = @"..\..\Log.txt";

        public const string FILL_ALL_FIELDS_WARNING = "Morate da popunite sva polja!";

        public const string FILL_FIELD = "Popuniti";

        public const string DATABASE_ERROR_MESSAGE = "Doslo je do greske sa bazom!";

        public ObservableCollection<Company> Companies { get; set; }
        public ObservableCollection<Carpet> Carpets { get; set; }
        public ObservableCollection<Billitem> Billitems { get; set; }
        public ObservableCollection<Bill> Bills { get; set; }

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
            Billitems = new ObservableCollection<Billitem>();
            Bills = new ObservableCollection<Bill>();
            CompanyDao.Load();
            CarpetDao.Load();
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
    }
}
