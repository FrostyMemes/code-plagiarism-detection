using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodePlagiarismDetection.Methods;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Forms
{
    public partial class MainForm : Form
    {
        private static DataTable _comparisionDataTable = null;
        private static IProgress<int> _progressBarValueUpProgress = null;
        private static CancellationTokenSource _cancellationTokenSource = default;
        private static MethodOption _methodOption = MethodOption.ShingleCoefficient;
        private static SearchOption _searchOption = SearchOption.TopDirectoryOnly;
        private static FilePairOption _filePairOption = FilePairOption.CheckFileType;
        private static TableFillOption _tableFillOption = TableFillOption.ClearTable;
        private static bool _isProcessing = false;
        
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
        
        private static readonly Dictionary<MethodOption, SimilairyMethod> _methods 
            = new Dictionary<MethodOption, SimilairyMethod>()
            {
                {MethodOption.Cosine, new Cosine()},
                {MethodOption.LevensteinModify, new LevenshteinModify()},
                {MethodOption.SorensenDiceСoefficient, new SorensenDiceCoefficient()},
                {MethodOption.JaccardCoefficient, new JaccardCoefficient()},
                {MethodOption.NGramDistance, new NGramDistance()},
                {MethodOption.LongestCommonSubsequence, new LongestCommonSubsequence()},
                {MethodOption.JaroWickler, new JaroWickler()},
                {MethodOption.ShingleCoefficient, new ShingleCoefficient()},
            };

        private static Dictionary<MethodOption, RadioButton> _radioButtonsMethodAccordance = null;


        public MainForm()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            ShingleProfiler.N = int.Parse(numUpDownTokenLenghtValue.Text);
            _progressBarValueUpProgress = new Progress<int>(_ => progressProcessingBar.Value++);
            _comparisionDataTable = ComparisonDataTableWorker.CreateFileCoprasionDataTable();
            dataGridComparisionResult.DataSource = _comparisionDataTable;
            _radioButtonsMethodAccordance = new Dictionary<MethodOption, RadioButton>()
            {
                {MethodOption.Cosine, rbCosineMethod},
                {MethodOption.LevensteinModify, rbLevensteinModifyMethod},
                {MethodOption.SorensenDiceСoefficient, rbSorensenDiceMethod},
                {MethodOption.JaccardCoefficient, rbJaccardMethod},
                {MethodOption.NGramDistance, rbNGrammDistanceMethod},
                {MethodOption.LongestCommonSubsequence, rbLongestCommonSubsequenceMethod},
                {MethodOption.JaroWickler, rbJaroWicklerMethod},
                {MethodOption.ShingleCoefficient, rbShingleCoefficientMethod},
            };
            
            
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
        
        private async void btnStartProcessing_Click(object sender, EventArgs e)
        {
            
            if (_isProcessing)
            {
                _cancellationTokenSource.Cancel();
                _isProcessing = false;
                return;
            }
            
            if (!ValidationChecker.CheckValidationOfCurrentDirectory(txtDirectoryPath.Text))
                return;

            _isProcessing = true;
            _cancellationTokenSource = new CancellationTokenSource();
            ShingleProfiler.N = int.Parse(numUpDownTokenLenghtValue.Text);
            
            var directory = new DirectoryInfo(txtDirectoryPath.Text);
            var files = FileLoader.LoadFiles(directory, _searchOption)
                .Select(file => new FileContent(file))
                .ToList();
            var selectedMethod = _radioButtonsMethodAccordance.First(pair => pair.Value.Checked);
            var method = _methods[selectedMethod.Key];
            
            progressProcessingBar.Value = 0;
            progressProcessingBar.Maximum = GetFilePairCount(files);

            var comparisons = await Task.Run(() => 
                method.CompareFilePairwiseAsync(files, _filePairOption, _progressBarValueUpProgress, _cancellationTokenSource.Token));
            _comparisionDataTable = ComparisonDataTableWorker
                .FillComparisionDataTable(_comparisionDataTable, comparisons, selectedMethod.Value.Text, 
                    (int)numUpDownCriticalBorderValue.Value, _tableFillOption);
            _cancellationTokenSource.Dispose();
            _isProcessing = false;
        }

        private void dataGridComparisionResult_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (dataGridComparisionResult.Columns[e.ColumnIndex].DataPropertyName.Equals("SimilarityPercent") &&
                dataGridComparisionResult.Rows[e.RowIndex].Cells[e.ColumnIndex].Value != null)
            {
                var criticalSimilarityBorder = (double)dataGridComparisionResult.Rows[e.RowIndex].Cells["CriticalBorderValue"].Value;
                if ((double)e.Value >= criticalSimilarityBorder)
                    dataGridComparisionResult.Rows[e.RowIndex].DefaultCellStyle.BackColor = Color.Yellow;
            }
        }

        private void btnGenerateExcelReport_Click(object sender, EventArgs e)
        {
            ExcelReportGenerator.GenerateExcelReport(_comparisionDataTable);
        }
        
        private void btnTraceSuspectParts_Click(object sender, EventArgs e)
        {
            if (dataGridComparisionResult.SelectedRows.Count == 0)
                return;
            
            var selectedRow = dataGridComparisionResult.SelectedRows[0];
            var originalFile = (string)selectedRow.Cells["PathToFirstFile"].Value;
            var comparedFilePath = (string)selectedRow.Cells["PathToSecondFile"].Value;
            var reportFileName =
                $"{(string) selectedRow.Cells["FirstFile"].Value}_{(string) selectedRow.Cells["SecondFile"].Value}.html";
            var report = Path.Combine(txtDirectoryPath.Text, reportFileName);
            File.WriteAllText(report, SuspiciousPartTracer.GenerateHtmlReport(originalFile, comparedFilePath));
            System.Diagnostics.Process.Start(report);
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
        
        private int GetFilePairCount(List<FileContent> fileList)
        {
            var count = 0;
            for (int i = 0; i < fileList.Count; i++)
            for (int j = i + 1; j < fileList.Count; j++)
            {
                if (_filePairOption == FilePairOption.CheckFileType && !fileList[i].Extension.Equals(fileList[j].Extension))
                    continue;
                count++;
            }

            return count;
        }
    }
}