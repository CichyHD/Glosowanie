using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemBox.Spreadsheet;

namespace Glosowanie.Domain.Providers
{

    public static class ExcelProvider
    {
        public static ExcelFile CreateExcelFile(IEnumerable<string> listaTokenow)
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            ExcelFile excelFile = new ExcelFile();
            ExcelWorksheet excelWorksheet = excelFile.Worksheets.Add("Writing");

            excelWorksheet.Cells[0, 0].Value = "Lista tokenów";
            foreach (string token in listaTokenow)
            {
                excelWorksheet.Cells[token.GetEnumerator().Current, 0].Value = token;
            }

            return excelFile;
        }
    }
}
