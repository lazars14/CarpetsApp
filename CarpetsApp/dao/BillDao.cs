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
    public class BillDao
    {
        public static Bill LoadId(Company c)
        {
            using (SqlConnection connection = new SqlConnection(ApplicationA.CONNECTION_STRING))
            {
                bool valid = false;

                connection.Open();

                DataSet dataSet = new DataSet();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"Select * From bill Where company_id = @Company_Id;";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                try
                {
                    command.Parameters.Add(new SqlParameter("@Company_Id", c.Id));
                    dataAdapter.Fill(dataSet, "bill");

                    foreach (DataRow row in dataSet.Tables["bill"].Rows)
                    {
                        int id = (int)row["id"];
                        String dispatcher = (String)row["dispatcher"];
                        String billNum = (String)row["bill_num"];
                        String trafficMonth = (String)row["traffic_month"];
                        int trafficYear = (int)row["traffic_year"];
                        DateTime billDate = (DateTime)row["bill_date"];
                        float surface = (float)row["surface"];
                        float price = (float)row["price"];

                        return new Bill(id, dispatcher, billNum, c, trafficMonth, trafficYear, billDate, surface, price);
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

                return null;
            }

            return null;
        }
    }
}
