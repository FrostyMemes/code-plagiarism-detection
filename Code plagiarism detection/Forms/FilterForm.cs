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
            InitializeComponentStyles();
        }

        private void Filter_Load(object sender, EventArgs e)
        {
            txtFilter.Text = string.Join(Environment.NewLine, FileLoader.filter);
        }

        private void txtFilter_Leave(object sender, EventArgs e)
        {
            SaveTextToFilterList();
        }

        private void FilterForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            SaveTextToFilterList();
            Program.filterForm = null;
        }

        private void SaveTextToFilterList()
        {
            FileLoader.filter = txtFilter.Lines.OfType<string>()
                .Where(s => !string.IsNullOrWhiteSpace(s))
                .Distinct()
                .ToList();
        }
        
        private void InitializeComponentStyles()
        {
            _privateFontCollection = LocalFontsCollection.GetPrivateFontCollectionInstance();
            
            foreach (Control control in this.Controls)
                control.Font = new Font(_privateFontCollection.Families[(int)Fonts.MontserattThin], 11, FontStyle.Regular);
        }
    }
}
