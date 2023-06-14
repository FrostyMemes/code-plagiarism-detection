using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;

namespace CodePlagiarismDetection.Services
{
    //Класс для создания Excel-документа
    public static class ExcelReportGenerator
    {
        private static List<string> ExceptionColumns = new List<string>() //Список игнорируемых столбцов таблицы
        {
            "Id",
            "PathToFirstFile",
            "PathToSecondFile",
        };
        
        //Метод создания Excel-документа
        public static void GenerateExcelReport(DataTable comparisionDataTable)
        {
            const int START_ROW = 2;
            const int START_COLUMN = 2;
            
            try
            {
                var excelApp = new Excel.Application(); excelApp.DisplayAlerts = false;
                var workbook = excelApp.Workbooks.Add(Type.Missing);
                var sheet = (Excel.Worksheet)excelApp.Worksheets.Item[1];
                
                var suspiciousFiles = comparisionDataTable.Select()
                    .Where(row => (double)row["SimilarityPercent"] >= (double)row["CriticalBorderValue"])
                    .ToList();

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
                range.Columns.AutoFit();
                excelApp.Visible = true;
            }
            catch (Exception e)
            {
                MessageBox.Show("Не удалось создать Excel-документ","Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}