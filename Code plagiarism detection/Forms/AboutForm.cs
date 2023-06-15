using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Forms
{
    public partial class AboutForm : Form
    {
        private static PrivateFontCollection _privateFontCollection = default;
        public AboutForm()
        {
            InitializeComponent();
            InitializeComponentStyles();
        }

        private void AboutForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.aboutForm = null; //Удаление ссылки на форму
        }

        //Подгрузка внешних шрифтов
        private void InitializeComponentStyles()
        {
            _privateFontCollection = LocalFontsCollection.GetPrivateFontCollectionInstance(); //Получение коллекции внешних добавленных шрифтов
            
            foreach (Control control in this.Controls)
                control.Font = new Font(_privateFontCollection.Families[(int)Fonts.MontserattThin], 10, FontStyle.Regular);
        }
    }
}