using System.Collections.Generic;
using System.Linq;
using System.IO;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection
{
    public class FileContent
    {
        public readonly string FileName;
        public readonly string DirectoryName;
        public readonly string FullPath;
        public readonly string Extension;
        public readonly string Text;
        public readonly string NormalizedText;
        public readonly List<string> Literals;

        public FileContent(string file)
        {
            FileName = Path.GetFileName(file);
            DirectoryName = Path.GetFileName(Path.GetDirectoryName(file));
            FullPath = file;
            Extension = Path.GetExtension(file);
            Text = File.ReadAllText(file);
            NormalizedText = TextNormalizer.NormalizeText(Text);
            Literals = LiteralTokenizer.Tokenize(Text)
                .Where(token => token.All(c => !char.IsWhiteSpace(c)))
                .ToList();
        }
    }
}
