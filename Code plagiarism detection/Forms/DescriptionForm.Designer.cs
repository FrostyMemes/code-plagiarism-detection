using System.ComponentModel;

namespace CodePlagiarismDetection.Forms
{
    partial class DescriptionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private IContainer components = null;

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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(DescriptionForm));
            this.webBrowserDescription = new System.Windows.Forms.WebBrowser();
            this.SuspendLayout();
            // 
            // webBrowserDescription
            // 
            this.webBrowserDescription.Dock = System.Windows.Forms.DockStyle.Fill;
            this.webBrowserDescription.Location = new System.Drawing.Point(0, 0);
            this.webBrowserDescription.MinimumSize = new System.Drawing.Size(20, 20);
            this.webBrowserDescription.Name = "webBrowserDescription";
            this.webBrowserDescription.Size = new System.Drawing.Size(1108, 767);
            this.webBrowserDescription.TabIndex = 0;
            // 
            // DescriptionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1108, 767);
            this.Controls.Add(this.webBrowserDescription);
            this.Icon = ((System.Drawing.Icon) (resources.GetObject("$this.Icon")));
            this.Name = "DescriptionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Справка";
            this.Load += new System.EventHandler(this.DescriptionForm_Load);
            this.ResumeLayout(false);
        }

        private System.Windows.Forms.WebBrowser webBrowserDescription;

        #endregion
    }
}