using System;
using System.IO;
using System.Text.RegularExpressions;
using CodePlagiarismDetection.Services;
using Xunit;

namespace ModuleTests.ServiceTests
{
    public class NormalizerTests
    {
        private string direcotryToFileForNormalizing = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
            "..", 
            "..", @"ServiceTests\FilesForNormalizing");

        [Theory]
        [InlineData("TestRegexForDeletingCommentsAndStringLiterals.c")]
        public void TestRegexForDeletingCommentsAndStringLiterals(string file)
        {
            var fileText = File.ReadAllText($@"{direcotryToFileForNormalizing}\{file}");
            fileText = Regex.Replace(fileText, TextNormalizer.commentAndStringLiterallsPattern, String.Empty);
            Assert.True(String.IsNullOrWhiteSpace(fileText));
        }
        
        /*[Theory]
        [InlineData("TestProcessingToOneLineText.c")]
        public void TestProcessingToOneLineText(string file)
        {
            var fileText = File.ReadAllText($@"{direcotryToFileForNormalizing}\{file}");
            var factLineCount = TextNormalizer.NormalizeText(fileText)
                .Split(Convert.ToChar(Environment.NewLine)).Count(); 
            
            Assert.Equal(String.IsNullOrWhiteSpace(fileText));
        }*/
    }
}