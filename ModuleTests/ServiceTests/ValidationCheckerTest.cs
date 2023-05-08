using System;
using System.IO;
using CodePlagiarismDetection.Services;
using Xunit;

namespace ModuleTests.ServiceTests
{
    public class ValidationCheckerTest
    {
        [Fact]
        public void IsExist_CheckingExistingDirectory_ReturnTrue()
        {
            var existingDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            Assert.True(ValidationChecker.CheckValidationOfCurrentDirectory(existingDirectory));
        }
        
        [Fact]
        public void IsNotExist_CheckingNotExistingDirectory_ReturnFalse()
        {
            var notExistingDirectory = "h:\\";
            Assert.False(ValidationChecker.CheckValidationOfCurrentDirectory(notExistingDirectory));
        }
        
        [Fact]
        public void IsNotEmpty_CheckingEmptyDirectoryPath_ReturnFalse()
        {
            var emptyPath = String.Empty;
            Assert.False(ValidationChecker.CheckValidationOfCurrentDirectory(emptyPath));
        }
    }
}