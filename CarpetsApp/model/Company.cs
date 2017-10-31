using CarpetsApp.dao;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetsApp.model
{
    public class Company : INotifyPropertyChanged, ICloneable
    {
        private int id;
        public int Id
        {
            get { return id; }
            set { id = value; OnPropertyChanged("Id"); }
        }

        private String name;
        public String Name
        {
            get { return name; }
            set { name = value; OnPropertyChanged("Name"); }
        }

        private String pib;
        public String Pib
        {
            get { return pib; }
            set { pib = value; OnPropertyChanged("Pib"); }
        }

        private String address;
        public String Address
        {
            get { return address; }
            set { address = value; OnPropertyChanged("Address"); }
        }

        private String city;
        public String City
        {
            get { return city; }
            set { city = value; OnPropertyChanged("City"); }
        }

        private String zone;
        public String Zone
        {
            get { return zone; }
            set { zone = value; OnPropertyChanged("Zone"); }
        }

        private String contactPerson;
        public String ContactPerson
        {
            get { return contactPerson; }
            set { contactPerson = value; OnPropertyChanged("ContactPerson"); }
        }

        private String phoneNumber;
        public String PhoneNumber
        {
            get { return phoneNumber; }
            set { phoneNumber = value; OnPropertyChanged("PhoneNumber"); }
        }

        private DateTime signingDate;
        public DateTime SigningDate
        {
            get { return signingDate; }
            set { signingDate = value; OnPropertyChanged("SigningDate"); }
        }

        private bool insecure;
        public bool Insecure
        {
            get { return insecure; }
            set { insecure = value; OnPropertyChanged("Insecure"); }
        }

        private double compensation;
        public double Compensation
        {
            get { return compensation; }
            set { compensation = value; OnPropertyChanged("Compensation"); }
        }

        private int numReplacements;
        public int NumReplacements
        {
            get { return numReplacements; }
            set { numReplacements = value; OnPropertyChanged("NumReplacements"); }
        }

        private int numLocations;
        public int NumLocations
        {
            get { return numLocations; }
            set { numLocations = value; OnPropertyChanged("NumLocations"); }
        }

        private int numCarpets;
        public int NumCarpets
        {
            get { return numCarpets; }
            set { numCarpets = value; OnPropertyChanged("NumCarpets"); }
        }

        private Bill bill;
        public Bill Bill
        {
            get { return bill; }
            set { bill = value; OnPropertyChanged("Bill"); }
        }

        public Company() {}

        public Company(int id) { Id = id; }

        public Company(int id, string name, string pib, string address, string city, string zone, string contactPerson, string phoneNumber, DateTime signingDate, bool insecure, double compensation, int numReplacements, int numLocations, int numCarpets)
        {
            Id = id;
            Name = name;
            Pib = pib;
            Address = address;
            City = city;
            Zone = zone;
            ContactPerson = contactPerson;
            PhoneNumber = phoneNumber;
            SigningDate = signingDate;
            Insecure = insecure;
            Compensation = compensation;
            NumReplacements = numReplacements;
            NumLocations = numLocations;
            NumCarpets = numCarpets;
            Bill = null;
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
            Company companyCopy = new Company();
            companyCopy.Id = Id;
            companyCopy.Name = Name;
            companyCopy.Pib = Pib;
            companyCopy.Address = Address;
            companyCopy.City = City;
            companyCopy.Zone = Zone;
            companyCopy.ContactPerson = ContactPerson;
            companyCopy.PhoneNumber = PhoneNumber;
            companyCopy.SigningDate = SigningDate;
            companyCopy.Insecure = Insecure;
            companyCopy.Compensation = Compensation;
            companyCopy.NumReplacements = NumReplacements;
            companyCopy.NumLocations = NumLocations;
            companyCopy.NumCarpets = NumCarpets;

            return companyCopy;
        }

        #endregion
    }
}
