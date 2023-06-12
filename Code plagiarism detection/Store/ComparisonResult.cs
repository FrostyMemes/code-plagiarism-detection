namespace CodePlagiarismDetection
{
    public class ComparisonResult
    {
        public readonly double Similarity; //Степень схожести двух текстов исходных кодов
        public readonly FileContent OriginalFile; //Информация о первом файле
        public readonly FileContent ComparedFile; //Информация о втором файле

        public ComparisonResult(FileContent originalFile, FileContent comparedFile, double similarity)
        {
            OriginalFile = originalFile;
            ComparedFile = comparedFile;
            Similarity = similarity;
        }
    }
}