using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text.RegularExpressions;

namespace CodePlagiarismDetection.Services
{
    public static class ShingleProfiler
    {
        public static int N = 2;
        public static Dictionary<string, int> GetProfile(string str)
        {
            var old = 0;
            var shingle = String.Empty;
            var stringWitoutSpaces = Regex.Replace(str,@"\s+"," ");
            var shingles = new Dictionary<string, int>();
            
            for (int i = 0; i < (stringWitoutSpaces.Length-N+1); i++)
            {
                shingle = stringWitoutSpaces.Substring(i, N);
                if (shingles.ContainsKey(shingle))
                {
                    old = shingles[shingle];
                    shingles[shingle] = old + 1;
                }
                else
                    shingles[shingle] = 1;
            }
            return shingles;
        }
    }
}