using CarpetsApp.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetsApp.model
{
    public class Bill : INotifyPropertyChanged, ICloneable
    {
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

        private String billNum;
        public String BillNum
        {
            get { return billNum; }
            set { billNum = value; OnPropertyChanged("BillNum"); }
        }

        private Company company;
        public Company Company
        {
            get { return company; }
            set { company = value; OnPropertyChanged("Company"); }
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

        private float surface;
        public float Surface
        {
            get { return surface; }
            set { surface = value; OnPropertyChanged("Surface"); }
        }

        private float price;
        public float Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged("Price"); }
        }

        public List<Billitem> Items { get; set; }

        public Bill() { }

        public Bill(int id) { Id = id; }

        public Bill(int id, string dispatcher, string billNum, Company c, string trafficMonth, int trafficYear, DateTime billDate, float surface, float price)
        {
            Id = id;
            Dispatcher = dispatcher;
            BillNum = billNum;
            Company = c;
            TrafficMonth = trafficMonth;
            TrafficYear = trafficYear;
            BillDate = billDate;
            Surface = surface;
            Price = price;
            Items = BillitemDao.LoadForBill(this);
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
            billCopy.BillNum = BillNum;
            billCopy.Company = Company;
            billCopy.TrafficMonth = TrafficMonth;
            billCopy.TrafficYear = TrafficYear;
            billCopy.BillDate = BillDate;
            billCopy.Surface = Surface;
            billCopy.Price = Price;

            return billCopy;
        }

        #endregion
    }
}
