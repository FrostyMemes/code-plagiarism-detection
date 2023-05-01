﻿using System;
using System.IO;
using System.Windows.Forms;

namespace CodePlagiarismDetection.Services
{
    public static class ValidationChecker
    {
        public static bool CheckValidationOfCurrentDirectory(string path)
        {
            if (String.IsNullOrWhiteSpace(path)) 
                return false;

            if (!Directory.Exists(path))
            {
                MessageBox.Show("Указанная папка не существует", "Внимание", 
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}