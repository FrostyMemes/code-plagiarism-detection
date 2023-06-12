using System;
using System.Windows.Forms;
using CodePlagiarismDetection.Forms;

namespace CodePlagiarismDetection
{
    static class Program
    {
        public static FilterForm filterForm;
        public static AboutForm aboutForm;
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new MainForm());
        }
    }
}