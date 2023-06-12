using System.Windows.Forms;

namespace CodePlagiarismDetection.Forms
{
    public partial class AboutForm : Form
    {
        public AboutForm()
        {
            InitializeComponent();
        }

        private void AboutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.aboutForm = null; //Удаление ссылки на форму
        }
        
    }
}