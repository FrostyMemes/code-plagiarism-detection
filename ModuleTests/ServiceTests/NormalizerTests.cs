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
            "..", @"ServiceTests\TestFiles");

        [Theory]
        [InlineData("TestRegexForDeletingCommentsAndStringLiterals.c")]
        public void TestRegexForDeletingCommentsAndStringLiterals(string file)
        {
            var fileText = File.ReadAllText($@"{direcotryToFileForNormalizing}\{file}");
            fileText = Regex.Replace(fileText, TextNormalizer.commentAndStringLiterallsPattern, String.Empty);
            Assert.True(String.IsNullOrWhiteSpace(fileText));
        }
    }
}