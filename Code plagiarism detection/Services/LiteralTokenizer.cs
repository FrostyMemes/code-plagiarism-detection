using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace CodePlagiarismDetection.Services
{
    //Класс для получения списка токенов метода Левенштейна
    public static class LiteralTokenizer
    {
        private static readonly Regex regex = new Regex(@"(\w+)|(\r?\n)|(.)", 
            RegexOptions.IgnorePatternWhitespace); //Регулярное выражение для выделение слов (токенов), разделенных пробелом

        //Метод для удаления лишних слов (токенов) из списка 
        public static IEnumerable<string> GetTokens(string text)
        {
            return Tokenize(text).Where(token => token.All(c => !char.IsWhiteSpace(c)));
        }
        
        //Метод для получения списка слов (токенов), разделенных пробелом
        private static IEnumerable<string> Tokenize(string text)
        {
            var matches = regex.Matches(text);
            foreach (Match match in matches)
            {
                if (match.Success)
                {
                    yield return match.Value;
                }
            }
        }
    }
}