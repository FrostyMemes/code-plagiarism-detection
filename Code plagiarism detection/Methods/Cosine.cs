using System;
using System.Collections.Generic;
using System.Linq;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Methods
{
    public class Cosine: SimilairyMethod
    {
        protected override ComparisonResult CompareFiles(FileContent originalFile, FileContent comparedFile)
        {
            
            if (originalFile.NormalizedText == null) 
                throw new ArgumentNullException($"{originalFile.FileName} text must not be null");
            
            if (comparedFile.NormalizedText == null)
                throw new ArgumentNullException($"{comparedFile.FileName} text must not be null");
            
            var s1 = originalFile.NormalizedText;
            var s2 = comparedFile.NormalizedText;
            var similarity = 0.0;
            
            if (s1.Equals(s2))
                return new ComparisonResult(originalFile, comparedFile, 1.0);
        
            if (s1.Length < ShingleProfiler.N || s2.Length < ShingleProfiler.N )
                return new ComparisonResult(originalFile, comparedFile, 0.0);

            var profile1 = ShingleProfiler.GetShingleProfile(s1);
            var profile2 = ShingleProfiler.GetShingleProfile(s2);

            var dot = DotProduct(profile1, profile2);
            var norm1 = Norm(profile1);
            var norm2 = Norm(profile2);
            similarity = DotProduct(profile1, profile2) / (Norm(profile1) * Norm(profile2));
            return new ComparisonResult(originalFile, comparedFile, similarity);
        }
        
        private static double DotProduct(Dictionary<string, int> profile1, Dictionary<string, int> profile2)
        {
            var dot = 0.0;
            var intersection = profile1.Keys.Intersect(profile2.Keys);

            foreach (var shingle in intersection)
                dot += 1.0 * profile1[shingle] * profile2[shingle];

            return dot;
        }
        
        private static double Norm(Dictionary<string, int> profile)
        {
            var agg = 0.0;

            foreach (var pair in profile)
            {
                agg += 1.0 * Math.Pow(pair.Value, 2);
            }

            return Math.Sqrt(agg);
        }
    }
}