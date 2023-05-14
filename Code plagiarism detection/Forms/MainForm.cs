using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        private static DataTable _comparisionDataTable = default;
        private static IProgress<int> _progressBarValueUpProgress = default;
        private static CancellationTokenSource _cancellationTokenSource = default;
        private static PrivateFontCollection _privateFontCollection = default;
        private static Dictionary<MethodOption, RadioButton> _radioButtonsMethodAccordance = default;
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
        
        private static readonly Dictionary<MethodOption, SimilarityMethod> _methods 
            = new Dictionary<MethodOption, SimilarityMethod>()
            {
                {MethodOption.Cosine, new Cosine()},
                {MethodOption.LevensteinModify, new LevenshteinModify()},
                {MethodOption.SorensenDiceСoefficient, new SorensenDiceCoefficient()},
                {MethodOption.JaccardCoefficient, new JaccardCoefficient()},
                {MethodOption.NGramDistance, new NGramDistance()},
                {MethodOption.LongestCommonSubsequence, new LongestCommonSubsequence()},
                {MethodOption.ShingleCoefficient, new ShingleCoefficient()},
            };
        
        public MainForm()
        {
            InitializeComponent();
            InitializeComponentCustomStyles();
            InitializeRadioButtonMethodCheckedChangeEvents();
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
                btnStartProcessing.Text = "Начать обработку";
                toolStripLabelProcessingStatus.Text = "Прервано";
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
            btnStartProcessing.Text = "Прервать";
            toolStripLabelProcessingStatus.Text = "Идёт обработка...";

            var comparisons = await Task.Run(() => 
                method.CompareFilePairwise(files, _filePairOption, _progressBarValueUpProgress, _cancellationTokenSource.Token));
            _comparisionDataTable = ComparisonDataTableWorker.FillComparisionDataTable(_comparisionDataTable, comparisons, 
                selectedMethod.Value.Text, (int)numUpDownCriticalBorderValue.Value, _tableFillOption);
            
            toolStripLabelProcessingStatus.Text = _cancellationTokenSource.IsCancellationRequested
                ? "Прервано"
                : "Обработка завершена";
            _cancellationTokenSource.Dispose();
            _isProcessing = false;
            btnStartProcessing.Text = "Начать обработку";
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
        
        private void dataGridComparisionResult_CellMouseDown(object sender, DataGridViewCellMouseEventArgs e)
        {
            if (e.RowIndex != -1 && e.ColumnIndex != -1)
            {
                if (e.Button == MouseButtons.Right)
                {
                    DataGridViewRow clickedRow = (sender as DataGridView)?.Rows[e.RowIndex]; 
                    if (clickedRow != null && !clickedRow.Selected)
                        dataGridComparisionResult.CurrentCell = clickedRow.Cells[e.ColumnIndex];
                    
                    var mousePosition = dataGridComparisionResult.PointToClient(Cursor.Position);
                    contextMenuStripDataGridView.Show(dataGridComparisionResult, mousePosition);
                }
            }
        }
        
        private void найтиПодозрительныеЧастиToolStripMenuItem_Click(object sender, EventArgs e)
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
        
        private void вывестиДанныеВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            ExcelReportGenerator.GenerateExcelReport(_comparisionDataTable);
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

        private void InitializeComponentCustomStyles()
        {
            _privateFontCollection = LocalFontsCollection.GetPrivateFontCollectionInstance();
            foreach (Control control in this.Controls)
                control.Font = new Font(_privateFontCollection.Families[(int)Fonts.MontserattThin], 10, FontStyle.Regular);
        }

        private void InitializeRadioButtonMethodCheckedChangeEvents()
        {
            rbLevensteinModifyMethod.CheckedChanged += HideWarning;
            rbJaccardMethod.CheckedChanged += ShowApproximatelyWarning;
            rbSorensenDiceMethod.CheckedChanged += ShowApproximatelyWarning;
            rbCosineMethod.CheckedChanged += ShowEqualTextLenghtWarning;
            rbNGrammDistanceMethod.CheckedChanged += ShowSequenceWarning;
            rbLongestCommonSubsequenceMethod.CheckedChanged += ShowSequenceWarning;
            rbShingleCoefficientMethod.CheckedChanged += ShowNDivideWarning;
        }

        private void ShowEqualTextLenghtWarning(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                lblMethodDescriptiom.Text = "Внимание." +
                                            "\nМетод выдает корректные результаты, если два сравниваемых исходных кода приблизительно близки по количеству символов." +
                                            "\nНаиболее оптимальный уровень разбиения на токены для данного метода является 4-5 уровень разбиения.";
                lblMethodDescriptiom.Visible = true;
            }
        }
        
        private void ShowSequenceWarning(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                lblMethodDescriptiom.Text = "Внимание." +
                                            "\nДля данного метода имеет значение, в каком порядке идут символы и блоки кода в сравнимаемых исходных кодах. " +
                                            "Одинаковые части кода могут быть не распознаны, " +
                                            "если в сравниваемых исходных кодах они находится в разных местах." +
                                            "\nДля N-расстояния наиболее оптимальный уровень разбиения на токены для данного метода является 6-7 уровень разбиения.";
                lblMethodDescriptiom.Visible = true;
            }
        }
        
        private void ShowApproximatelyWarning(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                lblMethodDescriptiom.Text = "Внимание." +
                                            "\nМетод выдает приблизительный результат схожести." +
                                            "\nНаиболее оптимальный уровень разбиения на токены для данного метода является 4-5 уровень разбиения.";
                lblMethodDescriptiom.Visible = true;
            }
        }

        private void ShowNDivideWarning(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                lblMethodDescriptiom.Text = "Внимание." +
                                            "\nНаиболее оптимальный уровень разбиения на токены для данного метода является 4-5 уровень разбиения.";
                lblMethodDescriptiom.Visible = true;
            }
        }
        
        private void HideWarning(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
                lblMethodDescriptiom.Visible = false;
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