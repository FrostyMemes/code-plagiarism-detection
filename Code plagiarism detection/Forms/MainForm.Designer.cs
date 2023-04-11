﻿namespace CodePlagiarismDetection
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
            this.dataGridComprasionResult = new System.Windows.Forms.DataGridView();
            this.FirstFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.SecondFile = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.Similarity = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.numUpDownCriticalValue = new System.Windows.Forms.NumericUpDown();
            this.groupBox1.SuspendLayout();
            this.menu.SuspendLayout();
            this.ProcessingStatusStrip.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize) (this.dataGridComprasionResult)).BeginInit();
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
            this.txtCriticalValue.Location = new System.Drawing.Point(12, 157);
            this.txtCriticalValue.Name = "txtCriticalValue";
            this.txtCriticalValue.Size = new System.Drawing.Size(142, 20);
            this.txtCriticalValue.TabIndex = 6;
            this.txtCriticalValue.Text = "Порог заимствования";
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
            // dataGridComprasionResult
            // 
            this.dataGridComprasionResult.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridComprasionResult.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridComprasionResult.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {this.FirstFile, this.SecondFile, this.Similarity});
            this.dataGridComprasionResult.Location = new System.Drawing.Point(11, 267);
            this.dataGridComprasionResult.Name = "dataGridComprasionResult";
            this.dataGridComprasionResult.Size = new System.Drawing.Size(755, 243);
            this.dataGridComprasionResult.TabIndex = 12;
            // 
            // FirstFile
            // 
            this.FirstFile.DataPropertyName = "FirstFile";
            this.FirstFile.HeaderText = "Файл1";
            this.FirstFile.Name = "FirstFile";
            // 
            // SecondFile
            // 
            this.SecondFile.DataPropertyName = "SecondFile";
            this.SecondFile.HeaderText = "Файл2";
            this.SecondFile.Name = "SecondFile";
            // 
            // Similarity
            // 
            this.Similarity.DataPropertyName = "Similarity";
            this.Similarity.HeaderText = "Схожесть";
            this.Similarity.Name = "Similarity";
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(778, 558);
            this.Controls.Add(this.numUpDownCriticalValue);
            this.Controls.Add(this.dataGridComprasionResult);
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
            ((System.ComponentModel.ISupportInitialize) (this.dataGridComprasionResult)).EndInit();
            ((System.ComponentModel.ISupportInitialize) (this.numUpDownCriticalValue)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.NumericUpDown numUpDownCriticalValue;

        private System.Windows.Forms.DataGridViewTextBoxColumn FirstFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn SecondFile;
        private System.Windows.Forms.DataGridViewTextBoxColumn Similarity;

        private System.Windows.Forms.DataGridView dataGridComprasionResult;

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