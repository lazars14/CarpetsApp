using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetsApp.model
{
    public class Carpet : INotifyPropertyChanged, ICloneable
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private double length;
        public double Length
        {
            get { return length; }
            set { length = value; OnPropertyChanged("Length"); }
        }

        private double width;
        public double Width
        {
            get { return width; }
            set { width = value; OnPropertyChanged("Width"); }
        }

        public Carpet() { }

        public Carpet(int id) { Id = id; }

        public Carpet(int id, double length, double width)
        {
            Id = id;
            Length = length;
            Width = width;
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
            Carpet carpetCopy = new Carpet();
            carpetCopy.Id = Id;
            carpetCopy.Length = Length;
            carpetCopy.Width = Width;

            return carpetCopy;
        }

        #endregion
    }
}
