using System;
using System.Drawing;
using System.Drawing.Text;
using System.Linq;
using System.Windows.Forms;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Forms
{
    public partial class FilterForm : Form
    {
        private static PrivateFontCollection _privateFontCollection = default;
        public FilterForm()
        {
            InitializeComponent();
            InitializeComponentStyles(); //Инициализация внешних стилей компонентов формы
        }

        private void Filter_Load(object sender, EventArgs e)
        {
            txtFilter.Text = string.Join(Environment.NewLine, FileLoader.filter);
        }
        
        private void FilterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Program.filterForm = null;
        }

        //Добавление масок имен файлов в фильтр обработчика
        private void SaveTextToFilterList()
        {
            FileLoader.filter = txtFilter.Lines.OfType<string>()
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct()
                .ToList();
        }
        
        private void InitializeComponentStyles()
        {
            _privateFontCollection = LocalFontsCollection.GetPrivateFontCollectionInstance(); //Получение коллекции внешних добавленных шрифтов
            
            foreach (Control control in this.Controls)
                control.Font = new Font(_privateFontCollection.Families[(int)Fonts.MontserattThin], 11, FontStyle.Regular);
        }

        //Добавление масок имен файлов в фильтр обработчика
        private void txtFilter_TextChanged(object sender, EventArgs e) 
        {
            SaveTextToFilterList();
        }
    }
}
