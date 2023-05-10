using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Types = System.Type;

namespace CodePlagiarismDetection.Services
{
    public static class ComparisonDataTableWorker
    {
        public static DataTable CreateFileCoprasionDataTable()
        {
            var table = new DataTable("FileComrassionResult");
            table.Columns.Add(AddColumn("FirstFile", "System.String", "Файл 1", true));
            table.Columns.Add(AddColumn("FirstDirectory", "System.String",  "Папка 1", true));
            table.Columns.Add(AddColumn("SecondFile", "System.String",  "Файл 2", true));
            table.Columns.Add(AddColumn("SecondDirectory", "System.String", "Папка 2", true));
            table.Columns.Add(AddColumn("SimilarityPercent", "System.Double",  "Схожесть %", true));
            table.Columns.Add(AddColumn("CriticalBorderValue", "System.Double",  "Порог схожести", true));
            table.Columns.Add(AddColumn("Method", "System.String", "Метод", true));
            table.Columns.Add(AddColumn("PathToFirstFile", "System.String",  "PathToFirstFile", true));
            table.Columns.Add(AddColumn("PathToSecondFile", "System.String",  "PathToSecondFile", true));
            
            return table;
        }

        public static DataTable FillComparisionDataTable(DataTable table, IEnumerable<ComparisonResult> comparisons,
            string methodName, int criticalBorderValue, TableFillOption option)
        {
            DataRow row;
            var comprassionList = comparisons.ToList();
            
            if (option == TableFillOption.ClearTable)
                table.Clear();
            
            foreach (var compressionResult in comprassionList)
            {
                row = table.NewRow();
                row["FirstDirectory"] = compressionResult.OriginalFile.DirectoryName;
                row["FirstFile"] = compressionResult.OriginalFile.FileName;
                row["SecondDirectory"] = compressionResult.ComparedFile.DirectoryName;
                row["SecondFile"] = compressionResult.ComparedFile.FileName;
                row["SimilarityPercent"] = Math.Round((compressionResult.Similarity * 100), 2);
                row["CriticalBorderValue"] = criticalBorderValue;
                row["Method"] = methodName;
                row["PathToFirstFile"] = compressionResult.OriginalFile.FullPath;
                row["PathToSecondFile"] = compressionResult.ComparedFile.FullPath;
                
                table.Rows.Add(row);
            }
            return table;
        }

        private static DataColumn AddColumn(string columnName, string type,  string caption, bool readonlyMode)
        {
            return new DataColumn(){
                DataType = Types.GetType(type),
                ColumnName = columnName,
                Caption = caption,
                ReadOnly = readonlyMode
            };
        }
    }
}