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
    public class CompanyDao
    {

        public static ObservableCollection<Company> Load()
        {
            using (SqlConnection connection = new SqlConnection(ApplicationA.CONNECTION_STRING))
            {
                ObservableCollection<Company> companies = new ObservableCollection<Company>();

                connection.Open();

                DataSet dataSet = new DataSet();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"Select * From company;";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                try
                {
                    dataAdapter.Fill(dataSet, "company");

                    foreach (DataRow row in dataSet.Tables["company"].Rows)
                    {
                        int id = (int)row["id"];
                        String name = (String)row["name"];
                        String pib = (String)row["pib"];
                        String address = (String)row["adress"];
                        String city = (String)row["city"];
                        String zone = (String)row["zone"];
                        String contactPerson = (String)row["contact_person"];
                        String phoneNumber = (String)row["phone_number"];
                        DateTime signingDate = (DateTime)row["signing_date"];
                        bool insecure = (bool)row["insecure"];
                        double compensation = (double)row["compensation"];
                        int numReplacements = (int)row["num_replacements"];
                        int numLocations = (int)row["num_locations"];
                        int numCarpets = (int)row["num_carpets"];

                        Company company = new Company(id, name, pib, address, city, zone, contactPerson, 
                            phoneNumber, signingDate, insecure, compensation, numReplacements, numLocations, numCarpets);

                        companies.Add(company);
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

                return companies;
            }
        }


    }
}
