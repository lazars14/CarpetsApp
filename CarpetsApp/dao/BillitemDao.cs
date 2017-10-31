using CarpetsApp.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarpetsApp.dao
{
    public class BillitemDao
    {
        public static ObservableCollection<Billitem> LoadForBill(Bill bill)
        {
            using (SqlConnection connection = new SqlConnection(ApplicationA.CONNECTION_STRING))
            {
                ObservableCollection<Billitem> items = new ObservableCollection<Billitem>();

                connection.Open();

                DataSet dataSet = new DataSet();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"Select * From bill_item Where bill_id = @Bill_Id;";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                try
                {
                    command.Parameters.Add(new SqlParameter("@Bill_Id", bill.Id));
                    dataAdapter.Fill(dataSet, "bill_item");

                    foreach (DataRow row in dataSet.Tables["bill_item"].Rows)
                    {
                        int id = (int)row["id"];
                        int carpetId = (int)row["carpet_id"];
                        double price = (double)row["price"];

                        Billitem item = new Billitem(id, carpetId, price);

                        items.Add(item);
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show("SQL Exception");
                    ApplicationA.WriteToLog(e.StackTrace);
                }
                catch (InvalidOperationException a)
                {
                    MessageBox.Show("InvalidOperationException");
                    ApplicationA.WriteToLog(a.StackTrace);
                }
                catch (ArgumentException g)
                {
                    MessageBox.Show("ArgumentException");
                    ApplicationA.WriteToLog(g.StackTrace);
                }
                catch (NullReferenceException n)
                {
                    MessageBox.Show("NullReferenceException");
                    ApplicationA.WriteToLog(n.StackTrace);
                }

                return items;
            }
        }
    }
}
