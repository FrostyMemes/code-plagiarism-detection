namespace CodePlagiarismDetection
{
    public class ComparisonResult
    {
        public readonly double Similarity;
        public readonly FileContent OriginalFile;
        public readonly FileContent ComparedFile;

        public ComparisonResult(FileContent originalFile, FileContent comparedFile, double similarity)
        {
            OriginalFile = originalFile;
            ComparedFile = comparedFile;
            Similarity = similarity;
        }
    }
}