using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using CodePlagiarismDetection.Services;
using Xunit;

namespace ModuleTests.ServiceTests
{
    public class NormalizerTests
    {
        private string direcotryToFileForNormalizing = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
            "..", 
            "..", @"ServiceTests\TestFiles"); //Пусть к файлам для тестирования
        
        //Тест проверки удаления комментариев и строковых литералов
        [Fact]
        public void DeletingCommentsAndStringsLiterals_RegexMustDeleteCommentsAndStringLiterals_ReturnNullOrWhiteSpaceString()
        {
            var path = Path.Combine(direcotryToFileForNormalizing, "TestRegexForDeletingCommentsAndStringLiterals.c");
            var fileText = File.ReadAllText(path);
            fileText = TextNormalizer.NormalizeText(fileText);
            Assert.True(String.IsNullOrWhiteSpace(fileText));
        }
        
        
        //Тест проверки возвращения единой строки текста
        [Fact]
        public void NormalizeText_NormalizerMustReturnTextWithoutTextLineBreakers_ReturnOneLine()
        {
            var path = Path.Combine(direcotryToFileForNormalizing, "TestProcessingToOneLineText.c");
            var fileText = File.ReadAllText(path);
            var normalizedText = TextNormalizer.NormalizeText(fileText);
            var lineCount = normalizedText.Split('\n').Length;
            Assert.Equal(1, lineCount);
        }
        
        
        //Тест получения списка слов, разделенных пробелом
        [Fact]
        public void LiteralTokenize_LiteralTokenizerExtractLiteralFromNormalizedText_ReturnSameLiterals()
        {
            var path = Path.Combine(direcotryToFileForNormalizing, "TestExtractLiteralsFromText.c");
            var fileText = File.ReadAllText(path);
            var normalizedText = TextNormalizer.NormalizeText(fileText);
            var literalCount = LiteralTokenizer.GetTokens(normalizedText).Count();
            Assert.Equal(50, literalCount);
        }
    }
}