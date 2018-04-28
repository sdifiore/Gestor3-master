using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Excel = Microsoft.Office.Interop.Excel;

namespace Gestor.Models
{
    public class ExcelDb
    {
        public void Estrutura()
        {
            var worksheets = new Stack<int>();
            worksheets.Push(2);

            Excel.Application xlApp = new Excel.Application();
            Excel.Workbook workbook = xlApp.Workbooks.Open(Files.CustoEstrutura);
            Excel._Worksheet worksheet = workbook.Sheets[2];
            Excel.Range range = worksheet.UsedRange;

            try
            {
                var columns = range.Columns.Count;
                var rows = range.Rows.Count;

                for (int i = 1; i <= columns; i++)
                {
                    for (int j = 1; j <= rows; j++)
                    {
                        if (range.Cells[i, j] != null && range.Cells[i, j].Value2 != null)
                            DbLogger.Log(Reason.Info, range.Cells[i, j]);
                    }

                    Console.ReadLine();
                }
            }
            catch (Exception)
            {

                throw;
            }
            finally
            {
                xlApp.Quit();
                workbook = null;
                worksheet = null;
                xlApp = null;
            }
        }
    }
}

// to be continued if needed