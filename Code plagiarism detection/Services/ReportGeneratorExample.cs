using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace CodePlagiarismDetection.Services
{
    public static class ReportGeneratorExample
    {
        public enum TokenType
        {
            Common,
            Original
        }
        public static string GenerateHTMLReport(string originalFile, string comparedFile)
        {
            var stringWriter = new StringWriter();
            stringWriter.WriteLine(HtmlBegin);
            using (var htmlWriter = new HtmlTextWriter(stringWriter))
            {
                var originalFileContent = new FileContent(originalFile);
                var comparedFileContent = new FileContent(comparedFile);
                var commonSubsequence = CalculateLiteralLCS(originalFileContent.Literals, comparedFileContent.Literals);
                GenerateMarkup(originalFileContent, comparedFileContent, commonSubsequence, htmlWriter);
            }

            return stringWriter.ToString();
        }
        
        private static void GenerateMarkup(FileContent originalFile, FileContent comparedFile, 
            List<string> commonSequence, HtmlTextWriter writer)
        {
            WriteDocumentsNames(originalFile.FileName, comparedFile.FileName, writer);
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            WriteDocumentInHtml(originalFile, commonSequence, writer);
            WriteDocumentInHtml(comparedFile, commonSequence, writer);
            writer.RenderEndTag();
            writer.WriteLine(HtmlEnd);
        }

        private static void WriteDocumentsNames(string firstDocumentName, string secondDocumentName, HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            writer.WriteEncodedText(firstDocumentName);
            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            writer.WriteEncodedText(secondDocumentName);
            writer.RenderEndTag();
            writer.RenderEndTag();
        }
        
        private static void WriteDocumentInHtml(FileContent file, List<string> commonSequence, HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            var wasCommon = false;
            var whiteSpacesTokens = new StringBuilder();
            var rawTextTokens = LiteralTokenizer.Tokenize(file.Text).ToList();
            foreach (var tokenAndType in GetTokensType(rawTextTokens, commonSequence))
            {
                var token = tokenAndType.Item1;
                var tag = tokenAndType.Item2;
                if (token.Any(char.IsWhiteSpace))
                {
                    whiteSpacesTokens.Append(token);
                    continue;
                }
                if (wasCommon && tag == TokenType.Common)
                {
                    WriteWithTag(writer, whiteSpacesTokens.ToString(), TokenType.Common);
                }
                else
                {
                    WriteWithTag(writer, whiteSpacesTokens.ToString(), TokenType.Original);
                }
                WriteWithTag(writer, token, tag);
                whiteSpacesTokens.Clear();
                wasCommon = tag == TokenType.Common;
            }
            WriteWithTag(writer, whiteSpacesTokens.ToString(), TokenType.Original);
            writer.RenderEndTag();
        }

        private static void WriteWithTag(HtmlTextWriter writer, string text, TokenType tag)
        {
            if (text.Length == 0) 
                return;
            writer.AddAttribute(HtmlTextWriterAttribute.Class, tag.ToString());
            writer.RenderBeginTag(HtmlTextWriterTag.Span);
            writer.WriteEncodedText(text);
            writer.RenderEndTag();
        }
        
        public static IEnumerable<Tuple<string, TokenType>> GetTokensType(List<string> rawTextTokens,  
            List<string> commonTokens)
        {
            int i = 0;
            foreach (var token in rawTextTokens)
            {
                if (i != commonTokens.Count && token == commonTokens[i])
                {
                    yield return Tuple.Create(token, TokenType.Common);
                    ++i;
                }
                else
                {
                    yield return Tuple.Create(token, TokenType.Original);
                }
            }
        }
        
        public static List<string> CalculateLiteralLCS(List<string> first, List<string> second)
        {
            int[,] opt = new int[first.Count + 1, second.Count + 1];
            for (int i = 0; i < first.Count; i++)
                opt[i, 0] = 0;
            for (int j = 0; j < second.Count; j++)
                opt[0, j] = 0;
            for (int i = 1; i <= first.Count; i++)
            for (int j = 1; j <= second.Count; j++)
            {
                if (first[i - 1] == second[j - 1])
                    opt[i, j] = opt[i - 1, j - 1] + 1;
                else
                    opt[i, j] = Math.Max(opt[i, j - 1], opt[i - 1, j]);
            }
            return BacktrackOpt(opt, first, second, first.Count, second.Count);
        }
        private static List<string> BacktrackOpt(int[,] opt, List<string> first, List<string> second, int x, int y)
        {
            if (x == 0 | y == 0)
                return new List<string>();
            if (first[x - 1] == second[y - 1])
            {
                var result = BacktrackOpt(opt, first, second, x - 1, y - 1);
                result.Add(first[x - 1]);
                return result;
            }
            if (opt[x, y - 1] > opt[x - 1, y])
                return BacktrackOpt(opt, first, second, x, y - 1);
            return BacktrackOpt(opt, first, second, x - 1, y);
        }
        
        private const string HtmlBegin =
            @"<!DOCTYPE html>
            <html>
            <head>
            <meta charset=""utf-8""/>
            <title>Похожие решения</title>
            <style type=""text/css"">
            * {padding-top:0;margin-top:0;border-top:0;}
            .Common {background-color: #ff9999;}
            tr, td {vertical-align: top; border-left: 1px solid #ddd;border-bottom: 1px solid #ddd;}
            th {background-color: #ddd} 
            </style>
            </head>
            <body>
            <pre>
            <table valign=""top"">";

        private const string HtmlEnd = @"</table></pre></body></html>";
    }
}