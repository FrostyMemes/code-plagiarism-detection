using CodePlagiarismDetection.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CodePlagiarismDetection
{
    public partial class FilterForm : Form
    {
        public FilterForm()
        {
            InitializeComponent();
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
    }
}
