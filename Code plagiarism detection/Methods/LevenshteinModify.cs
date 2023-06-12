using System;
using System.Collections.Generic;
using System.Linq;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Methods
{
    public class LevenshteinModify: SimilarityMethod
    {
        //Реализация нахождения схожести модифицированным методом Левенштейна
        protected override ComparisonResult CompareFiles(FileContent originalFile, FileContent comparedFile)
        {
            var s1 = LiteralTokenizer.GetTokens(originalFile.NormalizedText).ToList();
            var s2 = LiteralTokenizer.GetTokens(comparedFile.NormalizedText).ToList();
            
            if (s1 == null) 
                throw new ArgumentNullException($"{originalFile.FileName} text must not be null");
            
            if (s2 == null)
                throw new ArgumentNullException($"{comparedFile.FileName} text must not be null");

            if (s1.Count == 0 || s2.Count == 0)
                return new ComparisonResult(originalFile, comparedFile, 0.0);

            var normalizedDistance = 1 - (GetLevensteinModifyDistance(s1, s2) / 
                                          Math.Max(s1.Count, s2.Count));
            
            return new ComparisonResult(originalFile, comparedFile, normalizedDistance);
        }

        private double GetLevensteinModifyDistance(List<string> s1, List<string> s2)
        {
            var D = new double[s1.Count + 1, s2.Count + 1];

            s1.Sort();
            s2.Sort();
            
            for (int i = 0; i <= s1.Count; i++) { D[i, 0] = i; } 
            for (int j = 0; j <= s2.Count; j++) { D[0, j] = j; }

            for (int i = 1; i <= s1.Count; i++)
                for (int j = 1; j <= s2.Count; j++)
                {
                   var diff = (s1[i - 1].Equals(s2[j - 1])) 
                        ? 0 
                        : GetTokenDistance(s1[i - 1], s2[j - 1]);

                    D[i, j] = Math.Min(Math.Min(D[i - 1, j] + 1,
                            D[i, j - 1] + 1),
                        D[i - 1, j - 1] + diff);
                }

            return D[s1.Count, s2.Count];
        }
        
        public static double GetTokenDistance(string token1, string token2)
        {
            var union = new HashSet<char>();
            union.UnionWith(token1);
            union.UnionWith(token2);
            var intersection = new HashSet<char>(token1);
            intersection.IntersectWith(token2);
            return 1 - intersection.Count / (double) union.Count;
        }
    }
}