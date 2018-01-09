using CarpetsApp.dao;
using CarpetsApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarpetsApp.helpers
{
    public class BillMaxHelper
    {
        public void fillCompanyBills()
        {
            foreach (Company c in ApplicationA.Instance.Companies)
            {
                c.Bill = findMaxBillForCompany(c.Id);
            }
        }

        public Bill findMaxBillForCompany(int id)
        {
            int maxId = 0;

            for (int i = 0; i < ApplicationA.Instance.Bills.Count; i++)
            {
                if (ApplicationA.Instance.Bills[i].Company.Id == id)
                {
                    maxId = i;
                }
            }

            return ApplicationA.Instance.Bills[maxId];
        }

        public static int findMaxBillNumForYear(int year)
        {
            int maxBillNum = 0;

            foreach (Bill bill in ApplicationA.Instance.Bills)
            {
                if (bill.TrafficYear == year && bill.BillNumForYear > maxBillNum)
                {
                    maxBillNum = bill.BillNumForYear;
                }
            }

            return maxBillNum;
        }

        public static int findMaxBillItemId(Bill b)
        {
            int maxId = 0;
            foreach(Billitem item in b.Items)
            {
                if(item.Id > maxId)
                {
                    maxId = item.Id;
                }
            }

            return maxId;
        }

        public static double getBillValue(Bill b)
        {
            double sum = 0;

            foreach(Billitem item in b.Items)
            {
                sum += item.Price * item.Carpet.Length * item.Carpet.Width;
            }

            return sum;
        }

        public void fillBillCompany()
        {
            foreach(Bill bill in ApplicationA.Instance.Bills)
            {
                bill.Company.Name = findCompanyName(bill.Company.Id);
            }
        }

        internal void loadBillItems()
        {
            foreach (Bill bill in ApplicationA.Instance.Bills)
            {
                bill.Items = BillitemDao.LoadForBill(bill.Id);
            }
        }

        private String findCompanyName(int id)
        {
            foreach(Company c in ApplicationA.Instance.Companies)
            {
                if(c.Id == id)
                {
                    return c.Name;
                }
            }

            return null;
        }
    }
}
