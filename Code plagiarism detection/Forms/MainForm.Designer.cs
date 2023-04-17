namespace CodePlagiarismDetection
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
            this.txtDirectoryPath = new System.Windows.Forms.TextBox();
            this.btnBrowse = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.справкаToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.btnFilterForm = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.txtCriticalValue = new System.Windows.Forms.TextBox();
            this.cbOptionSubdirectories = new System.Windows.Forms.CheckBox();
            this.cbOptionFileType = new System.Windows.Forms.CheckBox();
            this.ProcessingStatusLabel = new System.Windows.Forms.ToolStripStatusLabel();
            this.ProcessingStatusStrip = new System.Windows.Forms.StatusStrip();
            this.btnStartProcessing = new System.Windows.Forms.Button();
            this.dataGridComparisionResult = new System.Windows.Forms.DataGridView();
            this.FirstDirectory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.FirstFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondDirectory = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Similarity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Method = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.RawSimilarityValue = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numUpDownCriticalValue = new System.Windows.Forms.NumericUpDown();
            this.cbOptionFillTable = new System.Windows.Forms.CheckBox();
            this.lbComparisionMethods = new System.Windows.Forms.ListBox();
            this.lblSimilarityBorder = new System.Windows.Forms.Label();
            this.lblTokenDividing = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.menu.SuspendLayout();
            this.ProcessingStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridComparisionResult)).BeginInit();
            ((System.ComponentModel.ISupportInitialize) (this.numUpDownCriticalValue)).BeginInit();
            this.SuspendLayout();
            // 
            // txtDirectoryPath
            // 
            this.txtDirectoryPath.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtDirectoryPath.Location = new System.Drawing.Point(6, 20);
            this.txtDirectoryPath.Name = "txtDirectoryPath";
            this.txtDirectoryPath.ReadOnly = true;
            this.txtDirectoryPath.Size = new System.Drawing.Size(636, 20);
            this.txtDirectoryPath.TabIndex = 0;
            this.txtDirectoryPath.Text = "D:\\Projects\\C Sharp Projects\\CodePlagiarismDetection\\ModuleTests\\CodeExamples\\CSh" + "arp";
            // 
            // btnBrowse
            // 
            this.btnBrowse.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnBrowse.Location = new System.Drawing.Point(658, 17);
            this.btnBrowse.Name = "btnBrowse";
            this.btnBrowse.Size = new System.Drawing.Size(85, 23);
            this.btnBrowse.TabIndex = 1;
            this.btnBrowse.Text = "Обзор";
            this.btnBrowse.UseVisualStyleBackColor = true;
            this.btnBrowse.Click += new System.EventHandler(this.btnBrowse_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles) (((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.txtDirectoryPath);
            this.groupBox1.Controls.Add(this.btnBrowse);
            this.groupBox1.Location = new System.Drawing.Point(12, 36);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(752, 53);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Путь до директории";
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.справкаToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(778, 24);
            this.menu.TabIndex = 3;
            this.menu.Text = "menuStrip1";
            // 
            // справкаToolStripMenuItem
            // 
            this.справкаToolStripMenuItem.Name = "справкаToolStripMenuItem";
            this.справкаToolStripMenuItem.Size = new System.Drawing.Size(65, 20);
            this.справкаToolStripMenuItem.Text = "Справка";
            // 
            // btnFilterForm
            // 
            this.btnFilterForm.Location = new System.Drawing.Point(12, 209);
            this.btnFilterForm.Name = "btnFilterForm";
            this.btnFilterForm.Size = new System.Drawing.Size(142, 23);
            this.btnFilterForm.TabIndex = 4;
            this.btnFilterForm.Text = "Фильтр";
            this.btnFilterForm.UseVisualStyleBackColor = true;
            this.btnFilterForm.Click += new System.EventHandler(this.btnFilterForm_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.progressBar1.Location = new System.Drawing.Point(0, 535);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(778, 23);
            this.progressBar1.TabIndex = 5;
            // 
            // txtCriticalValue
            // 
            this.txtCriticalValue.Location = new System.Drawing.Point(11, 157);
            this.txtCriticalValue.Name = "txtCriticalValue";
            this.txtCriticalValue.Size = new System.Drawing.Size(142, 20);
            this.txtCriticalValue.TabIndex = 6;
            this.txtCriticalValue.Text = "70";
            // 
            // cbOptionSubdirectories
            // 
            this.cbOptionSubdirectories.AutoSize = true;
            this.cbOptionSubdirectories.Location = new System.Drawing.Point(12, 111);
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
            this.cbOptionFileType.Location = new System.Drawing.Point(12, 134);
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
            // ProcessingStatusStrip
            // 
            this.ProcessingStatusStrip.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {this.ProcessingStatusLabel});
            this.ProcessingStatusStrip.Location = new System.Drawing.Point(0, 513);
            this.ProcessingStatusStrip.Name = "ProcessingStatusStrip";
            this.ProcessingStatusStrip.Size = new System.Drawing.Size(778, 22);
            this.ProcessingStatusStrip.SizingGrip = false;
            this.ProcessingStatusStrip.TabIndex = 10;
            this.ProcessingStatusStrip.Text = "statusStrip1";
            // 
            // btnStartProcessing
            // 
            this.btnStartProcessing.Location = new System.Drawing.Point(12, 238);
            this.btnStartProcessing.Name = "btnStartProcessing";
            this.btnStartProcessing.Size = new System.Drawing.Size(142, 23);
            this.btnStartProcessing.TabIndex = 11;
            this.btnStartProcessing.Text = "Начать";
            this.btnStartProcessing.UseVisualStyleBackColor = true;
            this.btnStartProcessing.Click += new System.EventHandler(this.btnStartProcessing_Click);
            // 
            // dataGridComparisionResult
            // 
            this.dataGridComparisionResult.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridComparisionResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridComparisionResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.FirstDirectory, this.FirstFile, this.SecondDirectory, this.SecondFile, this.Similarity, this.Method, this.RawSimilarityValue});
            this.dataGridComparisionResult.Location = new System.Drawing.Point(11, 267);
            this.dataGridComparisionResult.Name = "dataGridComparisionResult";
            this.dataGridComparisionResult.Size = new System.Drawing.Size(755, 243);
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
            this.Similarity.HeaderText = "Схожесть";
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
            // numUpDownCriticalValue
            // 
            this.numUpDownCriticalValue.Location = new System.Drawing.Point(12, 183);
            this.numUpDownCriticalValue.Minimum = new decimal(new int[] {1, 0, 0, 0});
            this.numUpDownCriticalValue.Name = "numUpDownCriticalValue";
            this.numUpDownCriticalValue.ReadOnly = true;
            this.numUpDownCriticalValue.Size = new System.Drawing.Size(142, 20);
            this.numUpDownCriticalValue.TabIndex = 13;
            this.numUpDownCriticalValue.Value = new decimal(new int[] {2, 0, 0, 0});
            this.numUpDownCriticalValue.ValueChanged += new System.EventHandler(this.numUpDownCriticalValue_ValueChanged);
            // 
            // cbOptionFillTable
            // 
            this.cbOptionFillTable.AutoSize = true;
            this.cbOptionFillTable.Location = new System.Drawing.Point(307, 111);
            this.cbOptionFillTable.Name = "cbOptionFillTable";
            this.cbOptionFillTable.Size = new System.Drawing.Size(125, 17);
            this.cbOptionFillTable.TabIndex = 14;
            this.cbOptionFillTable.Text = "Дополнять таблицу";
            this.cbOptionFillTable.UseVisualStyleBackColor = true;
            this.cbOptionFillTable.CheckedChanged += new System.EventHandler(this.cbOptionFillTable_CheckedChanged);
            // 
            // lbComparisionMethods
            // 
            this.lbComparisionMethods.FormattingEnabled = true;
            this.lbComparisionMethods.Items.AddRange(new object[] {"Метод косинуса", "Метод Левенштейна+", "Коэффициент Жаккара "});
            this.lbComparisionMethods.Location = new System.Drawing.Point(611, 111);
            this.lbComparisionMethods.Name = "lbComparisionMethods";
            this.lbComparisionMethods.Size = new System.Drawing.Size(153, 95);
            this.lbComparisionMethods.TabIndex = 15;
            this.lbComparisionMethods.SelectedIndexChanged += new System.EventHandler(this.lbComparisionMethods_SelectedIndexChanged);
            // 
            // lblSimilarityBorder
            // 
            this.lblSimilarityBorder.Location = new System.Drawing.Point(160, 160);
            this.lblSimilarityBorder.Name = "lblSimilarityBorder";
            this.lblSimilarityBorder.Size = new System.Drawing.Size(100, 17);
            this.lblSimilarityBorder.TabIndex = 16;
            this.lblSimilarityBorder.Text = "Граница схожести";
            // 
            // lblTokenDividing
            // 
            this.lblTokenDividing.Location = new System.Drawing.Point(160, 185);
            this.lblTokenDividing.Name = "lblTokenDividing";
            this.lblTokenDividing.Size = new System.Drawing.Size(100, 17);
            this.lblTokenDividing.TabIndex = 17;
            this.lblTokenDividing.Text = "Разбиение";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 558);
            this.Controls.Add(this.lblTokenDividing);
            this.Controls.Add(this.lblSimilarityBorder);
            this.Controls.Add(this.lbComparisionMethods);
            this.Controls.Add(this.cbOptionFillTable);
            this.Controls.Add(this.numUpDownCriticalValue);
            this.Controls.Add(this.dataGridComparisionResult);
            this.Controls.Add(this.btnStartProcessing);
            this.Controls.Add(this.ProcessingStatusStrip);
            this.Controls.Add(this.cbOptionFileType);
            this.Controls.Add(this.cbOptionSubdirectories);
            this.Controls.Add(this.txtCriticalValue);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.btnFilterForm);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.menu);
            this.MainMenuStrip = this.menu;
            this.Name = "MainForm";
            this.Text = "Антиплагиат исходного кода";
            this.Load += new System.EventHandler(this.Main_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ProcessingStatusStrip.ResumeLayout(false);
            this.ProcessingStatusStrip.PerformLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridComparisionResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numUpDownCriticalValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label lblSimilarityBorder;
        private System.Windows.Forms.Label lblTokenDividing;

        private System.Windows.Forms.DataGridViewTextBoxColumn Method;

        private System.Windows.Forms.DataGridViewTextBoxColumn FirstDirectory;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondDirectory;

        private System.Windows.Forms.ListBox lbComparisionMethods;

        private System.Windows.Forms.CheckBox cbOptionFillTable;

        private System.Windows.Forms.DataGridViewTextBoxColumn RawSimilarityValue;

        private System.Windows.Forms.NumericUpDown numUpDownCriticalValue;

        private System.Windows.Forms.DataGridViewTextBoxColumn FirstFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Similarity;

        private System.Windows.Forms.DataGridView dataGridComparisionResult;

        private System.Windows.Forms.Button btnStartProcessing;

        private System.Windows.Forms.TextBox txtDirectoryPath;
        private System.Windows.Forms.Button btnBrowse;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem справкаToolStripMenuItem;

        #endregion

        private System.Windows.Forms.Button btnFilterForm;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.TextBox txtCriticalValue;
        private System.Windows.Forms.CheckBox cbOptionSubdirectories;
        private System.Windows.Forms.CheckBox cbOptionFileType;
        private System.Windows.Forms.ToolStripStatusLabel ProcessingStatusLabel;
        private System.Windows.Forms.StatusStrip ProcessingStatusStrip;
    }
}