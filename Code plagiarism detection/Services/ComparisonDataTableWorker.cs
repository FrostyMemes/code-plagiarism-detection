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
                ColumnName = "Similarity",
                Caption = "Схожесть",
                ReadOnly = true
            };
            table.Columns.Add(column);
            
            return table;
        }

        public static DataTable FillComparisionDataTable(DataTable table, IEnumerable<ComparisonResult> comparisions)
        {
            DataRow row;
            var comprassionList = comparisions.ToList();
            foreach (var compressionResult in comprassionList)
            {
                row = table.NewRow();
                row["FirstFile"] = compressionResult.File1.FileName;
                row["SecondFile"] = compressionResult.File2.FileName;
                row["Similarity"] = compressionResult.Similarity.ToString();
                table.Rows.Add(row);
            }
            return table;
        }
    }
}