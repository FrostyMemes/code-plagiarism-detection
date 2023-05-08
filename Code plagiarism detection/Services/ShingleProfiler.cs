using System;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace CodePlagiarismDetection.Services
{
    public static class ShingleProfiler
    {
        public static int N = 2;
        public static Dictionary<string, int> GetShingleProfile(string text)
        {
            var shingle = String.Empty;
            var stringWithoutSpaces = Regex.Replace(text,@"\s+"," ");
            var shingles = new Dictionary<string, int>();
            
            for (int i = 0; i < (stringWithoutSpaces.Length-N+1); i++)
            {
                shingle = stringWithoutSpaces.Substring(i, N);
                if (shingles.ContainsKey(shingle))
                {
                    var old = shingles[shingle];
                    shingles[shingle] = old + 1;
                }
                else
                    shingles[shingle] = 1;
            }
            return shingles;
        }
        
        public static Dictionary<string, int> GetShingleProfile(string text, int n)
        {
            var shingle = String.Empty;
            var stringWithoutSpaces = Regex.Replace(text,@"\s+"," ");
            var shingles = new Dictionary<string, int>();
            
            for (int i = 0; i < (stringWithoutSpaces.Length-n+1); i++)
            {
                shingle = stringWithoutSpaces.Substring(i, n);
                if (shingles.ContainsKey(shingle))
                {
                    var old = shingles[shingle];
                    shingles[shingle] = old + 1;
                }
                else
                    shingles[shingle] = 1;
            }
            return shingles;
        }

        public static IEnumerable<string> GetShingles(string text, int n)
        {
            if (text.Length < n)
                yield return text;
            
            for (int i = 0; i < text.Length - n + 1; i++)
                yield return text.Substring(i, n);
        }
    }
}