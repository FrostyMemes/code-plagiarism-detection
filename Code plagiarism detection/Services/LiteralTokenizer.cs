using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodePlagiarismDetection.Services
{
    public static class LiteralTokenizer
    {
        private static readonly Regex regex = new Regex(@"(\w+)|(\r?\n)|(.)", 
            RegexOptions.IgnorePatternWhitespace);

        public static IEnumerable<string> Tokenize(string text)
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