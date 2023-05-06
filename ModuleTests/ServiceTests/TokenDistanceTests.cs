using CodePlagiarismDetection.Services;
using Xunit;

namespace ModuleTests.ServiceTests
{
    public class TokenDistanceTests
    {
        [Fact]
        public void IsEqual_ShinglesCountWithPropertyNlenght_ReturnTrue()
        {
            var token1 = "AAAAAAAAAAAA";
            var token2 = "BBBBBBBBBBBB";
            var distance = TokenDistance.GetTokenDistance(token1, token2);
            Assert.Equal(1, distance);
        }
        
        [Fact]
        public void IsEqual_ShinglesCountWithPrpertyNlenght_ReturnTrue()
        {
            var token1 = "AAAAAAAAAAAA";
            var token2 = "AAAAAAAAAAAA";
            var distance = TokenDistance.GetTokenDistance(token1, token2);
            Assert.Equal(0, distance);
        }
    }
}