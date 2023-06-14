using System;
using System.IO;
using CodePlagiarismDetection.Services;
using Xunit;

namespace ModuleTests.ServiceTests
{
    public class ValidationCheckerTest
    {
        //Тест проверки корректности введенного пути директории
        [Fact]
        public void CheckCheckDirectoryExisting_TestCheckingOfValidationOfCurrentDirectoryWithDifferentParameters_ReturnSuccess()
        {
            var existingDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            var notExistingDirectory = "h:\\NotFoundFolder111";
            var emptyPath = String.Empty;
            Assert.True(ValidationChecker.CheckDirectoryExisting(existingDirectory, MessageBoxShowMode.Hide));
            Assert.False(ValidationChecker.CheckDirectoryExisting(notExistingDirectory, MessageBoxShowMode.Hide));
            Assert.False(ValidationChecker.CheckDirectoryExisting(emptyPath, MessageBoxShowMode.Hide));
        }
        
        //Тест проверки корректности введенного пути файла
        [Fact]
        public void CheckValidationOfCurrentDirectory_TestCheckingOfValidationOfCurrentDirectoryWithDifferentParameters_ReturnSuccess()
        {
            var existingFile = Path.Combine(AppDomain.CurrentDomain.BaseDirectory,
                "..", "..", 
                "CodeExamples", "CSharp",
                "1.c");
            var notExistingFile = "h:\\NotFoundFolder111\\321.с";
            var emptyPath = String.Empty;
            Assert.True(ValidationChecker.CheckFileExisting(existingFile, MessageBoxShowMode.Hide));
            Assert.False(ValidationChecker.CheckFileExisting(notExistingFile, MessageBoxShowMode.Hide));
            Assert.False(ValidationChecker.CheckFileExisting(emptyPath, MessageBoxShowMode.Hide));
        }
    }
}