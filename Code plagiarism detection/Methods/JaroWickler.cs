using System;
using System.Linq;

namespace CodePlagiarismDetection.Methods
{
    public class JaroWickler: SimilarityMethod
    {
        private const double THRESHOLD = 0.7;
        private const double JW_COEF = 0.1;
        protected override ComparisonResult CompareFiles(FileContent originalFile, FileContent comparedFile)
        {
            if (originalFile.NormalizedText == null) 
                throw new ArgumentNullException($"{originalFile.FileName} text must not be null");
            
            if (comparedFile.NormalizedText == null)
                throw new ArgumentNullException($"{comparedFile.FileName} text must not be null");
            
            var s1 = originalFile.NormalizedText;
            var s2 = comparedFile.NormalizedText;
            

            if (s1.Equals(s2))
            {
                return new ComparisonResult(originalFile, comparedFile, 1.0);
            }

            var jaroInfoMatrix = GetJaroInfoMatrix(s1, s2);
            var matches = (double)jaroInfoMatrix[0];
            var halfTranspositionsCount = (double)jaroInfoMatrix[1];
            var prefix = jaroInfoMatrix[2];
            var maxStringLenght = (double)jaroInfoMatrix[3];
            if (matches == 0)
                return new ComparisonResult(originalFile, comparedFile, 0.0);

            var jaroSimilarity = (matches / s1.Length + matches / s2.Length + (matches - halfTranspositionsCount) / matches)
                       / 3;
            double jaroWicklerSimilarity = jaroSimilarity;

            if (jaroSimilarity > THRESHOLD)
                jaroWicklerSimilarity = jaroSimilarity + Math.Min(JW_COEF, 1.0 / maxStringLenght) * prefix * (1 - jaroSimilarity);

            return new ComparisonResult(originalFile, comparedFile, jaroWicklerSimilarity);
        }
        
        private static int[] GetJaroInfoMatrix(string s1, string s2)
        {
            string max, min;
            if (s1.Length > s2.Length)
            {
                max = s1;
                min = s2;
            }
            else
            {
                max = s2;
                min = s1;
            }
            int range = Math.Max(max.Length / 2 - 1, 0);
            int[] match_indexes = Enumerable.Repeat(-1, min.Length).ToArray();

            bool[] match_flags = new bool[max.Length];
            int matches = 0;
            for (int mi = 0; mi < min.Length; mi++)
            {
                char c1 = min[mi];
                for (int xi = Math.Max(mi - range, 0),
                        xn = Math.Min(mi + range + 1, max.Length); xi < xn; xi++)
                {
                    if (!match_flags[xi] && c1 == max[xi])
                    {
                        match_indexes[mi] = xi;
                        match_flags[xi] = true;
                        matches++;
                        break;
                    }
                }
            }
            char[] ms1 = new char[matches];
            char[] ms2 = new char[matches];
            for (int i = 0, si = 0; i < min.Length; i++)
            {
                if (match_indexes[i] != -1)
                {
                    ms1[si] = min[i];
                    si++;
                }
            }
            for (int i = 0, si = 0; i < max.Length; i++)
            {
                if (match_flags[i])
                {
                    ms2[si] = max[i];
                    si++;
                }
            }
            int transpositions = 0;
            for (int mi = 0; mi < ms1.Length; mi++)
            {
                if (ms1[mi] != ms2[mi])
                {
                    transpositions++;
                }
            }
            int prefix = 0;
            for (int mi = 0; mi < min.Length; mi++)
            {
                if (s1[mi] == s2[mi])
                {
                    prefix++;
                }
                else
                {
                    break;
                }
            }
            return new[] { matches, transpositions / 2, prefix, max.Length };
        }
    }
}