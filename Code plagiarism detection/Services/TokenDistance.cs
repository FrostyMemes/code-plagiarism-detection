using System.Collections.Generic;

namespace CodePlagiarismDetection.Services
{
    public static class TokenDistance
    {
        public static double GetTokenDistance(string token1, string token2)
        {
            var commonLetters = new HashSet<char>(token1);
            commonLetters.IntersectWith(new HashSet<char>(token2));
            var allLetters = new HashSet<char>(token1);
            allLetters.UnionWith(new HashSet<char>(token2));
            return 1 - commonLetters.Count / (double) allLetters.Count;
        }
    }
}