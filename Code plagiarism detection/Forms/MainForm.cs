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
        private static DataTable _comparisionDataTable = default; //Таблица с результатами обработки файлов
        private static Stack<HashSet<int>> _comparisionDataTableIdHistory = default; //Стек, содержащий множества последних добавленных в таблицу id записей результатов  обработки файлов
        private static IProgress<int> _progressBarValueUpProgress = default; //Обработчик события обработки одной пары файлов 
        private static CancellationTokenSource _cancellationTokenSource = default; //Токен, отвечающий за фиксирования запроса отмены обработки файлов 
        private static PrivateFontCollection _privateFontCollection = default; //Коллекция для загрузки внешних стилей
        private static Dictionary<MethodOption, RadioButton> _radioButtonsMethodAccordance = default; //Словарь соответствия выбранной радиокнопки и метода обработки файлов
        private static SearchOption _searchOption = SearchOption.TopDirectoryOnly; //Опция задания режима чтения файлов из директории
        private static FilePairOption _filePairOption = FilePairOption.CheckFileType; //Опция учета типа файла при попарном сравнении файлов
        private static TableFillOption _tableFillOption = TableFillOption.ClearTable; //Опция учета очистки таблицы при новой обработке
        private static bool _isProcessing = false; //Флаг, идет ли в данный момент обработка файлов
        
        //Перечисление для определения опций-ключей методов обработки файлов
        private enum MethodOption 
        {
            Cosine = 0,
            LevensteinModify,
            SorensenDiceСoefficient,
            JaccardCoefficient,
            NGramDistance,
            LongestCommonSubsequence,
            ShingleCoefficient
        }
        
        //Словарь соответствия элементов опций перечисления методов обработки файлов к объектам-методам обработки файлов
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
            _comparisionDataTableIdHistory = new Stack<HashSet<int>>();
            _progressBarValueUpProgress = new Progress<int>(_ => progressProcessingBar.Value++); //Задание поведения обработчика прогресса обработки файла
            _comparisionDataTable = ComparisonDataTableWorker.CreateFileCoprasionDataTable(); //Создание таблица с результатами
            dataGridComparisionResult.DataSource = _comparisionDataTable; //Определение источника данных для компонента-таблицы
            _radioButtonsMethodAccordance = new Dictionary<MethodOption, RadioButton>() //Задание соответствия радио-кнопки к опции перечисления метода обработки файлов
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

        //Обработчик нажатия на кнопку для открытия системного проводника при нажатии на кнопку обзора
        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK)
                txtDirectoryPath.Text = folderBrowserDialog.SelectedPath;
        }
        
        //Обработчик нажатия на кнопку для отображаение формы для задания фильтра файлов
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
        
        //Обработчик нажатия на кнопку для начала обработки файлов
        private async void btnStartProcessing_Click(object sender, EventArgs e)
        {
            if (_isProcessing)  //Отмена обработки файлов, если она начата
            {
                _cancellationTokenSource.Cancel(); //Отправка запроса на отмену обработки файлов
                _isProcessing = false;
                btnStartProcessing.Text = "Начать обработку";
                toolStripLabelProcessingStatus.Text = "Прервано";
                numUpDownTokenLenghtValue.Enabled = true;
                return;
            }
            
            //Проверка корректности введенного пути файла
            if (!ValidationChecker.CheckValidationOfCurrentDirectory(txtDirectoryPath.Text, MessageBoxShowMode.Show))
                return;

            _isProcessing = true;
            _cancellationTokenSource = new CancellationTokenSource(); //Создание
            ShingleProfiler.N = int.Parse(numUpDownTokenLenghtValue.Text);
            
            var directoryInfo = new DirectoryInfo(txtDirectoryPath.Text); //Получение объекта с информацией о выбранной директории
            var files = FileLoader.LoadFiles(directoryInfo, _searchOption)
                .Select(file => new FileContent(file))
                .ToList(); //Получение списка файлов 
            var selectedMethod = _radioButtonsMethodAccordance.First(pair => pair.Value.Checked); //Получение идентификатора обработчика по радио-кнопке
            var method = _methods[selectedMethod.Key]; //
            
            progressProcessingBar.Value = 0;
            progressProcessingBar.Maximum = GetFilePairCount(files); //Задание длины для полосы прогресса
            btnStartProcessing.Text = "Прервать";
            toolStripLabelProcessingStatus.Text = "Идёт обработка...";
            numUpDownTokenLenghtValue.Enabled = false;

            var comparisonsResult = await Task.Run(() => 
                method.CompareFilePairwise(files, _filePairOption, _progressBarValueUpProgress, _cancellationTokenSource.Token)); //Асинхронный вызов меирда обработки файлов
            
            _comparisionDataTable = ComparisonDataTableWorker.FillComparisionDataTable(_comparisionDataTable, comparisonsResult, 
               _comparisionDataTableIdHistory, selectedMethod.Value.Text, (int)numUpDownCriticalBorderValue.Value, _tableFillOption); //Заполнение таблицы с результатами
            
            toolStripLabelProcessingStatus.Text = _cancellationTokenSource.IsCancellationRequested //Задание инфомрации об обработке
                ? "Прервано"
                : "Обработка завершена";
            _cancellationTokenSource.Dispose(); //Очищение токена отмены обработки
            _isProcessing = false;
            btnStartProcessing.Text = "Начать обработку";
            numUpDownTokenLenghtValue.Enabled = true;
        }

        //Выделение строк с "Подозирительной" парой файлов
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
        
        //Обработчик нажатия мыши на строку таблицы вызова контекстного меню
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
        
        //Отбоаботчик нажатия на иконку стрелки
        private void pictureBoxDeleteLastComparisons_Click(object sender, EventArgs e)
        {
            if (_comparisionDataTableIdHistory.Count.Equals(0))
                return;
            
            var lastComparisons = _comparisionDataTableIdHistory.Pop();
            _comparisionDataTable.AsEnumerable()
                .Where(row => lastComparisons.Contains(row.Field<int>("Id")))
                .ToList()
                .ForEach(row => row.Delete());
            _comparisionDataTable.AcceptChanges();
        }
        
        //Обработчик нажатия на иконку счетки
        private void pictureBoxClearTable_Click(object sender, EventArgs e)
        {
            _comparisionDataTable.Clear();
            _comparisionDataTableIdHistory.Clear();
        }
        
        //Обработчик нажатия на пункт контекстного меню для открытия файлов
        private void открытьФайлыToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridComparisionResult.SelectedRows.Count.Equals(0))
                return;
            
            var selectedRow = dataGridComparisionResult.SelectedRows[0];
            var originalFilePath = (string)selectedRow.Cells["PathToFirstFile"].Value;
            var comparedFilePath = (string)selectedRow.Cells["PathToSecondFile"].Value;
            System.Diagnostics.Process.Start(originalFilePath);
            System.Diagnostics.Process.Start(comparedFilePath);
        }

        //Обработчик нажатия на пункт контекстного меню для открытия файлов
        private void cbOptionFileType_CheckedChanged(object sender, EventArgs e)
        {
            _filePairOption = (cbOptionFileType.Checked)
                ? FilePairOption.CheckFileType
                : FilePairOption.IgnoreFileType;
        }

        //Обработчик нажатия на пункт контекстного меню для открытия файлов
        private void cbOptionFillTable_CheckedChanged(object sender, EventArgs e)
        {
            _tableFillOption = (cbOptionFillTable.Checked)
                ? TableFillOption.AddToTable
                : TableFillOption.ClearTable;
        }

        //Обработчик нажатия на пункт контекстного меню для обнаружения исходы
        private void найтиПодозрительныеЧастиToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridComparisionResult.SelectedRows.Count == 0)
                return;
            
            var selectedRow = dataGridComparisionResult.SelectedRows[0];
            var tempDirectoryPath = Path.GetTempPath();
            var originalFilePath = (string)selectedRow.Cells["PathToFirstFile"].Value;
            var comparedFilePath = (string)selectedRow.Cells["PathToSecondFile"].Value;
            var reportFileName =
                $"{(string) selectedRow.Cells["FirstFile"].Value}_{(string) selectedRow.Cells["SecondFile"].Value}.html";
            var report = Path.Combine(tempDirectoryPath, reportFileName);
            File.WriteAllText(report, SuspiciousPartTracer.GenerateHtmlReport(originalFilePath, comparedFilePath));
            System.Diagnostics.Process.Start(report);
        }
        
        //Обработчик нажатия на пункт контекстного меню для вывода данных в Excel
        private void вывестиДанныеВExcelToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (dataGridComparisionResult.SelectedRows.Count == 0)
                return;
            
            ExcelReportGenerator.GenerateExcelReport(_comparisionDataTable);
        }
        
        //Обработчик нажатия флага на смену режима чтения файлов с выбранной директории
        private void cbOptionSubdirectories_CheckedChanged(object sender, EventArgs e)
        {
            _searchOption = (cbOptionSubdirectories.Checked)
                ? SearchOption.AllDirectories
                : SearchOption.TopDirectoryOnly;
        }

        //Настройка стилей компонетов формы
        private void InitializeComponentCustomStyles()
        {
            _privateFontCollection = LocalFontsCollection.GetPrivateFontCollectionInstance();
            var mainFont = new Font(_privateFontCollection.Families[(int)Fonts.MontserattThin], 11, FontStyle.Regular);
            
            foreach (Control control in this.Controls)
                control.Font = mainFont;
            
            dataGridComparisionResult.RowsDefaultCellStyle.SelectionBackColor = Color.FromArgb(0, 165, 223);

            menuStripMainForm.BackColor = Color.FromArgb(65, 89, 151);
            menuStripMainForm.ForeColor = Color.White;
            menuStripMainForm.Font = new Font(_privateFontCollection.Families[(int)Fonts.MontserattThin], 12, FontStyle.Regular);
        }

        //Настройка обработчиков нажатия на радио-кнопку
        private void InitializeRadioButtonMethodCheckedChangeEvents()
        {
            rbLevensteinModifyMethod.CheckedChanged += ShowLevensteinModifyWarning;
            rbJaccardMethod.CheckedChanged += ShowApproximatelyWarning;
            rbSorensenDiceMethod.CheckedChanged += ShowApproximatelyWarning;
            rbCosineMethod.CheckedChanged += ShowEqualTextLenghtWarning;
            rbNGrammDistanceMethod.CheckedChanged += ShowSequenceWarning;
            rbLongestCommonSubsequenceMethod.CheckedChanged += ShowSequenceWarning;
            rbShingleCoefficientMethod.CheckedChanged += ShowNDivideWarning;
        }

        //Обработчик для вывода сообщения 1
        private void ShowEqualTextLenghtWarning(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                lblMethodDescriptiom.Text = "Внимание!" +
                                            "\nМетод выдает корректные результаты, если два сравниваемых исходных кода приблизительно близки по количеству символов." +
                                            "\nНаиболее оптимальный уровень разбиения на токены для данного метода является 4-5 уровень разбиения.";
                lblMethodDescriptiom.Visible = true;
            }
        }
        
        //Обработчик для вывода сообщения 1
        private void ShowSequenceWarning(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                lblMethodDescriptiom.Text = "Внимание!" +
                                            "\nДля данного метода имеет значение, в каком порядке идут символы и блоки кода в сравнимаемых исходных кодах. " +
                                            "Одинаковые части кода могут быть не распознаны, " +
                                            "если в сравниваемых исходных кодах они находится в разных местах." +
                                            "\nДля N-расстояния наиболее оптимальный уровень разбиения на токены является 6-7 уровень разбиения.";
                lblMethodDescriptiom.Visible = true;
            }
        }
        
        //Обработчик для вывода сообщения 2
        private void ShowApproximatelyWarning(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                lblMethodDescriptiom.Text = "Внимание!" +
                                            "\nМетод выдает приблизительный результат схожести." +
                                            "\nНаиболее оптимальный уровень разбиения на токены для данного метода является 4-5 уровень разбиения.";
                lblMethodDescriptiom.Visible = true;
            }
        }

        //Обработчик для вывода сообщения 3
        private void ShowNDivideWarning(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                lblMethodDescriptiom.Text = "Внимание!" +
                                            "\nНаиболее оптимальный уровень разбиения на токены для данного метода является 4-5 уровень разбиения.";
                lblMethodDescriptiom.Visible = true;
            }
        }
        
        //Обработчик для вывода сообщения 4
        private void ShowLevensteinModifyWarning(object sender, EventArgs e)
        {
            if (((RadioButton)sender).Checked)
            {
                lblMethodDescriptiom.Text = "Внимание!" +
                                            "\nДля данного метода нет необходимости в установке какого-либо значения уровня разбиения на токены" +
                                            "\nОбработка с помощью данного метода может занять некоторое время";
                lblMethodDescriptiom.Visible = true;
            }
        }
        
        //Метод подсчета количества обрабатываемых файлов
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

        //Обработка нажатия на вкладку О Программе
        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (Program.aboutForm != null)
            {
                Program.aboutForm.Activate();
                return;
            }
            Program.aboutForm = new AboutForm();    
            Program.aboutForm.Show();
        }
        
        //Обработка нажатия на вкладку Справка
        private void справкаToolStripMenuItem_Click(object sender, EventArgs e)
        {
            var desc = new DescriptionForm();
            desc.Show();
        }
    }
}