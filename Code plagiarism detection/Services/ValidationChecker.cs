using System;
using System.IO;
using System.Windows.Forms;

namespace CodePlagiarismDetection.Services
{
    public enum MessageBoxShowMode{
        Show,
        Hide
    }
    public static class ValidationChecker
    {
        public static bool CheckValidationOfCurrentDirectory(string path, MessageBoxShowMode showMode)
        {
            if (String.IsNullOrWhiteSpace(path)) 
                return false;

            if (!Directory.Exists(path))
            {
                if (showMode == MessageBoxShowMode.Show)
                    MessageBox.Show("Указанная папка не существует", "Внимание", 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}