using System;
using System.Collections.Generic;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Methods
{
    public class JaccardCoefficient: SimilairyMethod
    {
        protected override ComparisonResult CompareFiles(FileContent file1, FileContent file2)
        {
            
            if (file1.NormalizedText== null || file2.NormalizedText == null)
                throw new ArgumentNullException("String must not be null");

            var s1 = file1.NormalizedText;
            var s2 = file2.NormalizedText;
            var similarity = 0.0;
            if (s1.Equals(s2))
                similarity = 1.0;
        
            if (s1.Length < ShingleProfiler.N || s2.Length < ShingleProfiler.N )
                similarity = 0.0;
            
            var profile1 = ShingleProfiler.GetProfile(s1);
            var profile2 = ShingleProfiler.GetProfile(s2);
            HashSet<String> union = new HashSet<string>();
            union.UnionWith(profile1.Keys);
            union.UnionWith(profile2.Keys);
        
            int inter = profile1.Keys.Count + profile2.Keys.Count
                        - union.Count;
            
            similarity = (double)inter / union.Count;
            return new ComparisonResult(file1, file2, similarity);
        }
    }
}