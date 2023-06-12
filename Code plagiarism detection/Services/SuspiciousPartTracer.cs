using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web.UI;

namespace CodePlagiarismDetection.Services
{
    //Класс для вывода идентичных частей двух исходных кодов
    public static class SuspiciousPartTracer
    {
        private const int NShingleLenght = 4; //Подстройка для выделения шинглов сравнения
        public enum TokenType //Перечисления для характеристики типа токена и выделения блока
        {
            Common, //Идентичный токен
            Original //Оригинальный токен
        }
        
        private enum ConcatMode //Перечисление для задания режима обработки строки кода
        {
            Start, //Начало обработки
            Continue //Продолжение обработки
        }
        
        //Метод создания HTML-документа с идентичными частями исходных кодов
        public static string GenerateHtmlReport(string originalFile, string comparedFile)
        {
            var stringWriter = new StringWriter(); //Создание объекта 
            stringWriter.WriteLine(HtmlBegin);
            
            using (var htmlWriter = new HtmlTextWriter(stringWriter)) //Создание билдера для HTML-документа
            {
                var originalFileContent = new FileContent(originalFile); //Информация об первом файле
                var comparedFileContent = new FileContent(comparedFile); //Информация об втором файле
                var originalFileProfile = ShingleProfiler.GetShingleProfile(originalFileContent.NormalizedText, NShingleLenght);
                var comparedFileProfile = ShingleProfiler.GetShingleProfile(comparedFileContent.NormalizedText, NShingleLenght);
                var intersectionShingles = originalFileProfile.Keys.Intersect(comparedFileProfile.Keys).ToArray();
                var intersectionShinglesProfile = intersectionShingles.Select(
                        shingle => new KeyValuePair<string, int>(shingle, 
                            Math.Min(originalFileProfile[shingle], comparedFileProfile[shingle])))
                    .ToDictionary(pair => pair.Key, pair => pair.Value);  //Словарь со всеми общими токенами и их минимальным вхождением среди двух текстов
                GenerateMarkup(originalFileContent, comparedFileContent, intersectionShinglesProfile, htmlWriter);
            }

            return stringWriter.ToString();
        }
        
        
        //Метод создание HTML-разметки
        private static void GenerateMarkup(FileContent originalFile, FileContent comparedFile, 
            Dictionary<string, int> intersectionProfile, HtmlTextWriter writer)
        {
            WriteDocumentsNames(originalFile.FileName, comparedFile.FileName, writer);
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            WriteDocumentInHtml(originalFile, intersectionProfile, writer);
            WriteDocumentInHtml(comparedFile, intersectionProfile, writer);
            writer.RenderEndTag();
            writer.WriteLine(HtmlEnd);
        }
        
        
        //Метод выделения схожих частей у одного из исходных кодов
        private static void WriteDocumentInHtml(FileContent file, Dictionary<string, int> intersectionProfile, HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Td);
            var tokensAndTypes = new List<TokenAndType>(); //Список для обозначения блока и его типа
            var copyIntersectionProfile = intersectionProfile.ToDictionary(
                entry => entry.Key, entry => entry.Value); //Получение копии общих для двух текстов шинглов
            
            var codeLines = file.Text.Split(new string[] {Environment.NewLine}, //Получение списка строк исходного кода
                StringSplitOptions.RemoveEmptyEntries);
            
            foreach (var codeLine in codeLines)
            {
                var concatMode = ConcatMode.Start;
                var startTokenType = TokenType.Original;
                var whiteSpacePrefix = GetWhiteSpacePrefix(codeLine); //Получение пустого префикса строки
                var normalizedCodeLine = TextNormalizer.NormalizeText(codeLine); //Нормализованный текст строки
                var codeLineShingles = GetShingles(normalizedCodeLine).ToArray(); //Получение шинглов строки

                tokensAndTypes.Clear();
                WriteWithTag(writer, whiteSpacePrefix, TokenType.Original);

                foreach (var shingle in codeLineShingles)
                {
                    if (shingle.Length < NShingleLenght)
                    {
                        WriteWithTag(writer, shingle, TokenType.Original);
                        continue;
                    }

                    if (concatMode == ConcatMode.Start)
                    {
                        var shingleChars = shingle.ToCharArray();
                        if (copyIntersectionProfile.ContainsKey(shingle) && copyIntersectionProfile[shingle] != 0)
                        {
                           startTokenType = TokenType.Common;
                           copyIntersectionProfile[shingle]-=1;
                        }
                        else
                            startTokenType = TokenType.Original;

                        for (int i = 0; i != shingleChars.Length; i++)
                            tokensAndTypes.Add(new TokenAndType(shingleChars[i].ToString(), startTokenType));

                        concatMode = ConcatMode.Continue;
                        continue;
                    }

                    if (copyIntersectionProfile.ContainsKey(shingle) && copyIntersectionProfile[shingle] != 0)
                    {
                        for (int i = 1; i != NShingleLenght; i++)
                            tokensAndTypes[tokensAndTypes.Count - i].Type = TokenType.Common;

                        tokensAndTypes.Add(new TokenAndType(shingle[NShingleLenght - 1].ToString(),
                            TokenType.Common));
                        copyIntersectionProfile[shingle]-=1;
                    }
                    else
                    {
                        tokensAndTypes.Add(new TokenAndType(shingle[NShingleLenght - 1].ToString(),
                            TokenType.Original));
                    }

                }

                foreach (TokenAndType token in tokensAndTypes)
                {
                    WriteWithTag(writer, token.Token, token.Type);
                }
                writer.Write('\n');
            }
            writer.RenderEndTag();
        }
        
        //Метод внедрения заголовков имен файлов в HTML-документ
        private static void WriteDocumentsNames(string originalDocumentName, string comparedDocumentName, HtmlTextWriter writer)
        {
            writer.RenderBeginTag(HtmlTextWriterTag.Tr);
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            writer.WriteEncodedText(originalDocumentName);
            writer.RenderEndTag();
            writer.RenderBeginTag(HtmlTextWriterTag.Th);
            writer.WriteEncodedText(comparedDocumentName);
            writer.RenderEndTag();
            writer.RenderEndTag();
        }
        

        //Метода внедрения в HTML-документ определенного тега
        private static void WriteWithTag(HtmlTextWriter writer, string text, TokenType tag)
        {
            if (text.Length == 0) 
                return;
            writer.AddAttribute(HtmlTextWriterAttribute.Class, tag.ToString());
            writer.RenderBeginTag(HtmlTextWriterTag.Span);
            writer.WriteEncodedText(text);
            writer.RenderEndTag();
        }
        
        //Метод получения списка шинглов
        private static IEnumerable<string> GetShingles(string text)
        {
            if (text.Length < NShingleLenght)
                yield return text;
            
            for (int i = 0; i < text.Length - NShingleLenght + 1; i++)
            {
                yield return text.Substring(i, NShingleLenght);
            }
        }

        //Метод получения пустого префикса у строки кода
        private static string GetWhiteSpacePrefix(string text)
        {
            var prefix = new StringBuilder(String.Empty);
            foreach (var ch in text)
            {
                if (Char.IsWhiteSpace(ch))
                    prefix.Append(ch);
                else
                    break;
            }
            return prefix.ToString();
        }

        //Класс для хранения информации о токене
        private class TokenAndType
        {
            public string Token { get; set; }
            public TokenType Type { get; set; }

            public TokenAndType(string token, TokenType type)
            {
                Token = token;
                Type = type;
            }
            
        }
        
        //Текст для оформления головной части HTML-документа
        private const string HtmlBegin =
            @"<!DOCTYPE html>
            <html>
            <head>
            <meta charset=""utf-8""/>
            <title>Подозрительные части</title>
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

        //Текст для оформления подвальной части HTML-документа
        private const string HtmlEnd = @"</table></pre></body></html>";
        
    }
}