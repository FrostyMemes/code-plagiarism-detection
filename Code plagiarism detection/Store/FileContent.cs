using System.IO;
using CodePlagiarismDetection.Services;

namespace CodePlagiarismDetection
{
    public class FileContent
    {
        public readonly string FileName; //Имя файла
        public readonly string DirectoryName; //Имя директории файла
        public readonly string FullPath; //Полный путь к файлу
        public readonly string Extension; //Расщирение файла
        public readonly string Text; //Текст исходный код
        public readonly string NormalizedText; //Нормализированный текст исходного кода

        public FileContent(string file)
        {
            FileName = Path.GetFileName(file);
            DirectoryName = Path.GetFileName(Path.GetDirectoryName(file));
            FullPath = file;
            Extension = Path.GetExtension(file);
            Text = File.ReadAllText(file);
            NormalizedText = TextNormalizer.NormalizeText(Text);
        }
    }
}
