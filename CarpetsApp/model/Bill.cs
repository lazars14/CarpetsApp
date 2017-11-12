using CarpetsApp.dao;
using CarpetsApp.helpers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarpetsApp.model
{
    public class Bill : INotifyPropertyChanged, ICloneable
    {
        public String BillNum { get; set; }

        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private String dispatcher;
        public String Dispatcher
        {
            get { return dispatcher; }
            set { dispatcher = value; OnPropertyChanged("Dispatcher"); }
        }

        private Company company;
        public Company Company
        {
            get { return company; }
            set { company = value; OnPropertyChanged("Company"); }
        }

        private int billNumForYear;
        public int BillNumForYear
        {
            get { return billNumForYear; }
            set { billNumForYear = value; OnPropertyChanged("BillNumForYear"); }
        }

        private String trafficMonth;
        public String TrafficMonth
        {
            get { return trafficMonth; }
            set { trafficMonth = value; OnPropertyChanged("TrafficMonth"); }
        }

        private int trafficYear;
        public int TrafficYear
        {
            get { return trafficYear; }
            set { trafficYear = value; OnPropertyChanged("TrafficYear"); }
        }

        private DateTime billDate;
        public DateTime BillDate
        {
            get { return billDate; }
            set { billDate = value; OnPropertyChanged("BillDate"); }
        }

        public ObservableCollection<Billitem> Items { get; set; }

        public Bill() { }

        public Bill(int id) { Id = id; }

        public Bill(int id, string dispatcher, int companyId, int billNumForYear, string trafficMonth, int trafficYear, DateTime billDate)
        {
            Id = id;
            Dispatcher = dispatcher;
            Company = new Company(companyId);
            BillNumForYear = billNumForYear;
            TrafficMonth = trafficMonth;
            TrafficYear = trafficYear;
            BillDate = billDate;
            Items = BillitemDao.LoadForBill(this);
            BillNum = billNumForYear + "-" + MonthHelper.getIntFromMonth(trafficMonth) + "-" + (trafficYear - 2000);
        }

        #region INotifyPropertyChanged

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null)
            {
                handler(this, new PropertyChangedEventArgs(name));
            }
        }

        #endregion

        #region ICloneable

        public object Clone()
        {
            Bill billCopy = new Bill();
            billCopy.Id = Id;
            billCopy.Dispatcher = Dispatcher;
            billCopy.Company = Company;
            billCopy.TrafficMonth = TrafficMonth;
            billCopy.TrafficYear = TrafficYear;
            billCopy.BillDate = BillDate;
            billCopy.Items = Items;
            billCopy.BillNum = BillNum;

            return billCopy;
        }

        #endregion
    }
}
