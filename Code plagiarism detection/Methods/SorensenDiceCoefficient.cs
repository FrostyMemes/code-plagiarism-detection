﻿using System;
using System.Collections.Generic;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Methods
{
    public class SorensenDiceCoefficient: SimilarityMethod
    {
        //Реализация нахождения схожести по коэфициенту Сёренсена
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
            
            var inter = profile1.Keys.Count + profile2.Keys.Count
                        - union.Count;
            
            similarity = 2.0 * inter / (profile1.Count + profile2.Count);
            
            return new ComparisonResult(originalFile, comparedFile, similarity);

        }
    }
}