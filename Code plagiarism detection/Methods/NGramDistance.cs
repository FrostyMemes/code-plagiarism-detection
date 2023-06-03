using System;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Methods
{
    public class NGramDistance: SimilarityMethod
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

            var nDistance = GetNGramDistance(s1, s2, ShingleProfiler.N);
            similarity = 1 - nDistance;
            return new ComparisonResult(originalFile, comparedFile, similarity);
        }
        
        private double GetNGramDistance(string originalString, string comparedString, int n)
        {
            const char specialPrefix = '\n';
            var originalStringLength = originalString.Length;
            var comparedStringLength = comparedString.Length;
            
            if (originalStringLength == 0 || comparedStringLength == 0)
                return 1;

            var cost = 0;
            if (originalStringLength < n || comparedStringLength < n)
            {
                for (int i1 = 0, min = Math.Min(originalStringLength, comparedStringLength); i1 < min; i1++)
                {
                    if (originalString[i1] == comparedString[i1])
                    {
                        cost++;
                    }
                }
                return (float)cost / Math.Max(originalStringLength, comparedStringLength);
            }

            var originalStringChars = new char[originalStringLength + n - 1];
            float[] costArray; 
            float[] previousCostArray; 
            float[] tempForCostArrays; 

         
            for (int i1 = 0; i1 < originalStringChars.Length; i1++)
            {
                if (i1 < n - 1)
                {
                    originalStringChars[i1] = specialPrefix; 
                }
                else
                {
                    originalStringChars[i1] = originalString[i1 - n + 1];
                }
            }
            previousCostArray = new float[originalStringLength + 1];
            costArray = new float[originalStringLength + 1];

           
            int iOriginal; 
            int jCompared; 

            char[] comparedStringNgram = new char[n]; 

            for (iOriginal = 0; iOriginal <= originalStringLength; iOriginal++)
            {
                previousCostArray[iOriginal] = iOriginal;
            }

            for (jCompared = 1; jCompared <= comparedStringLength; jCompared++)
            {
               
                if (jCompared < n)
                {
                    for (int ti = 0; ti < n - jCompared; ti++)
                    {
                        comparedStringNgram[ti] = specialPrefix;
                    }
                    for (int ti = n - jCompared; ti < n; ti++)
                    {
                        comparedStringNgram[ti] = comparedString[ti - (n - jCompared)];
                    }
                }
                else
                {
                    comparedStringNgram = comparedString.Substring(jCompared - n, n).ToCharArray();
                }
                costArray[0] = jCompared;
                for (iOriginal = 1; iOriginal <= originalStringLength; iOriginal++)
                {
                    cost = 0;
                    int tn = n;
                    for (int ni = 0; ni < n; ni++)
                    {
                        if (originalStringChars[iOriginal - 1 + ni] != comparedStringNgram[ni])
                        {
                            cost++;
                        }
                        else if (originalStringChars[iOriginal - 1 + ni] == specialPrefix)
                        {
                            tn--;
                        }
                    }
                    float ec = (float)cost / tn;
                    costArray[iOriginal] = Math.Min(
                        Math.Min(costArray[iOriginal - 1] + 1, previousCostArray[iOriginal] + 1), 
                        previousCostArray[iOriginal - 1] + ec);
                }
                tempForCostArrays = previousCostArray;
                previousCostArray = costArray;
                costArray = tempForCostArrays;
            }
            return previousCostArray[originalStringLength] / Math.Max(comparedStringLength, originalStringLength);
        }
    }
}