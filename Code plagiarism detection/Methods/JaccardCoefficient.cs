using System;
using System.Collections.Generic;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Methods
{
    public class JaccardCoefficient: SimilarityMethod
    {
        //Реализация нахождения схожести по коэфициенту Жаккара
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
            var union = new HashSet<string>();
            union.UnionWith(profile1.Keys);
            union.UnionWith(profile2.Keys);

            var intersection = new HashSet<string>(profile1.Keys);
            intersection.IntersectWith(profile2.Keys);
            
            similarity = (double) intersection.Count / union.Count;
            return new ComparisonResult(originalFile, comparedFile, similarity);
        }
        
        
    }
}