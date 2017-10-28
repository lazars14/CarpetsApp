using CarpetsApp.model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetsApp.helpers
{
    public class CarpetHelper
    {
        public static Carpet getCarpetFromApp(int id)
        {
            foreach(Carpet c in ApplicationA.Instance.Carpets)
            {
                if(c.Id == id)
                {
                    return c;
                }
            }

            return null;
        } 
    }
}
