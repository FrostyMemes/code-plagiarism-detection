using System;
using System.Text.RegularExpressions;


namespace CodePlagiarismDetection.Services
{
    public static class TextNormalizer
    {
        public static readonly string commentAndStringLiterallsPattern = 
            @"(?x)( ""(?> (?<=@.) (?>[^""]+|"""")*  | (?> [^""\\]+ | \\. )* ) 
            ""| ' (?> [^'\\]+ | \\. )* ')| // .* | /\* (?s) .*? \*/ ";
        public static string NormalizeText(string str)
        {
            str = Regex.Replace(str, commentAndStringLiterallsPattern, "");
            //str = string.Join(" ", Regex.Split(str, @"(?:\r\n|\n\r|\n|\r)"));
            str = str.Replace(Environment.NewLine, " ");
            str = str.Replace('\t', ' ');
            str = Regex.Replace(str,@"\s+"," ");
            return str.Trim().ToLower();;
        }
    }
}