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
            table.Columns.Add(AddColumn("FirstFile", "System.String", "Файл1", true));
            table.Columns.Add(AddColumn("FirstDirectory", "System.String",  "Папка1", true));
            table.Columns.Add(AddColumn("SecondFile", "System.String",  "Файл2", true));
            table.Columns.Add(AddColumn("SecondDirectory", "System.String", "Папка", true));
            table.Columns.Add(AddColumn("SimilarityPercent", "System.Double",  "Схожесть %", true));
            table.Columns.Add(AddColumn("CriticalBorderValue", "System.Double",  "Порог схожести", true));
            table.Columns.Add(AddColumn("Method", "System.String", "Метод", true));
            table.Columns.Add(AddColumn("PathToFirstFile", "System.String",  "PathToFirstFile", true));
            table.Columns.Add(AddColumn("PathToSecondFile", "System.String",  "PathToSecondFile", true));
            
            return table;
        }

        public static DataTable FillComparisionDataTable(DataTable table, IEnumerable<ComparisonResult> comparisions,
            string methodName, int criticalBorderValue, TableFillOption option)
        {
            DataRow row;
            var comprassionList = comparisions.ToList();
            
            if (option == TableFillOption.ClearTable)
                table.Clear();
            
            foreach (var compressionResult in comprassionList)
            {
                row = table.NewRow();
                row["FirstDirectory"] = compressionResult.File1.DirectoryName;
                row["FirstFile"] = compressionResult.File1.FileName;
                row["SecondDirectory"] = compressionResult.File2.DirectoryName;
                row["SecondFile"] = compressionResult.File2.FileName;
                row["SimilarityPercent"] = Math.Round((compressionResult.Similarity * 100), 2);
                row["CriticalBorderValue"] = criticalBorderValue;
                row["Method"] = methodName;
                row["PathToFirstFile"] = compressionResult.File1.FullPath;
                row["PathToSecondFile"] = compressionResult.File2.FullPath;
                
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