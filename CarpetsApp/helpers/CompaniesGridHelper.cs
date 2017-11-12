using CarpetsApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Data;

namespace CarpetsApp.helpers
{
    public class CompaniesGridHelper
    {
        public List<String> headers = new List<string> {"Id", "Zona", "Naziv", "PIB", "Adresa", "Grad", "Kontakt osoba",
                "Kontakt telefon", "Datum potpisivanja", "Nesigurno", "Kompenzacija", "Broj zamena", "Broj tepiha",
                "Broj lokacija", "Poslednji racun", "Vrednost racuna"
            };
        public List<String> bindings = new List<string> {"Id", "Zone", "Name", "Pib", "Address", "City", "ContactPerson",
                "PhoneNumber", "SigningDate", "Insecure", "Compensation", "NumReplacements", "NumCarpets", "NumLocations",
                "Bill.BillNum", "Bill.Amount"
            };

        public List<String> billsHeaders = new List<string> {"Firma", "Otpremnica",  "Broj racuna", "Datum", "Iznos"
            };

        public List<String> billsBindings = new List<string> {"Company.Name", "Dispatcher", "BillNum", "BillDate", "Amount"
            };

        public void setupTable(DataGrid dg)
        {
            DataGridTextColumn column = new DataGridTextColumn();

            for (int i = 0; i < headers.Count; i++)
            {
                column = new DataGridTextColumn();
                column.Header = headers[i];
                column.Binding = new Binding(bindings[i]);
                dg.Columns.Add(column);
            }

            foreach (object c in ApplicationA.Instance.Companies)
            {
                dg.Items.Add(c);
            }

            dg.IsSynchronizedWithCurrentItem = true;
        }

        public void setupTableBills(DataGrid dg)
        {
            DataGridTextColumn column = new DataGridTextColumn();

            for (int i = 0; i < billsHeaders.Count; i++)
            {
                column = new DataGridTextColumn();
                column.Header = billsHeaders[i];
                column.Binding = new Binding(billsBindings[i]);

                if(billsHeaders[i] == "Datum")
                {
                    column.Binding.StringFormat = "d";
                }

                dg.Columns.Add(column);
            }

            foreach (object c in ApplicationA.Instance.Bills)
            {
                dg.Items.Add(c);
            }

            dg.IsSynchronizedWithCurrentItem = true;
        }
    }
}
