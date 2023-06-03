using CodePlagiarismDetection.Services;
using Xunit;

namespace ModuleTests.ServiceTests
{
    public class ShingleProfilerTests
    {
        readonly string testStringForCountingShingles = "ABCDEFGH";
        
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GetShingleProfile_GenerateCountShingleWithParametrNlenght_IsEqual(int shingleLenght)
        {
            var profile = ShingleProfiler.GetShingleProfile(testStringForCountingShingles, shingleLenght);
            var profileShingleCount = profile.Count;
            Assert.Equal(testStringForCountingShingles.Length - shingleLenght + 1, profileShingleCount);
        }
        
        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GetShingleProfile_ShinglesCountWithPropertyNlenght_IsEqual(int shingleLenght)
        {
            ShingleProfiler.N = shingleLenght;
            var profile = ShingleProfiler.GetShingleProfile(testStringForCountingShingles);
            var profileShingleCount = profile.Count;
            Assert.Equal(testStringForCountingShingles.Length - shingleLenght + 1, profileShingleCount);
        }

        [Theory]
        [InlineData(2)]
        [InlineData(3)]
        [InlineData(4)]
        public void GetShingleProfile_ShinglesCountForStringWithSameCharsEqualToOne_IsEqual(int shingleLenght)
        {
            var testString = "AAAAAAAAAAAAAAAAAAAAAAA";
            var profile = ShingleProfiler.GetShingleProfile(testString, shingleLenght);
            var profileShingleCount = profile.Count;
            Assert.Equal(1, profileShingleCount);
        }
        
        
    }
}