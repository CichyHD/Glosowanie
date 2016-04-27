using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using GemBox.Spreadsheet;

namespace Glosowanie.Domain.Providers
{

    public class ExcelProvider : IExcelProvider
    {
        public ExcelFile CreateExcelFile(IEnumerable<string> tokensList)
        {
            SpreadsheetInfo.SetLicense("FREE-LIMITED-KEY");

            ExcelFile excelFile = new ExcelFile();
            ExcelWorksheet excelWorksheet = excelFile.Worksheets.Add("Writing");

            excelWorksheet.Cells[0, 0].Value = "Lista tokenów";
            foreach (string token in tokensList)
            {
                excelWorksheet.Cells[token.GetEnumerator().Current, 0].Value = token;
            }

            return excelFile;
        }
    }
}
