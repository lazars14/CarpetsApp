using CarpetsApp.helpers;
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
    public class BillDao
    {

        public static Bill LoadId(int companyId)
        {
            using (SqlConnection connection = new SqlConnection(ApplicationA.CONNECTION_STRING))
            {
                connection.Open();

                DataSet dataSet = new DataSet();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"Select * From bill Where company_id = @Company_Id;";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                try
                {
                    dataAdapter.Fill(dataSet, "bill");

                    foreach (DataRow row in dataSet.Tables["bill"].Rows)
                    {
                        int id = (int)row["id"];
                        String dispatcher = (String)row["dispatcher"];
                        String trafficMonth = (String)row["traffic_month"];
                        int trafficYear = (int)row["traffic_year"];
                        int billNumForYear = (int)row["bill_num_for_year"];
                        DateTime billDate = (DateTime)row["bill_date"];

                        return new Bill(id, dispatcher, companyId, billNumForYear, trafficMonth, trafficYear, billDate);
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
        }

        public static ObservableCollection<Bill> Load()
        {
            using (SqlConnection connection = new SqlConnection(ApplicationA.CONNECTION_STRING))
            {
                ObservableCollection<Bill> bills = new ObservableCollection<Bill>();

                connection.Open();

                DataSet dataSet = new DataSet();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"Select * From bill;";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(command);

                try
                {
                    dataAdapter.Fill(dataSet, "bill");

                    foreach (DataRow row in dataSet.Tables["bill"].Rows)
                    {
                        int id = (int)row["id"];
                        String dispatcher = (String)row["dispatcher"];
                        String trafficMonth = (String)row["traffic_month"];
                        int trafficYear = (int)row["traffic_year"];
                        int billNumForYear = (int)row["bill_num_for_year"];
                        DateTime billDate = (DateTime)row["bill_date"];
                        int companyId = (int)row["company_id"];

                        bills.Add(new Bill(id, dispatcher, companyId, billNumForYear, trafficMonth, trafficYear, billDate));
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

                return bills;
            }
        }

        public static bool Add(Bill bill)
        {
            using (SqlConnection connection = new SqlConnection(ApplicationA.CONNECTION_STRING))
            {
                bool valid = false;

                connection.Open();

                SqlCommand command = connection.CreateCommand();
                command.CommandText = @"Insert Into bill Values(@Dispathcer,@Carpet,@BillNumNext,@TrafficMonth,@TrafficYear,@BillDate);";

                try
                {
                    command.Parameters.Add(new SqlParameter("@Dispathcer", bill.Dispatcher));
                    command.Parameters.Add(new SqlParameter("@Carpet", bill.Company.Id));
                    command.Parameters.Add(new SqlParameter("@BillNumNext", bill.BillNumForYear));
                    command.Parameters.Add(new SqlParameter("@TrafficMonth", bill.TrafficMonth));
                    command.Parameters.Add(new SqlParameter("@TrafficYear", bill.TrafficYear));
                    command.Parameters.Add(new SqlParameter("@BillDate", bill.BillDate));

                    command.ExecuteNonQuery();

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
