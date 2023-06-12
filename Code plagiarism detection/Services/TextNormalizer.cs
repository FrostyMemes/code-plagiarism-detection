using System;
using System.Text.RegularExpressions;


namespace CodePlagiarismDetection.Services
{
    //Класс для нормализации текста исходного кода
    public static class TextNormalizer
    {
        //Регулярное выражение для удаление строковых литералов и комментарие
        public static readonly string commentAndStringLiterallsPattern = 
            @"(?x)( ""(?> (?<=@.) (?>[^""]+|"""")*  | (?> [^""\\]+ | \\. )* ) 
            ""| ' (?> [^'\\]+ | \\. )* ')| // .* | /\* (?s) .*? \*/ ";
        
        //Метод нормализации текста исходного кода
        public static string NormalizeText(string str)
        {
            str = Regex.Replace(str, commentAndStringLiterallsPattern, "");
            str = str.Replace(Environment.NewLine, " ");
            str = str.Replace('\t', ' ');
            str = Regex.Replace(str,@"\s+"," ");
            return str.Trim().ToLower();;
        }
    }
}