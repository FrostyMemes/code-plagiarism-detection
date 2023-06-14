using System;
using System.IO;
using System.Windows.Forms;

namespace CodePlagiarismDetection.Services
{
    public enum MessageBoxShowMode{
        Show, //Показать сообение об ошибке
        Hide //Не показывать сообщение об ошибке
    }
    
    //Класс для валидации данных
    public static class ValidationChecker
    {
        
        //Класс для валидации введенного пользователем пути к директории с файлами
        public static bool CheckDirectoryExisting(string path, MessageBoxShowMode showMode)
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
        
        
        public static bool CheckFileExisting(string path, MessageBoxShowMode showMode)
        {
            if (String.IsNullOrWhiteSpace(path)) 
                return false;

            if (!File.Exists(path))
            {
                if (showMode == MessageBoxShowMode.Show)
                    MessageBox.Show($"Файла {Path.GetFileName(path)} не существует", "Внимание", 
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Warning);
                return false;
            }
            return true;
        }
    }
}