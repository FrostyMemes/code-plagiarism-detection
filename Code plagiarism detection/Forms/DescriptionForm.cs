using System;
using System.IO;
using System.Windows.Forms;

namespace CodePlagiarismDetection.Forms
{
    public partial class DescriptionForm : Form
    {
        public DescriptionForm()
        {
            InitializeComponent();
        }

        private void DescriptionForm_Load(object sender, EventArgs e)
        {
            var path = Path.Combine(Application.StartupPath, @"Doc\Theory.html"); //Получение пути к справке программы
            webBrowserDescription.Navigate(path); //Отображение справки на форме
        }
    }
}