using CarpetsApp.model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CarpetsApp.helpers
{
    public class CarpetHelper
    {
        public void setCarpetsForItems()
        {
            foreach(Bill bill in ApplicationA.Instance.Bills)
            {
                foreach(Billitem item in bill.Items)
                {
                    item.Carpet = getCarpet(item.CarpetId);
                }
            }
        }

        public Carpet getCarpet(int carpetId)
        {
            foreach(Carpet c in ApplicationA.Instance.Carpets)
            {
                if(c.Id == carpetId)
                {
                    return c;
                }
            }

            return null;
        } 
    }
}
