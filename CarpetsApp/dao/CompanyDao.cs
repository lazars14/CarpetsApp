using CarpetsApp.model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetsApp.dao
{
    public class CompanyDao
    {

        public static bool Load()
        {
            using (SqlConnection connection = new SqlConnection(ApplicationA.CONNECTION_STRING))
            {
                bool valid = false;

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
                        int languageId = (int)row["Course_LanguageId"];
                        int courseTypeId = (int)row["Course_CourseTypeId"];
                        int teacherId = (int)row["Course_TeacherId"];
                        double price = (double)row["Course_Price"];
                        DateTime startDate = (DateTime)row["Course_StartDate"];
                        DateTime endDate = (DateTime)row["Course_EndDate"];
                        bool deleted = (bool)row["Course_Deleted"];
                        Course course = new Course(id, languageId, courseTypeId, price, teacherId, startDate, endDate, deleted);

                        ApplicationA.Instance.Companies.Add(course);
                    }

                    valid = true;
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

                return valid;
            }
        }


    }
}
