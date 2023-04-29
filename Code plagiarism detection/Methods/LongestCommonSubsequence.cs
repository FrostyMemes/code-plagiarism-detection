﻿using System;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Methods
{
    public class LongestCommonSubsequence: SimilairyMethod
    {
        protected override ComparisonResult CompareFiles(FileContent originalFile, FileContent comparedFile)
        {
            if (originalFile.NormalizedText == null) 
                throw new ArgumentNullException($"{originalFile.FileName} text must not be null");
            
            if (comparedFile.NormalizedText == null)
                throw new ArgumentNullException($"{comparedFile.FileName} text must not be null");

            var s1 = originalFile.NormalizedText;
            var s2 = comparedFile.NormalizedText;

            if (s1.Equals(s2))
                return new ComparisonResult(originalFile, comparedFile, 1.0);

            var m = s1.Length;
            var n = s2.Length;
            var lengths = new int[m + 1, n + 1];

            for (int i = 1; i <= m; i++)
            {
                for (int j = 1; j <= n; j++)
                {
                    if (s1[i - 1] == s2[j - 1])
                        lengths[i, j] = lengths[i - 1, j - 1] + 1;
                    else
                        lengths[i, j] = Math.Max(lengths[i - 1, j], lengths[i, j - 1]);
                }
            }

            var normalizedDistance = 1.0 * lengths[m, n] / Math.Max(m, n);
            
            return new ComparisonResult(originalFile, comparedFile, normalizedDistance);
        }
    }
}