using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.IO;
using System.Threading.Tasks;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection
{
    public class FileContent
    {
        public readonly string FileName;
        public readonly string DirectoryName;
        public readonly string Extension;
        public readonly string Text;
        public readonly string NormalizedText;
        public readonly List<string> Tokens;

        public FileContent(string file)
        {
            FileName = Path.GetFileName(file);
            DirectoryName = Path.GetFileName(Path.GetDirectoryName(file));
            Extension = Path.GetExtension(file);
            Text = File.ReadAllText(file);
            NormalizedText = TextNormalizer.NormalizeText(Text);
            Tokens = Tokenizer.Tokenize(Text)
                .Where(token => token.All(c => !char.IsWhiteSpace(c)))
                .ToList();
        }
    }
}
