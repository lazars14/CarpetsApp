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

        private double price;
        public double Price
        {
            get { return price; }
            set { price = value; OnPropertyChanged("Price"); }
        }

        private int quantity;
        public int Quantity
        {
            get { return quantity; }
            set { quantity = value; OnPropertyChanged("Quantity"); }
        }

        public int CarpetId { get; set; }

        public Billitem() { }
        
        public Billitem(int id) { Id = id; }

        public Billitem(int id, int carpetId, double price, int quantity)
        {
            Id = id;
            Carpet = null;
            Price = price;
            Quantity = quantity;
            CarpetId = carpetId;
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
            itemCopy.Quantity = Quantity;

            return itemCopy;
        }

        #endregion
    }
}
