using CarpetsApp.helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetsApp.model
{
    public class Billitem : INotifyPropertyChanged, ICloneable
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private Carpet carpet;
        public Carpet Carpet
        {
            get { return carpet; }
            set { carpet = value; OnPropertyChanged("Carpet"); }
        }

        private float price;
        public float Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged("Price"); }
        }

        private Bill bill;
        private int carpetId;

        public Bill Bill
        {
            get { return bill; }
            set { bill = value; OnPropertyChanged("Bill"); }
        }

        public Billitem() { }
        
        public Billitem(int id) { Id = id; }

        public Billitem(int id, int carpetId, float price, Bill bill)
        {
            Id = id;
            Carpet = CarpetHelper.getCarpetFromApp(carpetId);
            Price = price;
            Bill = bill;
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
            Billitem itemCopy = new Billitem();
            itemCopy.Id = Id;
            itemCopy.Carpet = Carpet;
            itemCopy.Price = Price;
            itemCopy.Bill = Bill;

            return itemCopy;
        }

        #endregion
    }
}
