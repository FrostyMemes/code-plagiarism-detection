using System.Collections.Generic;
using System.Linq;

namespace CodePlagiarismDetection.Methods
{
    public abstract class SimilairyMethod
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
        protected abstract ComparisonResult CompareFiles(FileContent file1, FileContent file2);
    }
}