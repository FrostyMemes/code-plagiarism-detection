using System;
using System.IO;
using System.Text.RegularExpressions;
using Xunit;

namespace ModuleTests.ServiceTests
{
    public class NormalizerTests
    {
        private string direcotryToFileForNormalizing = @"ServiceTests\FilesForNormalizing";
        private static readonly string commentAndStringLiterallsPattern = 
            @"(?x)( ""(?> (?<=@.) (?>[^""]+|"""")*  | (?> [^""\\]+ | \\. )* ) 
            ""| ' (?> [^'\\]+ | \\. )* ')| // .* | /\* (?s) .*? \*/ ";
        
        [Theory]
        [InlineData("TestRegexForDeletingCommentsAndStringLiterals.c")]
        public void TestRegexForDeletingCommentsAndStringLiterals(string file)
        {
            var directory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
                "..", 
                "..", direcotryToFileForNormalizing);
            var fileText = File.ReadAllText($"{directory}\\{file}");
            fileText = Regex.Replace(fileText, commentAndStringLiterallsPattern, String.Empty);
            Assert.True(String.IsNullOrWhiteSpace(fileText));
        }
    }
}