using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CodePlagiarismDetection.Methods.Abstract
{
    public abstract class SimilairyMethod
    {
        public List<ComparisonResult> CompareFilePairwise(IEnumerable<FileContent> files, FilePairOption option,
            IProgress<int> progress)
        {
            var fileList = files.ToList();
            var result = new List<ComparisonResult>();
            for (int i = 0; i < fileList.Count; i++)
            for (int j = i + 1; j < fileList.Count; j++)
            {
                if (option == FilePairOption.CheckFileType && !fileList[i].Extension.Equals(fileList[j].Extension))
                    continue;

                result.Add(CompareFiles(fileList[i], fileList[j]));
                progress.Report(0);
            }
            return result;
        }
        
        protected abstract ComparisonResult CompareFiles(FileContent originalFile, FileContent comparedFile);
    }
}