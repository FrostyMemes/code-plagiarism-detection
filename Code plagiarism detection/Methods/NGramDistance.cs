using System;
using System.Linq;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection.Methods
{
    public class NGramDistance: SimilairyMethod
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
        
        
        private double GetNGramDistanceRecursive(string originalString, string comparedString,
            int originalPrefixStringLenght, int comparedPrefixStringLenght, int n)
        {
            if (originalPrefixStringLenght == n && comparedPrefixStringLenght == n)
            {
                for (int i = 0; i != n; i++)
                {
                    if (originalString[i] != comparedString[i])
                        return 1;
                }
                return 0;
            }

            if ((originalPrefixStringLenght == n && comparedPrefixStringLenght > n)
                || (originalPrefixStringLenght > n && comparedPrefixStringLenght == n))
            {
                return 1;
            }

            var cost = 0.0;
            var shingleDistance = 0;
            for (int i = 0; i != n; i++)
            {
                shingleDistance += (originalString[originalPrefixStringLenght - i - 1] ==
                                    comparedString[comparedPrefixStringLenght - i - 1])
                    ? 1
                    : 0 ;
            }

            cost = (double) shingleDistance / n;

            return Math.Min(
                Math.Min(
                    GetNGramDistanceRecursive(originalString, comparedString, originalPrefixStringLenght - 1,
                        comparedPrefixStringLenght, n) + 1,
                    GetNGramDistanceRecursive(originalString, comparedString, originalPrefixStringLenght,
                        comparedPrefixStringLenght - 1, n) + 1
                ),
                GetNGramDistanceRecursive(originalString, comparedString, originalPrefixStringLenght - 1,
                    comparedPrefixStringLenght - 1, n) + cost
            );
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
            float[] costArray; // Cost array, horizontally
            float[] previousCostArray; // 'previous' cost array, horizontally
            float[] tempForCostArrays; // Placeholder to assist in swapping p and d

            // Construct sa with prefix
            for (int i1 = 0; i1 < originalStringChars.Length; i1++)
            {
                if (i1 < n - 1)
                {
                    originalStringChars[i1] = specialPrefix; // Add prefix
                }
                else
                {
                    originalStringChars[i1] = originalString[i1 - n + 1];
                }
            }
            previousCostArray = new float[originalStringLength + 1];
            costArray = new float[originalStringLength + 1];

            // Indexes into strings s and t
            int iOriginal; // Iterates through source
            int jCompared; // Iterates through target

            char[] comparedStringNgram = new char[n]; // jth n-gram of t

            for (iOriginal = 0; iOriginal <= originalStringLength; iOriginal++)
            {
                previousCostArray[iOriginal] = iOriginal;
            }

            for (jCompared = 1; jCompared <= comparedStringLength; jCompared++)
            {
                // Construct t_j n-gram 
                if (jCompared < n)
                {
                    for (int ti = 0; ti < n - jCompared; ti++)
                    {
                        comparedStringNgram[ti] = specialPrefix; // Add prefix
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
                    // Compare sa to t_j
                    for (int ni = 0; ni < n; ni++)
                    {
                        if (originalStringChars[iOriginal - 1 + ni] != comparedStringNgram[ni])
                        {
                            cost++;
                        }
                        else if (originalStringChars[iOriginal - 1 + ni] == specialPrefix)
                        { 
                            // Discount matches on prefix
                            tn--;
                        }
                    }
                    float ec = (float)cost / tn;
                    // Minimum of cell to the left+1, to the top+1, diagonally left and up +cost
                    costArray[iOriginal] = Math.Min(
                        Math.Min(costArray[iOriginal - 1] + 1, previousCostArray[iOriginal] + 1), 
                        previousCostArray[iOriginal - 1] + ec);
                }
                // Copy current distance counts to 'previous row' distance counts
                tempForCostArrays = previousCostArray;
                previousCostArray = costArray;
                costArray = tempForCostArrays;
            }

            // Our last action in the above loop was to switch d and p, so p now
            // actually has the most recent cost counts
            return previousCostArray[originalStringLength] / Math.Max(comparedStringLength, originalStringLength);
        }
    }
}