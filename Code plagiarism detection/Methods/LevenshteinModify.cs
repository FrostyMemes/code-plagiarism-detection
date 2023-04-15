using System;
using System.Collections.Generic;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Methods
{
    public class LevenshteinModify: SimilairyMethod
    {
        protected override ComparisonResult CompareFiles(FileContent file1, FileContent file2)
        {
            if (file1.Tokens == null || file2.Tokens == null)
                throw new ArgumentNullException("String must not be null");

            var s1 = file1.Tokens;
            var s2 = file2.Tokens;
            double diff;
            double[,] m = new double[s1.Count + 1, s2.Count + 1];

            for (int i = 0; i <= s1.Count; i++) { m[i, 0] = i; }
            for (int j = 0; j <= s2.Count; j++) { m[0, j] = j; }

            for (int i = 1; i <= s1.Count; i++)
            for (int j = 1; j <= s2.Count; j++)
            {
                diff = (s1[i - 1] == s2[j - 1]) 
                    ? 0 
                    : TokenDistance.GetTokenDistance(s1[i - 1], s2[j - 1]);

                m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1,
                        m[i, j - 1] + 1),
                    m[i - 1, j - 1] + diff);
            }

            var distance = m[s1.Count, s2.Count];
            var normalizedDistance = 1 - (m[s1.Count, s2.Count] / 
                                          Math.Max(file1.Tokens.Count, file2.Tokens.Count));
            
            return new ComparisonResult(file1, file2, normalizedDistance);
        }

        /*private double[] GetLevinsteinMatrix(List<s>)
        {
            
        }*/
    }
}