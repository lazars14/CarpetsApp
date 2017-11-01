using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarpetsApp.helpers
{
    public class MonthHelper
    {
        public static String getMonthFromInt(int monthId)
        {
            String month = "";

            switch (monthId)
            {
                case 1:
                    month = "Januar";
                    break;
                case 2:
                    month = "Februar";
                    break;
                case 3:
                    month = "Mart";
                    break;
                case 4:
                    month = "April";
                    break;
                case 5:
                    month = "Maj";
                    break;
                case 6:
                    month = "Jun";
                    break;
                case 7:
                    month = "Jul";
                    break;
                case 8:
                    month = "Avgust";
                    break;
                case 9:
                    month = "Septembar";
                    break;
                case 10:
                    month = "Oktobar";
                    break;
                case 11:
                    month = "Novembar";
                    break;
                case 12:
                    month = "Decembar";
                    break;
            }

            return month;
        }

        public static int getIntFromMonth(String month)
        {
            int monthInt = 0;

            switch (month)
            {
                case "Januar":
                    monthInt = 1;
                    break;
                case "Februar":
                    monthInt = 2;
                    break;
                case "Mart":
                    monthInt = 3;
                    break;
                case "April":
                    monthInt = 4;
                    break;
                case "Maj":
                    monthInt = 5;
                    break;
                case "Jun":
                    monthInt = 6;
                    break;
                case "Jul":
                    monthInt = 7;
                    break;
                case "Avgust":
                    monthInt = 8;
                    break;
                case "Septembar":
                    monthInt = 9;
                    break;
                case "Oktobar":
                    monthInt = 10;
                    break;
                case "Novembar":
                    monthInt = 11;
                    break;
                case "Decembar":
                    monthInt = 12;
                    break;
            }

            return monthInt;
        }
    }
}
