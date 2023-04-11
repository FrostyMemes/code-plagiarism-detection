using System.Collections;
using System.Collections.Generic;
using CodePlagiarismDetection.Services;
using System.IO;
using System.Linq;
using Xunit;

namespace ModuleTests.ServiceTests
{
    public class FileLoaderTests
    {
        private string codeExamplePath = @"D:\Projects\C Sharp Projects\CodePlagiarismDetection\ModuleTests\CodeExamples";
        
        public static IEnumerable<object[]> FilterTestData => 
            new List<object[]>
            {
                new object[] {new List<string>(){"*.c"}}, 
                new object[] {new List<string>(){"*.py"}}, 
                new object[] {new List<string>() {"*.c", "*.py"}},
            };
        
        [Theory]
        [InlineData(SearchOption.AllDirectories)]
        [InlineData(SearchOption.TopDirectoryOnly)]
        public void GetFilesFromDirectoryWithSearchOption(SearchOption option)
        {
            var directory = new DirectoryInfo(codeExamplePath);
            var testFileLoaderFileCount = FileLoader.LoadFiles(directory, option)
                .ToList().Count;
            var factFilesCount = directory.GetFiles("*", option)
                .ToList().Count;
            Assert.Equal(factFilesCount, testFileLoaderFileCount);
        }
        
        [Theory]
        [MemberData(nameof(FilterTestData))]
        public void GetFilesFromDirectoryWithFilter(List<string> filter)
        {
            FileLoader.filter = filter;
            var directory = new DirectoryInfo(codeExamplePath);
            var testFileLoaderFileCount = FileLoader.LoadFiles(directory, SearchOption.AllDirectories)
                .ToList().Count;
            
            var factFilesCount = 0;
            foreach (var pattern in filter)
            {
                factFilesCount += directory.GetFiles(pattern, SearchOption.AllDirectories)
                    .ToList().Count;
            }
            
            
            Assert.Equal(factFilesCount, testFileLoaderFileCount);
        }
    }
}