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
            
            DataColumn column;

            column = new DataColumn()
            {
                DataType = Types.GetType("System.String"),
                ColumnName = "FirstDirectory",
                Caption = "Папка1",
                ReadOnly = true
            };
            table.Columns.Add(column);
            
            column = new DataColumn()
            {
                DataType = Types.GetType("System.String"),
                ColumnName = "FirstFile",
                Caption = "Файл1",
                ReadOnly = true
            };
            table.Columns.Add(column);
            
            column = new DataColumn()
            {
                DataType = Types.GetType("System.String"),
                ColumnName = "SecondFile",
                Caption = "Файл2",
                ReadOnly = true
            };
            table.Columns.Add(column);
            
            column = new DataColumn()
            {
                DataType = Types.GetType("System.String"),
                ColumnName = "SecondDirectory",
                Caption = "Папка2",
                ReadOnly = true
            };
            table.Columns.Add(column);
            
            column = new DataColumn()
            {
                DataType = Types.GetType("System.String"),
                ColumnName = "SimilarityPercent",
                Caption = "Схожесть",
                ReadOnly = true
            };
            table.Columns.Add(column);
            
            column = new DataColumn()
            {
                DataType = Types.GetType("System.String"),
                ColumnName = "Method",
                Caption = "Метод",
                ReadOnly = true
            };
            table.Columns.Add(column);
            
            column = new DataColumn()
            {
                DataType = Types.GetType("System.Double"),
                ColumnName = "RawSimilarityValue",
                Caption = "Схожесть",
                ReadOnly = true
            };
            table.Columns.Add(column);
            
            return table;
        }

        public static DataTable FillComparisionDataTable(DataTable table, IEnumerable<ComparisonResult> comparisions,
            string methodName, TableFillOption option)
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
                row["SimilarityPercent"] = string.Format("{0:0.00%}", compressionResult.Similarity);
                row["Method"] = methodName;
                row["RawSimilarityValue"] = Math.Round((compressionResult.Similarity * 100), 2);
                
                table.Rows.Add(row);
            }
            return table;
        }
    }
}