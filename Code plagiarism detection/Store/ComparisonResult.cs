namespace CodePlagiarismDetection
{
    public class ComparisonResult
    {
        public readonly double Similarity;
        public readonly FileContent File1;
        public readonly FileContent File2;

        public ComparisonResult(FileContent file1, FileContent file2, double similarity)
        {
            File1 = file1;
            File2 = file2;
            Similarity = similarity;
        }
    }
}