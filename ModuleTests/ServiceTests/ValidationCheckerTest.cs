using System;
using System.IO;
using CodePlagiarismDetection.Services;
using Xunit;

namespace ModuleTests.ServiceTests
{
    public class ValidationCheckerTest
    {
        [Fact]
        public void CheckValidationOfCurrentDirectory_TestCheckingOfValidationOfCurrentDirectoryWithDifferentParameters_ReturnSuccess()
        {
            var existingDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory);
            var notExistingDirectory = "h:\\NotFoundFolder";
            var emptyPath = String.Empty;
            Assert.True(ValidationChecker.CheckValidationOfCurrentDirectory(existingDirectory, MessageBoxShowMode.Hide));
            Assert.False(ValidationChecker.CheckValidationOfCurrentDirectory(notExistingDirectory, MessageBoxShowMode.Hide));
            Assert.False(ValidationChecker.CheckValidationOfCurrentDirectory(emptyPath, MessageBoxShowMode.Hide));
        }
    }
}