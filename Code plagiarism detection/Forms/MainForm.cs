using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CodePlagiarismDetection.Methods;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection
{
    public partial class MainForm : Form
    {
        private SearchOption _searchOption = SearchOption.TopDirectoryOnly;
        private FilePairOption _filePairOption = FilePairOption.CheckFileType;
        private DataTable _comparisionDataTable;
        public MainForm()
        {
            InitializeComponent();
        }

        private void Main_Load(object sender, EventArgs e)
        {
            _comparisionDataTable = ComparisonDataTableWorker.CreateFileCoprasionDataTable();
            dataGridComprasionResult.DataSource = _comparisionDataTable;
        }

        private void btnBrowse_Click(object sender, EventArgs e)
        {
            var folderBrowserDialog = new FolderBrowserDialog();
            if (folderBrowserDialog.ShowDialog() == DialogResult.OK) {
                txtDirectoryPath.Text = folderBrowserDialog.SelectedPath ;
            }
        }
        
        private void btnFilterForm_Click(object sender, EventArgs e)
        {
            if (Program.filterForm != null)
            {
                Program.filterForm.Activate();
                return;
            }
            Program.filterForm = new FilterForm();    
            Program.filterForm.Show();
        }

        private void btnStartProcessing_Click(object sender, EventArgs e)
        {
            if (String.IsNullOrWhiteSpace(txtDirectoryPath.Text))
                return;
            
            var directory = new DirectoryInfo(txtDirectoryPath.Text);
            var files = FileLoader.LoadFiles(directory, _searchOption)
                .Select(file => new FileContent(file))
                .ToList();
            var cosine = new Cosine();
            var comparisons = cosine.CompareFilePairwise(files, _filePairOption);
            _comparisionDataTable = ComparisonDataTableWorker
                .FillComparisionDataTable(_comparisionDataTable, comparisons);
        }

        private void cbOptionSubdirectories_CheckedChanged(object sender, EventArgs e)
        {
            _searchOption = (cbOptionSubdirectories.Checked)
                ? SearchOption.TopDirectoryOnly
                : SearchOption.AllDirectories;
        }

        private void cbOptionFileType_CheckedChanged(object sender, EventArgs e)
        {
            _filePairOption = (cbOptionFileType.Checked)
                ? FilePairOption.CheckFileType
                : FilePairOption.IgnoreFileType;
        }

        private void numUpDownCriticalValue_ValueChanged(object sender, EventArgs e)
        {
            ShingleProfiler.N = int.Parse(numUpDownCriticalValue.Text);
        }

       
    }
}