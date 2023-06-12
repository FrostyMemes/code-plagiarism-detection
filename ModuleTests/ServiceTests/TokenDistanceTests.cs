using CodePlagiarismDetection.Methods;
using CodePlagiarismDetection.Services;
using Xunit;

namespace ModuleTests.ServiceTests
{
    public class TokenDistanceTests
    {
        [Fact]
        public void GetTokenDistance_TestTokenDistanceWithDifferentTokens_IsEqualOne()
        {
            var token1 = "AAAAAAAAAAAA";
            var token2 = "BBBBBBBBBBBB";
            var distance = LevenshteinModify.GetTokenDistance(token1, token2);
            Assert.Equal(1, distance);
        }
        
        [Fact]
        public void GetTokenDistance_TestTokenDistanceWithSimilarTokens_IsEqualZero()
        {
            var token1 = "AAAAAAAAAAAA";
            var token2 = "AAAAAAAAAAAA";
            var distance = LevenshteinModify.GetTokenDistance(token1, token2);
            Assert.Equal(0, distance);
        }
        
        [Fact]
        public void GetTokenDistance_TestTokenDistanceWithHalfSimilarTokens_ReturnHalf()
        {
            var token1 = "AAAAAABBBBBB";
            var token2 = "AAAAAAAAAAAA";
            var distance = LevenshteinModify.GetTokenDistance(token1, token2);
            Assert.Equal(0.5, distance);
        }
    }
}