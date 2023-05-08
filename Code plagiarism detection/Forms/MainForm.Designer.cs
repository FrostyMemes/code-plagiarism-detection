namespace CodePlagiarismDetection.Forms
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btnBrowse = new System.Windows.Forms.Button();
            this.txtDirectoryPath = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnFilterForm = new System.Windows.Forms.Button();
            this.progressProcessingBar = new System.Windows.Forms.ProgressBar();
            this.cbOptionSubdirectories = new System.Windows.Forms.CheckBox();
            this.cbOptionFileType = new System.Windows.Forms.CheckBox();
            this.ProcessingStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnStartProcessing = new System.Windows.Forms.Button();
            this.dataGridComparisionResult = new System.Windows.Forms.DataGridView();
            this.FirstDirectory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondDirectory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Similarity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.CriticalBorderValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathToFirstFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathToSecondFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numUpDownTokenLenghtValue = new System.Windows.Forms.NumericUpDown();
            this.cbOptionFillTable = new System.Windows.Forms.CheckBox();
            this.lblSimilarityBorder = new System.Windows.Forms.Label();
            this.lblTokenDividing = new System.Windows.Forms.Label();
            this.numUpDownCriticalBorderValue = new System.Windows.Forms.NumericUpDown();
            this.btnGenerateExcelReport = new System.Windows.Forms.Button();
            this.gbSimilarityMethods = new System.Windows.Forms.GroupBox();
            this.rbJaroWicklerMethod = new System.Windows.Forms.RadioButton();
            this.rbLongestCommonSubsequenceMethod = new System.Windows.Forms.RadioButton();
            this.rbShingleCoefficientMethod = new System.Windows.Forms.RadioButton();
            this.rbCosineMethod = new System.Windows.Forms.RadioButton();
            this.rbNGrammDistanceMethod = new System.Windows.Forms.RadioButton();
            this.rbJaccardMethod = new System.Windows.Forms.RadioButton();
            this.rbSorensenDiceMethod = new System.Windows.Forms.RadioButton();
            this.rbLevensteinModifyMethod = new System.Windows.Forms.RadioButton();
            this.btnTraceSuspectParts = new System.Windows.Forms.Button();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridComparisionResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numUpDownTokenLenghtValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numUpDownCriticalBorderValue)).BeginInit();
            this.gbSimilarityMethods.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(749, 17);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(85, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Обзор";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // txtDirectoryPath
            // 
            this.txtDirectoryPath.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectoryPath.Location = new System.Drawing.Point(6, 20);
            this.txtDirectoryPath.Name = "txtDirectoryPath";
            this.txtDirectoryPath.Size = new System.Drawing.Size(727, 20);
            this.txtDirectoryPath.TabIndex = 0;
            this.txtDirectoryPath.Text = "D:\\Projects\\C Sharp Projects\\CodePlagiarismDetection\\ModuleTests\\CodeExamples\\CSh" + "arp";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtDirectoryPath);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(843, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Путь до директории";
            // 
            // btnFilterForm
            // 
            this.btnFilterForm.Location = new System.Drawing.Point(11, 211);
            this.btnFilterForm.Name = "btnFilterForm";
            this.btnFilterForm.Size = new System.Drawing.Size(142, 23);
            this.btnFilterForm.TabIndex = 4;
            this.btnFilterForm.Text = "Фильтр файлов";
            this.btnFilterForm.UseVisualStyleBackColor = true;
            this.btnFilterForm.Click += new System.EventHandler(this.btnFilterForm_Click);
            // 
            // progressProcessingBar
            // 
            this.progressProcessingBar.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressProcessingBar.Location = new System.Drawing.Point(0, 724);
            this.progressProcessingBar.Name = "progressProcessingBar";
            this.progressProcessingBar.Size = new System.Drawing.Size(869, 23);
            this.progressProcessingBar.TabIndex = 5;
            // 
            // cbOptionSubdirectories
            // 
            this.cbOptionSubdirectories.AutoSize = true;
            this.cbOptionSubdirectories.Location = new System.Drawing.Point(12, 90);
            this.cbOptionSubdirectories.Name = "cbOptionSubdirectories";
            this.cbOptionSubdirectories.Size = new System.Drawing.Size(172, 17);
            this.cbOptionSubdirectories.TabIndex = 7;
            this.cbOptionSubdirectories.Text = "Сканировать поддиректории";
            this.cbOptionSubdirectories.UseVisualStyleBackColor = true;
            this.cbOptionSubdirectories.CheckedChanged += new System.EventHandler(this.cbOptionSubdirectories_CheckedChanged);
            // 
            // cbOptionFileType
            // 
            this.cbOptionFileType.AutoSize = true;
            this.cbOptionFileType.Checked = true;
            this.cbOptionFileType.CheckState = System.Windows.Forms.CheckState.Checked;
            this.cbOptionFileType.Location = new System.Drawing.Point(12, 113);
            this.cbOptionFileType.Name = "cbOptionFileType";
            this.cbOptionFileType.Size = new System.Drawing.Size(278, 17);
            this.cbOptionFileType.TabIndex = 8;
            this.cbOptionFileType.Text = "Сканировать файлы с одинаковым расширением";
            this.cbOptionFileType.UseVisualStyleBackColor = true;
            this.cbOptionFileType.CheckedChanged += new System.EventHandler(this.cbOptionFileType_CheckedChanged);
            // 
            // ProcessingStatusLabel
            // 
            this.ProcessingStatusLabel.Name = "ProcessingStatusLabel";
            this.ProcessingStatusLabel.Size = new System.Drawing.Size(153, 17);
            this.ProcessingStatusLabel.Text = "Обработка Файл1 и Файл2";
            // 
            // btnStartProcessing
            // 
            this.btnStartProcessing.Location = new System.Drawing.Point(593, 309);
            this.btnStartProcessing.Name = "btnStartProcessing";
            this.btnStartProcessing.Size = new System.Drawing.Size(262, 23);
            this.btnStartProcessing.TabIndex = 11;
            this.btnStartProcessing.Text = "Начать проверку";
            this.btnStartProcessing.UseVisualStyleBackColor = true;
            this.btnStartProcessing.Click += new System.EventHandler(this.btnStartProcessing_Click);
            // 
            // dataGridComparisionResult
            // 
            this.dataGridComparisionResult.AllowUserToAddRows = false;
            this.dataGridComparisionResult.AllowUserToDeleteRows = false;
            this.dataGridComparisionResult.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridComparisionResult.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dataGridComparisionResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridComparisionResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.FirstDirectory, this.FirstFile, this.SecondDirectory, this.SecondFile, this.Similarity, this.CriticalBorderValue, this.Method, this.PathToFirstFile, this.PathToSecondFile});
            this.dataGridComparisionResult.Location = new System.Drawing.Point(9, 338);
            this.dataGridComparisionResult.MultiSelect = false;
            this.dataGridComparisionResult.Name = "dataGridComparisionResult";
            this.dataGridComparisionResult.RowHeadersVisible = false;
            this.dataGridComparisionResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridComparisionResult.Size = new System.Drawing.Size(846, 380);
            this.dataGridComparisionResult.TabIndex = 12;
            this.dataGridComparisionResult.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridComparisionResult_CellFormatting);
            // 
            // FirstDirectory
            // 
            this.FirstDirectory.DataPropertyName = "FirstDirectory";
            this.FirstDirectory.HeaderText = "Папка1";
            this.FirstDirectory.Name = "FirstDirectory";
            this.FirstDirectory.ReadOnly = true;
            // 
            // FirstFile
            // 
            this.FirstFile.DataPropertyName = "FirstFile";
            this.FirstFile.HeaderText = "Файл1";
            this.FirstFile.Name = "FirstFile";
            // 
            // SecondDirectory
            // 
            this.SecondDirectory.DataPropertyName = "SecondDirectory";
            this.SecondDirectory.HeaderText = "Папка2";
            this.SecondDirectory.Name = "SecondDirectory";
            this.SecondDirectory.ReadOnly = true;
            // 
            // SecondFile
            // 
            this.SecondFile.DataPropertyName = "SecondFile";
            this.SecondFile.HeaderText = "Файл2";
            this.SecondFile.Name = "SecondFile";
            // 
            // Similarity
            // 
            this.Similarity.DataPropertyName = "SimilarityPercent";
            this.Similarity.HeaderText = "Схожесть %";
            this.Similarity.Name = "Similarity";
            // 
            // CriticalBorderValue
            // 
            this.CriticalBorderValue.DataPropertyName = "CriticalBorderValue";
            this.CriticalBorderValue.HeaderText = "Порог схожести";
            this.CriticalBorderValue.Name = "CriticalBorderValue";
            // 
            // Method
            // 
            this.Method.DataPropertyName = "Method";
            this.Method.HeaderText = "Метод";
            this.Method.Name = "Method";
            // 
            // PathToFirstFile
            // 
            this.PathToFirstFile.DataPropertyName = "PathToFirstFile";
            this.PathToFirstFile.HeaderText = "PathToFirstFile";
            this.PathToFirstFile.Name = "PathToFirstFile";
            this.PathToFirstFile.Visible = false;
            // 
            // PathToSecondFile
            // 
            this.PathToSecondFile.DataPropertyName = "PathToSecondFile";
            this.PathToSecondFile.HeaderText = "PathToSecondFile";
            this.PathToSecondFile.Name = "PathToSecondFile";
            this.PathToSecondFile.Visible = false;
            // 
            // numUpDownTokenLenghtValue
            // 
            this.numUpDownTokenLenghtValue.Location = new System.Drawing.Point(11, 185);
            this.numUpDownTokenLenghtValue.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numUpDownTokenLenghtValue.Name = "numUpDownTokenLenghtValue";
            this.numUpDownTokenLenghtValue.ReadOnly = true;
            this.numUpDownTokenLenghtValue.Size = new System.Drawing.Size(142, 20);
            this.numUpDownTokenLenghtValue.TabIndex = 13;
            this.numUpDownTokenLenghtValue.Value = new decimal(new int[] {3, 0, 0, 0});
            // 
            // cbOptionFillTable
            // 
            this.cbOptionFillTable.AutoSize = true;
            this.cbOptionFillTable.Location = new System.Drawing.Point(11, 136);
            this.cbOptionFillTable.Name = "cbOptionFillTable";
            this.cbOptionFillTable.Size = new System.Drawing.Size(125, 17);
            this.cbOptionFillTable.TabIndex = 14;
            this.cbOptionFillTable.Text = "Дополнять таблицу";
            this.cbOptionFillTable.UseVisualStyleBackColor = true;
            this.cbOptionFillTable.CheckedChanged += new System.EventHandler(this.cbOptionFillTable_CheckedChanged);
            // 
            // lblSimilarityBorder
            // 
            this.lblSimilarityBorder.Location = new System.Drawing.Point(159, 162);
            this.lblSimilarityBorder.Name = "lblSimilarityBorder";
            this.lblSimilarityBorder.Size = new System.Drawing.Size(159, 17);
            this.lblSimilarityBorder.TabIndex = 16;
            this.lblSimilarityBorder.Text = "Процентный порог схожести";
            // 
            // lblTokenDividing
            // 
            this.lblTokenDividing.Location = new System.Drawing.Point(159, 187);
            this.lblTokenDividing.Name = "lblTokenDividing";
            this.lblTokenDividing.Size = new System.Drawing.Size(169, 17);
            this.lblTokenDividing.TabIndex = 17;
            this.lblTokenDividing.Text = "Уровень разбиения на токены";
            // 
            // numUpDownCriticalBorderValue
            // 
            this.numUpDownCriticalBorderValue.Location = new System.Drawing.Point(11, 159);
            this.numUpDownCriticalBorderValue.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numUpDownCriticalBorderValue.Name = "numUpDownCriticalBorderValue";
            this.numUpDownCriticalBorderValue.Size = new System.Drawing.Size(142, 20);
            this.numUpDownCriticalBorderValue.TabIndex = 18;
            this.numUpDownCriticalBorderValue.Value = new decimal(new int[] {70, 0, 0, 0});
            // 
            // btnGenerateExcelReport
            // 
            this.btnGenerateExcelReport.Location = new System.Drawing.Point(9, 309);
            this.btnGenerateExcelReport.Name = "btnGenerateExcelReport";
            this.btnGenerateExcelReport.Size = new System.Drawing.Size(189, 23);
            this.btnGenerateExcelReport.TabIndex = 19;
            this.btnGenerateExcelReport.Text = "Вывести данные в Excel";
            this.btnGenerateExcelReport.UseVisualStyleBackColor = true;
            this.btnGenerateExcelReport.Click += new System.EventHandler(this.btnGenerateExcelReport_Click);
            // 
            // gbSimilarityMethods
            // 
            this.gbSimilarityMethods.Controls.Add(this.rbJaroWicklerMethod);
            this.gbSimilarityMethods.Controls.Add(this.rbLongestCommonSubsequenceMethod);
            this.gbSimilarityMethods.Controls.Add(this.rbShingleCoefficientMethod);
            this.gbSimilarityMethods.Controls.Add(this.rbCosineMethod);
            this.gbSimilarityMethods.Controls.Add(this.rbNGrammDistanceMethod);
            this.gbSimilarityMethods.Controls.Add(this.rbJaccardMethod);
            this.gbSimilarityMethods.Controls.Add(this.rbSorensenDiceMethod);
            this.gbSimilarityMethods.Controls.Add(this.rbLevensteinModifyMethod);
            this.gbSimilarityMethods.Location = new System.Drawing.Point(593, 71);
            this.gbSimilarityMethods.Name = "gbSimilarityMethods";
            this.gbSimilarityMethods.Size = new System.Drawing.Size(262, 232);
            this.gbSimilarityMethods.TabIndex = 20;
            this.gbSimilarityMethods.TabStop = false;
            this.gbSimilarityMethods.Text = "Методы сравнения";
            // 
            // rbJaroWicklerMethod
            // 
            this.rbJaroWicklerMethod.Location = new System.Drawing.Point(24, 69);
            this.rbJaroWicklerMethod.Name = "rbJaroWicklerMethod";
            this.rbJaroWicklerMethod.Size = new System.Drawing.Size(215, 24);
            this.rbJaroWicklerMethod.TabIndex = 6;
            this.rbJaroWicklerMethod.Text = "Метод Яро-Виклера";
            this.rbJaroWicklerMethod.UseVisualStyleBackColor = true;
            // 
            // rbLongestCommonSubsequenceMethod
            // 
            this.rbLongestCommonSubsequenceMethod.Location = new System.Drawing.Point(24, 194);
            this.rbLongestCommonSubsequenceMethod.Name = "rbLongestCommonSubsequenceMethod";
            this.rbLongestCommonSubsequenceMethod.Size = new System.Drawing.Size(215, 24);
            this.rbLongestCommonSubsequenceMethod.TabIndex = 5;
            this.rbLongestCommonSubsequenceMethod.Text = "Метод НОП";
            this.rbLongestCommonSubsequenceMethod.UseVisualStyleBackColor = true;
            // 
            // rbShingleCoefficientMethod
            // 
            this.rbShingleCoefficientMethod.Checked = true;
            this.rbShingleCoefficientMethod.Location = new System.Drawing.Point(24, 19);
            this.rbShingleCoefficientMethod.Name = "rbShingleCoefficientMethod";
            this.rbShingleCoefficientMethod.Size = new System.Drawing.Size(215, 24);
            this.rbShingleCoefficientMethod.TabIndex = 7;
            this.rbShingleCoefficientMethod.TabStop = true;
            this.rbShingleCoefficientMethod.Text = "Метод шинглов";
            this.rbShingleCoefficientMethod.UseVisualStyleBackColor = true;
            // 
            // rbCosineMethod
            // 
            this.rbCosineMethod.Location = new System.Drawing.Point(24, 94);
            this.rbCosineMethod.Name = "rbCosineMethod";
            this.rbCosineMethod.Size = new System.Drawing.Size(215, 24);
            this.rbCosineMethod.TabIndex = 0;
            this.rbCosineMethod.Text = "Метод косинуса";
            this.rbCosineMethod.UseVisualStyleBackColor = true;
            // 
            // rbNGrammDistanceMethod
            // 
            this.rbNGrammDistanceMethod.Location = new System.Drawing.Point(24, 169);
            this.rbNGrammDistanceMethod.Name = "rbNGrammDistanceMethod";
            this.rbNGrammDistanceMethod.Size = new System.Drawing.Size(215, 24);
            this.rbNGrammDistanceMethod.TabIndex = 4;
            this.rbNGrammDistanceMethod.Text = "N-расстояние";
            this.rbNGrammDistanceMethod.UseVisualStyleBackColor = true;
            // 
            // rbJaccardMethod
            // 
            this.rbJaccardMethod.Location = new System.Drawing.Point(24, 144);
            this.rbJaccardMethod.Name = "rbJaccardMethod";
            this.rbJaccardMethod.Size = new System.Drawing.Size(215, 24);
            this.rbJaccardMethod.TabIndex = 3;
            this.rbJaccardMethod.Text = "Коэффициент Жаккара";
            this.rbJaccardMethod.UseVisualStyleBackColor = true;
            // 
            // rbSorensenDiceMethod
            // 
            this.rbSorensenDiceMethod.Location = new System.Drawing.Point(24, 119);
            this.rbSorensenDiceMethod.Name = "rbSorensenDiceMethod";
            this.rbSorensenDiceMethod.Size = new System.Drawing.Size(215, 24);
            this.rbSorensenDiceMethod.TabIndex = 2;
            this.rbSorensenDiceMethod.Text = "Коэфиициент Сёренсена";
            this.rbSorensenDiceMethod.UseVisualStyleBackColor = true;
            // 
            // rbLevensteinModifyMethod
            // 
            this.rbLevensteinModifyMethod.Location = new System.Drawing.Point(24, 44);
            this.rbLevensteinModifyMethod.Name = "rbLevensteinModifyMethod";
            this.rbLevensteinModifyMethod.Size = new System.Drawing.Size(215, 24);
            this.rbLevensteinModifyMethod.TabIndex = 1;
            this.rbLevensteinModifyMethod.Text = "Метод Левинштейна+";
            this.rbLevensteinModifyMethod.UseVisualStyleBackColor = true;
            // 
            // btnTraceSuspectParts
            // 
            this.btnTraceSuspectParts.Location = new System.Drawing.Point(204, 309);
            this.btnTraceSuspectParts.Name = "btnTraceSuspectParts";
            this.btnTraceSuspectParts.Size = new System.Drawing.Size(189, 23);
            this.btnTraceSuspectParts.TabIndex = 21;
            this.btnTraceSuspectParts.Text = "Найти подозрительные части";
            this.btnTraceSuspectParts.UseVisualStyleBackColor = true;
            this.btnTraceSuspectParts.Click += new System.EventHandler(this.btnTraceSuspectParts_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Window;
            this.ClientSize = new System.Drawing.Size(869, 747);
            this.Controls.Add(this.btnTraceSuspectParts);
            this.Controls.Add(this.gbSimilarityMethods);
            this.Controls.Add(this.btnGenerateExcelReport);
            this.Controls.Add(this.numUpDownCriticalBorderValue);
            this.Controls.Add(this.lblTokenDividing);
            this.Controls.Add(this.lblSimilarityBorder);
            this.Controls.Add(this.cbOptionFillTable);
            this.Controls.Add(this.numUpDownTokenLenghtValue);
            this.Controls.Add(this.dataGridComparisionResult);
            this.Controls.Add(this.btnStartProcessing);
            this.Controls.Add(this.cbOptionFileType);
            this.Controls.Add(this.cbOptionSubdirectories);
            this.Controls.Add(this.progressProcessingBar);
            this.Controls.Add(this.btnFilterForm);
            this.Controls.Add(this.groupBox1);
            this.Location = new System.Drawing.Point(15, 15);
            this.Name = "MainForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridComparisionResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numUpDownTokenLenghtValue)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numUpDownCriticalBorderValue)).EndInit();
            this.gbSimilarityMethods.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Button btnTraceSuspectParts;

        private System.Windows.Forms.DataGridViewTextBoxColumn CriticalBorderValue;

        private System.Windows.Forms.RadioButton rbCosineMethod;
        private System.Windows.Forms.RadioButton rbLevensteinModifyMethod;
        private System.Windows.Forms.RadioButton rbSorensenDiceMethod;
        private System.Windows.Forms.RadioButton rbJaccardMethod;
        private System.Windows.Forms.RadioButton rbNGrammDistanceMethod;
        private System.Windows.Forms.RadioButton rbLongestCommonSubsequenceMethod;
        private System.Windows.Forms.RadioButton rbJaroWicklerMethod;
        private System.Windows.Forms.RadioButton rbShingleCoefficientMethod;

        private System.Windows.Forms.GroupBox gbSimilarityMethods;

        private System.Windows.Forms.Button btnGenerateExcelReport;

        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.TextBox txtDirectoryPath;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btnFilterForm;
        private System.Windows.Forms.ProgressBar progressProcessingBar;
        private System.Windows.Forms.CheckBox cbOptionSubdirectories;
        private System.Windows.Forms.CheckBox cbOptionFileType;
        private System.Windows.Forms.ToolStripStatusLabel ProcessingStatusLabel;
        private System.Windows.Forms.Button btnStartProcessing;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathToSecondFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn PathToFirstFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Method;
        private System.Windows.Forms.DataGridViewTextBoxColumn Similarity;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondDirectory;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstDirectory;
        private System.Windows.Forms.DataGridView dataGridComparisionResult;
        private System.Windows.Forms.NumericUpDown numUpDownTokenLenghtValue;
        private System.Windows.Forms.CheckBox cbOptionFillTable;
        private System.Windows.Forms.Label lblSimilarityBorder;
        private System.Windows.Forms.Label lblTokenDividing;
        private System.Windows.Forms.NumericUpDown numUpDownCriticalBorderValue;

        #endregion
    }
}