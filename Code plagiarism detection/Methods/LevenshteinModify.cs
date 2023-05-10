using System;
using System.Collections.Generic;
using System.Linq;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Methods
{
    public class LevenshteinModify: SimilairyMethod
    {
        protected override ComparisonResult CompareFiles(FileContent originalFile, FileContent comparedFile)
        {
            if (originalFile.Literals == null) 
                throw new ArgumentNullException($"{originalFile.FileName} text must not be null");
            
            if (comparedFile.Literals == null)
                throw new ArgumentNullException($"{comparedFile.FileName} text must not be null");

            var s1 = originalFile.Literals;
            var s2 = comparedFile.Literals;

            if (s1.Count == 0 || s2.Count == 0)
                return new ComparisonResult(originalFile, comparedFile, 0.0);

            var normalizedDistance = 1 - (GetLevensteinModifyDistance(s1, s2) / 
                                          Math.Max(originalFile.Literals.Count, comparedFile.Literals.Count));
            
            return new ComparisonResult(originalFile, comparedFile, normalizedDistance);
        }

        private double GetLevensteinModifyDistance(List<string> s1, List<string> s2)
        {
            var m = new double[s1.Count + 1, s2.Count + 1];

            s1.Sort();
            s2.Sort();
            
            for (int i = 0; i <= s1.Count; i++) { m[i, 0] = i; }
            for (int j = 0; j <= s2.Count; j++) { m[0, j] = j; }

            for (int i = 1; i <= s1.Count; i++)
                for (int j = 1; j <= s2.Count; j++)
                {
                   var diff = (s1[i - 1] == s2[j - 1]) 
                        ? 0 
                        : TokenDistance.GetTokenDistance(s1[i - 1], s2[j - 1]);

                    m[i, j] = Math.Min(Math.Min(m[i - 1, j] + 1,
                            m[i, j - 1] + 1),
                        m[i - 1, j - 1] + diff);
                }

            return m[s1.Count, s2.Count];
        }
    }
}