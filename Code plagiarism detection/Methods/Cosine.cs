using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Methods
{
    public class Cosine
    {

        public List<ComparisonResult> CompareFilePairwise(IEnumerable<FileContent> files, FilePairOption option)
        {
            var fileList = files.ToList();
            var result = new List<ComparisonResult>();
            for (int i = 0; i < fileList.Count; i++)
                for (int j = i + 1; j < fileList.Count; j++)
                {
                    if (option == FilePairOption.CheckFileType && !fileList[i].Extension.Equals(fileList[j].Extension))
                        continue;
                    
                    result.Add(CompareFiles(fileList[i], fileList[j]));
                }
            return result;
        }
        
        private ComparisonResult CompareFiles(FileContent file1, FileContent file2)
        {
            var s1 = file1.NormalizedText;
            var s2 = file2.NormalizedText;
            if (s1 == null || s2 == null)
            {
                throw new ArgumentNullException("String must not be null");
            }

            var similarity = 0.0;
            if (s1.Equals(s2))
                similarity = 1.0;
        
            if (s1.Length < ShingleProfiler.N || s2.Length < ShingleProfiler.N )
                similarity = 0.0;

            var profile1 = ShingleProfiler.GetProfile(s1);
            var profile2 = ShingleProfiler.GetProfile(s2);

            similarity = DotProduct(profile1, profile2) / (Norm(profile1) * Norm(profile2));
            return new ComparisonResult(file1, file2, similarity);
        }
        
        private static double DotProduct(Dictionary<string, int> profile1, Dictionary<string, int> profile2)
        {
            Dictionary<string, int> small_profile = profile2;
            Dictionary<string, int> large_profile = profile1;

            if (profile1.Count < profile2.Count)
            {
                small_profile = profile1;
                large_profile = profile2;
            }

            double agg = 0;
            int i = 0;

            foreach (var pair in small_profile)
            {
                if (large_profile.ContainsKey(pair.Key))
                    agg += 1.0 * pair.Value * large_profile[pair.Key];
            }

            return agg;
        }
        
        private static double Norm(Dictionary<string, int> profile)
        {
            double agg = 0;

            foreach (var pair in profile)
            {
                agg += 1.0 * pair.Value * pair.Value;
            }

            return Math.Sqrt(agg);
        }
    }
}