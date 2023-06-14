using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;


namespace CodePlagiarismDetection.Services
{
    //Класс для нормализации текста исходного кода
    public static class TextNormalizer
    {
        //Регулярное выражение для удаления многострочных комментариев
        private static readonly List<string> multiCommentsPatterns = new List<string>()
        {
            @"""""""(.|[\r\n])*?""""""",
            @"/\*(.|[\r\n])*?\*/"
        };

        //Регулярное выражение для удаления однострочных комментариев
        private static readonly List<string> lineCommentsPatterns = new List<string>()
        {
            @"\/\/.*?(?=\r\n|$)",
            @"#.*?(?=\r\n|$)"
        };
        
        //Регулярное выражение для удаления строковых литералов 
        private static readonly List<string> stringLiteralsPatterns = new List<string>()
        {
            @"\'.*?\'",
            @"\"".*?\""",
            @"\`.*?\`",
        };
        
        //Метод нормализации текста исходного кода
        public static string NormalizeText(string str)
        {
            str = DeleteWithPatterns(str, multiCommentsPatterns);
            str = DeleteWithPatterns(str, lineCommentsPatterns);
            str = DeleteWithPatterns(str, stringLiteralsPatterns);
            str = str.Replace(Environment.NewLine, " ");
            str = DeleteWithPatterns(str, stringLiteralsPatterns);
            str = str.Replace('\t', ' ');
            str = Regex.Replace(str,@"\s+"," ");
            return str.Trim().ToLower();;
        }

        //Метод удаления элементов по паттернам
        public static string DeleteWithPatterns(string str, List<string> patterns)
        {
            foreach (var pattern in patterns)
            {
                str = Regex.Replace(str, pattern, "");
            }
            return str;
        }
    }
}