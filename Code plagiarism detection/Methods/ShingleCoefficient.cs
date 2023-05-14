using System;
using System.Collections.Generic;
using System.Linq;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Methods
{
    public class ShingleCoefficient: SimilarityMethod
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
            var intersection = profile1.Keys.Intersect(profile2.Keys);
            var intersectionShingleCount = intersection.Sum(shingle => Math.Min(profile1[shingle], profile2[shingle]));
            var profile1ShingleCount = profile1.Sum(shingle => shingle.Value);
            var profile2ShingleCount = profile2.Sum(shingle => shingle.Value);


            similarity = (2.0 * intersectionShingleCount)
                         /(profile1ShingleCount + profile2ShingleCount);
            
            return new ComparisonResult(originalFile, comparedFile, similarity);
        }
        
    }
}