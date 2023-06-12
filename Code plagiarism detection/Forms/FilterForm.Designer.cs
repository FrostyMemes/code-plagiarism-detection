
namespace CodePlagiarismDetection.Forms
{
    partial class FilterForm
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FilterForm));
            this.txtFilter = new System.Windows.Forms.TextBox();
            this.lblDescription = new System.Windows.Forms.Label();
            this.splitter1 = new System.Windows.Forms.Splitter();
            this.pictureBoxDescription = new System.Windows.Forms.PictureBox();
            this.toolTipQuestion = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxDescription)).BeginInit();
            this.SuspendLayout();
            // 
            // txtFilter
            // 
            this.txtFilter.Anchor = ((System.Windows.Forms.AnchorStyles) ((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) | System.Windows.Forms.AnchorStyles.Left) | System.Windows.Forms.AnchorStyles.Right)));
            this.txtFilter.Location = new System.Drawing.Point(9, 108);
            this.txtFilter.Margin = new System.Windows.Forms.Padding(4);
            this.txtFilter.Multiline = true;
            this.txtFilter.Name = "txtFilter";
            this.txtFilter.Size = new System.Drawing.Size(480, 304);
            this.txtFilter.TabIndex = 0;
            this.txtFilter.TextChanged += new System.EventHandler(this.txtFilter_TextChanged);
            // 
            // lblDescription
            // 
            this.lblDescription.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.lblDescription.Location = new System.Drawing.Point(6, 12);
            this.lblDescription.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(459, 92);
            this.lblDescription.TabIndex = 1;
            this.lblDescription.Text = "На разных строка разместите маски названий файлов, которые хотите обработать.\r\nЧт" + "обы обработать все файлы в выбранной папке - оставтье поле пустым.\r\n";
            // 
            // splitter1
            // 
            this.splitter1.Location = new System.Drawing.Point(0, 0);
            this.splitter1.Name = "splitter1";
            this.splitter1.Size = new System.Drawing.Size(3, 423);
            this.splitter1.TabIndex = 2;
            this.splitter1.TabStop = false;
            // 
            // pictureBoxDescription
            // 
            this.pictureBoxDescription.Anchor = ((System.Windows.Forms.AnchorStyles) ((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxDescription.Image = ((System.Drawing.Image) (resources.GetObject("pictureBoxDescription.Image")));
            this.pictureBoxDescription.Location = new System.Drawing.Point(459, 12);
            this.pictureBoxDescription.Name = "pictureBoxDescription";
            this.pictureBoxDescription.Size = new System.Drawing.Size(27, 27);
            this.pictureBoxDescription.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxDescription.TabIndex = 3;
            this.pictureBoxDescription.TabStop = false;
            this.toolTipQuestion.SetToolTip(this.pictureBoxDescription, "Символ «?» в маске означает, что вместо него должен стоять любой символ.\r\nСимвол " + "«*» в маске означает, что вместо него может быть подставлено любое сочетание сим" + "волов. \r\n");
            // 
            // FilterForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 18F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(498, 423);
            this.Controls.Add(this.pictureBoxDescription);
            this.Controls.Add(this.splitter1);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtFilter);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte) (204)));
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "FilterForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Фильтр файлов";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.FilterForm_FormClosing);
            this.Load += new System.EventHandler(this.Filter_Load);
            ((System.ComponentModel.ISupportInitialize) (this.pictureBoxDescription)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.ToolTip toolTipQuestion;

        private System.Windows.Forms.PictureBox pictureBoxDescription;

        private System.Windows.Forms.Splitter splitter1;

        private System.Windows.Forms.Label lblDescription;

        #endregion

        private System.Windows.Forms.TextBox txtFilter;
    }
}