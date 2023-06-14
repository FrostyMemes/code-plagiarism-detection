using CodePlagiarismDetection.Methods;
using CodePlagiarismDetection.Services;
using Xunit;

namespace ModuleTests.ServiceTests
{
    public class TokenDistanceTests
    {
        //Тест вычисления степени схожести токенов при их полной схожести токенов
        [Fact]
        public void GetTokenDistance_TestTokenDistanceWithDifferentTokens_IsEqualOne()
        {
            var token1 = "AAAAAAAAAAAA";
            var token2 = "BBBBBBBBBBBB";
            var distance = LevenshteinModify.GetTokenDistance(token1, token2);
            Assert.Equal(1, distance);
        }
        
        //Тест вычисления степени схожести токенов при их полном отличии токенов
        [Fact]
        public void GetTokenDistance_TestTokenDistanceWithSimilarTokens_IsEqualZero()
        {
            var token1 = "AAAAAAAAAAAA";
            var token2 = "AAAAAAAAAAAA";
            var distance = LevenshteinModify.GetTokenDistance(token1, token2);
            Assert.Equal(0, distance);
        }
        
        
        //Тест вычисления степени схожести токенов при их половинной схожести
        [Fact]
        public void GetTokenDistance_TestTokenDistanceWithHalfSimilarTokens_ReturnHalf()
        {
            var token1 = "AAAABBBAABBB";
            var token2 = "AAAAAAAAAAAA";
            var distance = LevenshteinModify.GetTokenDistance(token1, token2);
            Assert.Equal(0.5, distance);
        }
    }
}