﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CodePlagiarismDetection.Services
{
    public static class TextNormalizer
    {
        private static readonly string commentAndStringLiterallsPattern = 
            @"(?x)( ""(?> (?<=@.) (?>[^""]+|"""")*  | (?> [^""\\]+ | \\. )* ) 
            ""| ' (?> [^'\\]+ | \\. )* ')| // .* | /\* (?s) .*? \*/ ";
        public static string NormalizeText(string str)
        {
            str = Regex.Replace(str, commentAndStringLiterallsPattern, "");
            str = string.Join(" ", Regex.Split(str, @"(?:\r\n|\n\r|\n|\r)"));
            str = str.Replace('\t', ' ');
            str = Regex.Replace(str,@"\s+"," ");
            return str.Trim().ToLower();;
        }
    }
}
