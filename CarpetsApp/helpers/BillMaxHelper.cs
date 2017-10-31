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
            foreach(Company c in ApplicationA.Instance.Companies)
            {
                c.Bill = findMaxBillForCompany(c.Id);
            }
        }

        public Bill findMaxBillForCompany(int id)
        {
            int maxId = 0;

            for(int i = 0; i < ApplicationA.Instance.Bills.Count; i++)
            {
                if(ApplicationA.Instance.Bills[i].Company.Id == id)
                {
                    maxId = i;
                }
            }

            return ApplicationA.Instance.Bills[maxId];
        }
    }
}
