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
    public class CarpetDao
    {
        public static ObservableCollection<Carpet> Load()
        {
            using (SqlConnection connection = new SqlConnection(ApplicationA.CONNECTION_STRING))
            {
                ObservableCollection<Carpet> carpets = new ObservableCollection<Carpet>();

                connection.Open();

                DataSet dataSet = new DataSet();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"Select * From carpet;";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                try
                {
                    dataAdapter.Fill(dataSet, "carpet");

                    foreach (DataRow row in dataSet.Tables["carpet"].Rows)
                    {
                        int id = (int)row["id"];
                        double length = (double)row["c_length"];
                        double width = (double)row["c_width"];

                        Carpet carpet = new Carpet(id, length, width);

                        carpets.Add(carpet);
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
                    MessageBox.Show(n.StackTrace);
                    ApplicationA.WriteToLog(n.StackTrace);
                }

                return carpets;
            }
        }

    }
}
