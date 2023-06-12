using System;
using System.Linq;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Methods
{
    public class NGramDistance: SimilarityMethod
    {
        //Реализация нахождения схожести исхондых кодов методом N-расстояния
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

            similarity = 1 - GetNGramDistance(s1, s2);
            return new ComparisonResult(originalFile, comparedFile, similarity);
        }
        
        //Нахождение N-расстояния двух строк
        private double GetNGramDistance(string originalString, string comparedString)
        {
            var shinglesOriginalFiles = ShingleProfiler.GetShingles(originalString, ShingleProfiler.N).ToList();
            var shinglesComparedFiles = ShingleProfiler.GetShingles(comparedString, ShingleProfiler.N).ToList();

            var D = new double[shinglesOriginalFiles.Count + 1, shinglesComparedFiles.Count + 1];
            
            for (int i = 0; i <= shinglesOriginalFiles.Count; i++) { D[i, 0] = i; }
            for (int j = 0; j <= shinglesComparedFiles.Count; j++) { D[0, j] = j; }

            for (int i = 1; i <= shinglesOriginalFiles.Count; i++)
                for (int j = 1; j <= shinglesComparedFiles.Count; j++)
                {
                    var distance = GetShingleDistance(shinglesOriginalFiles[i-1], shinglesComparedFiles[j-1]);
                        
                    D[i, j] = Math.Min(Math.Min(D[i - 1, j] + 1,
                            D[i, j - 1] + 1),
                        D[i - 1, j - 1] + distance);
                }

            return D[shinglesOriginalFiles.Count, shinglesComparedFiles.Count]
                   /Math.Max(shinglesOriginalFiles.Count, shinglesComparedFiles.Count);;
        }

        
        //Нахождение степени схоести двух шинглов
        private double GetShingleDistance(string shingle1, string shingle2)
        {
            var distance = 0;
            for (int i = 0; i < ShingleProfiler.N; i++)
            {
                if (shingle1[i].Equals(shingle2[i]))
                    distance++;
            }
            return (double)distance/ShingleProfiler.N;
        }
    }
}