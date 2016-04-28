using GemBox.Spreadsheet;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Glosowanie.Domain.Providers
{
    public interface IExcelProvider
    {
        ExcelFile CreateExcelFile(List<string> tokensList);
    }
}
