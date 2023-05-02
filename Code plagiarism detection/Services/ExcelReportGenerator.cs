using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using Excel = Microsoft.Office.Interop.Excel;

namespace CodePlagiarismDetection.Services
{
    public static class ExcelReportGenerator
    {
        private static List<string> ExceptionColumns = new List<string>()
        {
            "PathToFirstFile",
            "PathToSecondFile"
        };
        public static void GenerateExcelReport(DataTable comparisionDataTable, double borderSuspicious)
        {
            var excelApp = new Excel.Application(); excelApp.DisplayAlerts = false;
            var workBook = excelApp.Workbooks.Add(Type.Missing);
            var sheet = (Excel.Worksheet)excelApp.Worksheets.Item[1];
            
            var suspiciousFiles = comparisionDataTable.Select()
                .Where(row => double.Parse(row["SimilarityPercent"].ToString()) >= borderSuspicious)
                .ToList();

            const int START_ROW = 2;
            const int START_COLUMN = 2;
            
            var columnNameColumIndex = START_COLUMN - 1;

            foreach (DataColumn column in comparisionDataTable.Columns)
            {
                if (!ExceptionColumns.Contains(column.ColumnName))
                {
                    columnNameColumIndex++;
                    sheet.Cells[START_ROW, columnNameColumIndex] = column.Caption;
                }
            }

            var range = sheet.Range[sheet.Cells[START_ROW, START_COLUMN],
                sheet.Cells[START_ROW, columnNameColumIndex]];
            
            range.Font.Bold = true;

            var fileInfoRowIndex = START_ROW;
            var fileInfoColumnIndex = START_COLUMN;
            foreach (var fileInfo in suspiciousFiles)
            {
                fileInfoRowIndex++;
                for (int i = 0; i != comparisionDataTable.Columns.Count; i++)
                {
                    if (!ExceptionColumns.Contains(comparisionDataTable.Columns[i].ColumnName))
                        sheet.Cells[fileInfoRowIndex, fileInfoColumnIndex + i] = fileInfo[i];
                }
            }

            range = sheet.Range[sheet.Cells[START_ROW, START_COLUMN],
                sheet.Cells[fileInfoRowIndex, columnNameColumIndex]];
            range.Borders.LineStyle = Excel.XlLineStyle.xlContinuous;
            excelApp.Visible = true;
        }
    }
}