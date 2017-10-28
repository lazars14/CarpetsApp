using CarpetsApp.model;
using System;
using System.Collections.Generic;
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
        public static List<Billitem> LoadForBill(Bill bill)
        {
            using (SqlConnection connection = new SqlConnection(ApplicationA.CONNECTION_STRING))
            {
                List<Billitem> items = new List<Billitem>();

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
                        float price = (float)row["price"];

                        items.Add(new Billitem(id, carpetId, price, bill))
                    }
                }
                catch (SqlException e)
                {
                    MessageBox.Show(ApplicationA.DATABASE_ERROR_MESSAGE);
                    ApplicationA.WriteToLog(e.StackTrace);
                }
                catch (InvalidOperationException a)
                {
                    MessageBox.Show(ApplicationA.DATABASE_ERROR_MESSAGE);
                    ApplicationA.WriteToLog(a.StackTrace);
                }
                catch (ArgumentException g)
                {
                    MessageBox.Show(ApplicationA.DATABASE_ERROR_MESSAGE);
                    ApplicationA.WriteToLog(g.StackTrace);
                }
                catch (NullReferenceException n)
                {
                    MessageBox.Show(ApplicationA.DATABASE_ERROR_MESSAGE);
                    ApplicationA.WriteToLog(n.StackTrace);
                }

                return items;
            }
        }
    }
}
