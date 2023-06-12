using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;

using Types = System.Type;

namespace CodePlagiarismDetection.Services
{
    //Класс для работы с таблицей результатов
    public static class ComparisonDataTableWorker
    {
        //Конструктор таблицы с результатами
        public static DataTable CreateFileCoprasionDataTable()
        {
            var table = new DataTable("FileComrassionResult");
            table.Columns.Add(AddColumn("Id", "System.Int32", "Id", true));
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

        //Метод заполнения таблицы с результатами
        public static DataTable FillComparisionDataTable(DataTable comparisonDataTable, 
            IEnumerable<ComparisonResult> comparisons,
            Stack<HashSet<int>> historyStore, 
            string methodName, 
            int criticalBorderValue, 
            TableFillOption fillOption
            )
        {
            DataRow row = default;
            
            var id = 0;
            var idNewComparisons = new HashSet<int>(); 
            var comparisonResults = comparisons.ToList();

            if (fillOption == TableFillOption.ClearTable)
            {
                comparisonDataTable.Clear();
                historyStore.Clear();
            }

            if (fillOption == TableFillOption.AddToTable && !comparisonDataTable.Rows.Count.Equals(0))
                id = comparisonDataTable.AsEnumerable().Max(r => r.Field<int>("Id"));
            
            foreach (var comparison in comparisonResults)
            {
                row = comparisonDataTable.NewRow();
                row["Id"] = ++id;
                row["FirstDirectory"] = comparison.OriginalFile.DirectoryName;
                row["FirstFile"] = comparison.OriginalFile.FileName;
                row["SecondDirectory"] = comparison.ComparedFile.DirectoryName;
                row["SecondFile"] = comparison.ComparedFile.FileName;
                row["SimilarityPercent"] = Math.Round((comparison.Similarity * 100), 2);
                row["CriticalBorderValue"] = criticalBorderValue;
                row["Method"] = methodName;
                row["PathToFirstFile"] = comparison.OriginalFile.FullPath;
                row["PathToSecondFile"] = comparison.ComparedFile.FullPath;

                idNewComparisons.Add(id);
                comparisonDataTable.Rows.Add(row);
            }
            
            historyStore.Push(idNewComparisons);
            return comparisonDataTable;
        }

        //Метод создания столбца таблицы
        private static DataColumn AddColumn(string columnName, 
            string type,  
            string caption, 
            bool readonlyMode
            )
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