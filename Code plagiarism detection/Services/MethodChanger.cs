using System.Collections.Generic;
using CodePlagiarismDetection.Methods;

namespace CodePlagiarismDetection.Services
{
    public static class MethodChanger
    {
        private static Dictionary<MethodOption, SimilairyMethod> methods 
            = new Dictionary<MethodOption, SimilairyMethod>()
            {
                {MethodOption.Cosine, new Cosine()},
                {MethodOption.LevensteinModify, new LevenshteinModify()},
                {MethodOption.JaccardCoefficient, new JaccardCoefficient()}
            };

        public static SimilairyMethod ChangeMethod(MethodOption method)
        {
            return methods[method];
        }
    }
}