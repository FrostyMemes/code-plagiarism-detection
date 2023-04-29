using System;
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
            
            similarity = 1 - GetNGramDistance(s1, s2, ShingleProfiler.N);
            return new ComparisonResult(originalFile, comparedFile, similarity);
        }
        
        private double GetNGramDistance(string originalString, string comparedString, int n)
        {
            const char special = '\n';
            var sl = originalString.Length;
            var tl = comparedString.Length;
            
            if (sl == 0 || tl == 0)
                return 1;

            var cost = 0;
            if (sl < n || tl < n)
            {
                for (int i1 = 0, ni = Math.Min(sl, tl); i1 < ni; i1++)
                {
                    if (originalString[i1] == comparedString[i1])
                    {
                        cost++;
                    }
                }
                return (float)cost / Math.Max(sl, tl);
            }

            var sa = new char[sl + n - 1];
            float[] p; // 'previous' cost array, horizontally
            float[] d; // Cost array, horizontally
            float[] d2; // Placeholder to assist in swapping p and d

            // Construct sa with prefix
            for (int i1 = 0; i1 < sa.Length; i1++)
            {
                if (i1 < n - 1)
                {
                    sa[i1] = special; // Add prefix
                }
                else
                {
                    sa[i1] = originalString[i1 - n + 1];
                }
            }
            p = new float[sl + 1];
            d = new float[sl + 1];

            // Indexes into strings s and t
            int i; // Iterates through source
            int j; // Iterates through target

            char[] t_j = new char[n]; // jth n-gram of t

            for (i = 0; i <= sl; i++)
            {
                p[i] = i;
            }

            for (j = 1; j <= tl; j++)
            {
                // Construct t_j n-gram 
                if (j < n)
                {
                    for (int ti = 0; ti < n - j; ti++)
                    {
                        t_j[ti] = special; // Add prefix
                    }
                    for (int ti = n - j; ti < n; ti++)
                    {
                        t_j[ti] = comparedString[ti - (n - j)];
                    }
                }
                else
                {
                    t_j = comparedString.Substring(j - n, n).ToCharArray();
                }
                d[0] = j;
                for (i = 1; i <= sl; i++)
                {
                    cost = 0;
                    int tn = n;
                    // Compare sa to t_j
                    for (int ni = 0; ni < n; ni++)
                    {
                        if (sa[i - 1 + ni] != t_j[ni])
                        {
                            cost++;
                        }
                        else if (sa[i - 1 + ni] == special)
                        { 
                            // Discount matches on prefix
                            tn--;
                        }
                    }
                    float ec = (float)cost / tn;
                    // Minimum of cell to the left+1, to the top+1, diagonally left and up +cost
                    d[i] = Math.Min(Math.Min(d[i - 1] + 1, p[i] + 1), p[i - 1] + ec);
                }
                // Copy current distance counts to 'previous row' distance counts
                d2 = p;
                p = d;
                d = d2;
            }

            // Our last action in the above loop was to switch d and p, so p now
            // actually has the most recent cost counts
            return p[sl] / Math.Max(tl, sl);
        }
    }
}