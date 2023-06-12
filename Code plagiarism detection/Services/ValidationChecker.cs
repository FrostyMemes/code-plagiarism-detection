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