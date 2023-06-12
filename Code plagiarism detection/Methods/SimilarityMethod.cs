using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CodePlagiarismDetection.Methods
{
    public abstract class SimilarityMethod
    {
        //Метод для создания пар обрабатываемых файлов
        public List<ComparisonResult> CompareFilePairwise(IEnumerable<FileContent> files, FilePairOption option,
            IProgress<int> progress, CancellationToken cancellationToken)
        {
            var fileList = files.ToList();
            var result = new List<ComparisonResult>();
            try
            {
                for (int i = 0; i < fileList.Count; i++)
                for (int j = i + 1; j < fileList.Count; j++)
                {
                    if (option == FilePairOption.CheckFileType && !fileList[i].Extension.Equals(fileList[j].Extension))
                        continue;

                    if (cancellationToken.IsCancellationRequested)
                        return result;

                    result.Add(CompareFiles(fileList[i], fileList[j]));
                    progress.Report(0);
                }

                return result;
            }
            catch (OperationCanceledException)
            {
                return result;
            }
            catch (Exception e)
            {
                MessageBox.Show($"Ошибка {e.Message}", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return result;
            }
        }
        
        //Метод для переопределения алгоритма сравнения пар исходных кодов
        protected abstract ComparisonResult CompareFiles(FileContent originalFile, FileContent comparedFile);
    }
}