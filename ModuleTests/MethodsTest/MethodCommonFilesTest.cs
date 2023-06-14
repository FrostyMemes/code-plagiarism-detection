using System;
using System.IO;
using System.Linq;
using System.Threading;
using CodePlagiarismDetection;
using CodePlagiarismDetection.Methods;
using CodePlagiarismDetection.Services;
using Xunit;

namespace ModuleTests.ServiceTests
{
    public class MethodCommonFilesTest
    {
        private static string rootDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
            "..", 
            "..", @"MethodsTest\TestFiles"); //Директория с тестовыми файлами
        
        private SimilarityMethod _shingleMethod = new ShingleCoefficient(); //Создания экземпляра метода шинглов
        private SimilarityMethod _levenshteinMethod = new LevenshteinModify(); //Создания экземпляра метода Левенштейна
        private SimilarityMethod _sorensenMethod = new SorensenDiceCoefficient(); //Создания экземпляра метода Сёренсена
        private SimilarityMethod _jaccardMethod = new JaccardCoefficient(); //Создания экземпляра метода Жаккара
        private SimilarityMethod _cosineMethod = new Cosine(); //Создания экземпляра метода косинуса
        private SimilarityMethod _nGramDistanceMethod = new NGramDistance(); //Создания экземпляра метода N-расстояния
        private SimilarityMethod _lcsMethod = new LongestCommonSubsequence(); //Создания экземпляра метода НОП
        
        
        private static IProgress<int> IProgressPlug = new Progress<int>(_ => { }); //Заглушка для интерфейса прогресса
        private static CancellationToken CancellationTokenPlug = new CancellationToken(); //Заглушка для токена отмены
        
        [Fact]
        //Тест сравнения исходных кодов в общем случае
        public void SimilarityForCommonFiles_AllMethodsMustReturnSpecificSimilarityValue_ReturnTrueForAllMethods()
        {
            var directory = "CommonFiles";
            var path = Path.Combine(rootDirectory, directory);
            var directoryInfo = new DirectoryInfo(path);

            var files = FileLoader.LoadFiles(directoryInfo, SearchOption.TopDirectoryOnly)
                .Select(file => new FileContent(file))
                .ToList();;
            
            var shingleMethodResult = _shingleMethod.CompareFilePairwise(
                files, FilePairOption.CheckFileType, IProgressPlug, CancellationTokenPlug);
            
            var levenshteinMethodResult = _levenshteinMethod.CompareFilePairwise(
                files, FilePairOption.CheckFileType, IProgressPlug, CancellationTokenPlug);
            
            var sorensenMethodResult = _sorensenMethod.CompareFilePairwise(
                files, FilePairOption.CheckFileType, IProgressPlug, CancellationTokenPlug);
            
            var jaccardMethodResult = _jaccardMethod.CompareFilePairwise(
                files, FilePairOption.CheckFileType, IProgressPlug, CancellationTokenPlug);
            
            var cosineMethodResult = _cosineMethod.CompareFilePairwise(
                files, FilePairOption.CheckFileType, IProgressPlug, CancellationTokenPlug);
            
            var nGramDistanceMethodResult = _nGramDistanceMethod.CompareFilePairwise(
                files, FilePairOption.CheckFileType, IProgressPlug, CancellationTokenPlug);
            
            var lcsMethodResult = _lcsMethod.CompareFilePairwise(
                files, FilePairOption.CheckFileType, IProgressPlug, CancellationTokenPlug);
            
            Assert.Equal(0.59, shingleMethodResult.First().Similarity, 2);
            Assert.Equal(0.5, levenshteinMethodResult.First().Similarity, 2);
            Assert.Equal(0.66, sorensenMethodResult.First().Similarity, 2);
            Assert.Equal(0.49, jaccardMethodResult.First().Similarity, 2);
            Assert.Equal(0.8, cosineMethodResult.First().Similarity, 2);
            Assert.Equal(0.72, nGramDistanceMethodResult.First().Similarity, 2);
            Assert.Equal(0.39, lcsMethodResult.First().Similarity, 2);
        }
    }
}