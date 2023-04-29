﻿using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using CodePlagiarismDetection.Methods;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Forms
{
    public partial class MainForm : Form
    {
        private DataTable _comparisionDataTable;
        private MethodOption _methodOption = MethodOption.Cosine;
        private SearchOption _searchOption = SearchOption.TopDirectoryOnly;
        private FilePairOption _filePairOption = FilePairOption.CheckFileType;
        private TableFillOption _tableFillOption = TableFillOption.ClearTable;
        
        private enum MethodOption
        {
            Cosine = 0,
            LevensteinModify,
            SorensenDiceСoefficient,
            JaccardCoefficient,
            NGramDistance,
            LongestCommonSubsequence,
            JaroWickler,
            ShingleCoefficient
        }
        
        private readonly Dictionary<MethodOption, SimilairyMethod> _methods 
            = new Dictionary<MethodOption, SimilairyMethod>()
            {
                {MethodOption.Cosine, new Cosine()},
                {MethodOption.LevensteinModify, new LevenshteinModify()},
                {MethodOption.SorensenDiceСoefficient, new SorensenDiceCoefficient()},
                {MethodOption.JaccardCoefficient, new JaccardCoefficient()},
                {MethodOption.NGramDistance, new NGramDistance()},
                {MethodOption.LongestCommonSubsequence, new LongestCommonSubsequence()},
                {MethodOption.JaroWickler, new JaroWickler()},
                {MethodOption.ShingleCoefficient, new ShingleCoefficient()}
            };
        
        public MainForm()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            lbComparisionMethods.SelectedIndex = 0;
            _comparisionDataTable = ComparisonDataTableWorker.CreateFileCoprasionDataTable();
            dataGridComparisionResult.DataSource = _comparisionDataTable;
            ShingleProfiler.N = int.Parse(numUpDownTokenLenghtValue.Text);
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                txtDirectoryPath.Text = folderBrowserDialog.SelectedPath;
        }
        
        private void btnFilterForm_Click(object sender, EventArgs e)
        {
            if (Program.filterForm != null)
            {
                Program.filterForm.Activate();
                return;
            }
            Program.filterForm = new FilterForm();    
            Program.filterForm.Show();
        }

        private void btnStartProcessing_Click(object sender, EventArgs e)
        {
            if (!ValidationChecker.CheckCurrentDirectory(txtDirectoryPath.Text))
                return;

            ShingleProfiler.N = int.Parse(numUpDownTokenLenghtValue.Text);
            var directory = new DirectoryInfo(txtDirectoryPath.Text);
            var files = FileLoader.LoadFiles(directory, _searchOption)
                .Select(file => new FileContent(file))
                .ToList();
            var method = _methods[_methodOption];
            var comparisons = method.CompareFilePairwise(files, _filePairOption);
            _comparisionDataTable = ComparisonDataTableWorker
                .FillComparisionDataTable(_comparisionDataTable, comparisons, lbComparisionMethods.Text, _tableFillOption);
            /*var report = ReportGenerator.GenerateHTMLReport(files[0].FullPath, files[1].FullPath);
            var filePath = Path.Combine(txtDirectoryPath.Text, "report.html");
            File.WriteAllText(filePath, report);*/
        }

        private void dataGridComparisionResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridComparisionResult.Columns[e.ColumnIndex].Name.Equals("RawSimilarityValue") &&
                dataGridComparisionResult.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                var criticalBorder = (double)numUpDownCriticalBorderValue.Value;
                if ((double)e.Value > criticalBorder)
                    dataGridComparisionResult.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                /*double criticalBorder;
                if(Double.TryParse(numUpDownCriticalBorderValue.Value, out criticalBorder) &&
                   ((double)e.Value > criticalBorder))
                {
                    dataGridComparisionResult.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
                }*/
            }
        }
        
        private void lbComparisionMethods_SelectedIndexChanged(object sender, EventArgs e)
        {
            _methodOption = (MethodOption)lbComparisionMethods.SelectedIndex;
        }
        
        private void cbOptionSubdirectories_CheckedChanged(object sender, EventArgs e)
        {
            _searchOption = (cbOptionSubdirectories.Checked)
                ? SearchOption.AllDirectories
                : SearchOption.TopDirectoryOnly;
        }

        private void cbOptionFileType_CheckedChanged(object sender, EventArgs e)
        {
            _filePairOption = (cbOptionFileType.Checked)
                ? FilePairOption.CheckFileType
                : FilePairOption.IgnoreFileType;
        }

        private void cbOptionFillTable_CheckedChanged(object sender, EventArgs e)
        {
            _tableFillOption = (cbOptionFillTable.Checked)
                ? TableFillOption.AddToTable
                : TableFillOption.ClearTable;
        }

    }
}