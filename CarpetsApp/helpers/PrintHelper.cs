using CarpetsApp.model;
using Spire.Xls;
using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarpetsApp.helpers
{
    public class PrintHelper
    {
        public static void printExcelDoc(Workbook workbook)
        {
            PrintDialog dialog = new PrintDialog();
            dialog.AllowPrintToFile = true;
            dialog.AllowCurrentPage = true;
            dialog.AllowSomePages = true;
            dialog.AllowSelection = true;
            dialog.UseEXDialog = true;
            dialog.PrinterSettings.Duplex = Duplex.Simplex;
            dialog.PrinterSettings.FromPage = 1;
            dialog.PrinterSettings.ToPage = 1;
            dialog.PrinterSettings.PrintRange = PrintRange.SomePages;
            dialog.PrinterSettings.Copies = 2;
            workbook.PrintDialog = dialog;
            PrintDocument pd = workbook.PrintDocument;
            pd.DefaultPageSettings.Landscape = true;
            pd.Print();
        }
    }
}
