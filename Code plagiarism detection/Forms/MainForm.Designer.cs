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
            this.numUpDownTokenLenghtValue = new System.Windows.Forms.NumericUpDown();
            this.cbOptionFillTable = new System.Windows.Forms.CheckBox();
            this.lbComparisionMethods = new System.Windows.Forms.ListBox();
            this.lblSimilarityBorder = new System.Windows.Forms.Label();
            this.lblTokenDividing = new System.Windows.Forms.Label();
            this.numUpDownCriticalBorderValue = new System.Windows.Forms.NumericUpDown();
            this.FirstDirectory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondDirectory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Similarity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RawSimilarityValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathToFirstFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.PathToSecondFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridComparisionResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numUpDownTokenLenghtValue)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numUpDownCriticalBorderValue)).BeginInit();
            this.SuspendLayout();
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(679, 17);
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
            this.txtDirectoryPath.Size = new System.Drawing.Size(657, 20);
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
            this.groupBox1.Size = new System.Drawing.Size(773, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Путь до директории";
            // 
            // btnFilterForm
            // 
            this.btnFilterForm.Location = new System.Drawing.Point(12, 185);
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
            this.progressProcessingBar.Location = new System.Drawing.Point(0, 535);
            this.progressProcessingBar.Name = "progressProcessingBar";
            this.progressProcessingBar.Size = new System.Drawing.Size(799, 23);
            this.progressProcessingBar.TabIndex = 5;
            // 
            // cbOptionSubdirectories
            // 
            this.cbOptionSubdirectories.AutoSize = true;
            this.cbOptionSubdirectories.Location = new System.Drawing.Point(12, 87);
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
            this.cbOptionFileType.Location = new System.Drawing.Point(12, 110);
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
            this.btnStartProcessing.Location = new System.Drawing.Point(595, 214);
            this.btnStartProcessing.Name = "btnStartProcessing";
            this.btnStartProcessing.Size = new System.Drawing.Size(190, 23);
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
            this.dataGridComparisionResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridComparisionResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.FirstDirectory, this.FirstFile, this.SecondDirectory, this.SecondFile, this.Similarity, this.Method, this.RawSimilarityValue, this.PathToFirstFile, this.PathToSecondFile});
            this.dataGridComparisionResult.Location = new System.Drawing.Point(11, 243);
            this.dataGridComparisionResult.Name = "dataGridComparisionResult";
            this.dataGridComparisionResult.RowHeadersVisible = false;
            this.dataGridComparisionResult.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dataGridComparisionResult.Size = new System.Drawing.Size(776, 286);
            this.dataGridComparisionResult.TabIndex = 12;
            this.dataGridComparisionResult.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dataGridComparisionResult_CellFormatting);
            // 
            // numUpDownTokenLenghtValue
            // 
            this.numUpDownTokenLenghtValue.Location = new System.Drawing.Point(12, 159);
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
            this.cbOptionFillTable.Location = new System.Drawing.Point(317, 87);
            this.cbOptionFillTable.Name = "cbOptionFillTable";
            this.cbOptionFillTable.Size = new System.Drawing.Size(125, 17);
            this.cbOptionFillTable.TabIndex = 14;
            this.cbOptionFillTable.Text = "Дополнять таблицу";
            this.cbOptionFillTable.UseVisualStyleBackColor = true;
            this.cbOptionFillTable.CheckedChanged += new System.EventHandler(this.cbOptionFillTable_CheckedChanged);
            // 
            // lbComparisionMethods
            // 
            this.lbComparisionMethods.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lbComparisionMethods.FormattingEnabled = true;
            this.lbComparisionMethods.Items.AddRange(new object[] {"Метод косинуса", "Метод Левенштейна+", "Коэффициент Сёренсена", "Коэффициент Жаккара", "N-расстояние", "Метод НОП", "Метод Яро-Виклера", "Метод шинглов"});
            this.lbComparisionMethods.Location = new System.Drawing.Point(597, 87);
            this.lbComparisionMethods.Name = "lbComparisionMethods";
            this.lbComparisionMethods.Size = new System.Drawing.Size(190, 121);
            this.lbComparisionMethods.TabIndex = 15;
            this.lbComparisionMethods.SelectedIndexChanged += new System.EventHandler(this.lbComparisionMethods_SelectedIndexChanged);
            // 
            // lblSimilarityBorder
            // 
            this.lblSimilarityBorder.Location = new System.Drawing.Point(160, 136);
            this.lblSimilarityBorder.Name = "lblSimilarityBorder";
            this.lblSimilarityBorder.Size = new System.Drawing.Size(100, 17);
            this.lblSimilarityBorder.TabIndex = 16;
            this.lblSimilarityBorder.Text = "Граница схожести";
            // 
            // lblTokenDividing
            // 
            this.lblTokenDividing.Location = new System.Drawing.Point(160, 161);
            this.lblTokenDividing.Name = "lblTokenDividing";
            this.lblTokenDividing.Size = new System.Drawing.Size(100, 17);
            this.lblTokenDividing.TabIndex = 17;
            this.lblTokenDividing.Text = "Разбиение";
            // 
            // numUpDownCriticalBorderValue
            // 
            this.numUpDownCriticalBorderValue.Location = new System.Drawing.Point(12, 133);
            this.numUpDownCriticalBorderValue.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numUpDownCriticalBorderValue.Name = "numUpDownCriticalBorderValue";
            this.numUpDownCriticalBorderValue.Size = new System.Drawing.Size(142, 20);
            this.numUpDownCriticalBorderValue.TabIndex = 18;
            this.numUpDownCriticalBorderValue.Value = new decimal(new int[] {70, 0, 0, 0});
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
            // Method
            // 
            this.Method.DataPropertyName = "Method";
            this.Method.HeaderText = "Метод";
            this.Method.Name = "Method";
            // 
            // RawSimilarityValue
            // 
            this.RawSimilarityValue.DataPropertyName = "RawSimilarityValue";
            this.RawSimilarityValue.HeaderText = "RawSimilarityValue";
            this.RawSimilarityValue.Name = "RawSimilarityValue";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(799, 558);
            this.Controls.Add(this.numUpDownCriticalBorderValue);
            this.Controls.Add(this.lblTokenDividing);
            this.Controls.Add(this.lblSimilarityBorder);
            this.Controls.Add(this.lbComparisionMethods);
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
            this.ResumeLayout(false);
            this.PerformLayout();
        }

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
        private System.Windows.Forms.DataGridViewTextBoxColumn RawSimilarityValue;
        private System.Windows.Forms.DataGridViewTextBoxColumn Method;
        private System.Windows.Forms.DataGridViewTextBoxColumn Similarity;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondDirectory;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn FirstDirectory;
        private System.Windows.Forms.DataGridView dataGridComparisionResult;
        private System.Windows.Forms.NumericUpDown numUpDownTokenLenghtValue;
        private System.Windows.Forms.CheckBox cbOptionFillTable;
        private System.Windows.Forms.ListBox lbComparisionMethods;
        private System.Windows.Forms.Label lblSimilarityBorder;
        private System.Windows.Forms.Label lblTokenDividing;
        private System.Windows.Forms.NumericUpDown numUpDownCriticalBorderValue;

        #endregion
    }
}