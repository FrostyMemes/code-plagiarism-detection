using System;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading;
using CodePlagiarismDetection;
using CodePlagiarismDetection.Methods;
using CodePlagiarismDetection.Services;
using Xunit;

namespace ModuleTests.ServiceTests
{
    public class MethodsTest
    {
        private string rootDirectory = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, 
            "..", 
            "..", @"MethodsTest\TestFiles");
        
        private SimilarityMethod _shingleMethod = new ShingleCoefficient();
        private SimilarityMethod _levenshteinMethod = new LevenshteinModify();
        private SimilarityMethod _sorensenMethod = new SorensenDiceCoefficient();
        private SimilarityMethod _jaccardMethod = new JaccardCoefficient();
        private SimilarityMethod _cosineMethod = new Cosine();
        private SimilarityMethod _nGramDistanceMethod = new NGramDistance();
        private SimilarityMethod _lcsMethod = new LongestCommonSubsequence();

        private static IProgress<int> IProgressPlug = new Progress<int>(_ => { });
        private static CancellationToken CancellationTokenPlug = new CancellationToken();
        
        [Fact]
        public void SimilarityForDifferentFiles_AllMethodsMustReturnZero_ReturnTrueForAllMethods()
        {
            var directory = "DifferentFiles";
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
            
            Assert.Equal(0.0, shingleMethodResult.First().Similarity, 2);
            Assert.Equal(0.0, levenshteinMethodResult.First().Similarity, 2);
            Assert.Equal(0.0, sorensenMethodResult.First().Similarity, 2);
            Assert.Equal(0.0, jaccardMethodResult.First().Similarity, 2);
            Assert.Equal(0.0, cosineMethodResult.First().Similarity, 2);
            Assert.Equal(0.0, nGramDistanceMethodResult.First().Similarity, 2);
            Assert.Equal(0.0, lcsMethodResult.First().Similarity, 2);
        }
        
        [Fact]
        public void SimilarityForIdenticalFiles_AllMethodsMustReturnOne_ReturnTrueForAllMethods()
        {
            var directory = "IdenticalFiles";
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
            
            Assert.Equal(1.0, shingleMethodResult.First().Similarity, 2);
            Assert.Equal(1.0, levenshteinMethodResult.First().Similarity, 2);
            Assert.Equal(1.0, sorensenMethodResult.First().Similarity, 2);
            Assert.Equal(1.0, jaccardMethodResult.First().Similarity, 2);
            Assert.Equal(1.0, cosineMethodResult.First().Similarity, 2);
            Assert.Equal(1.0, nGramDistanceMethodResult.First().Similarity, 2);
            Assert.Equal(1.0, lcsMethodResult.First().Similarity, 2);
        }

        [Fact]
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
            Assert.Equal(0.42, levenshteinMethodResult.First().Similarity, 2);
            Assert.Equal(0.66, sorensenMethodResult.First().Similarity, 2);
            Assert.Equal(0.49, jaccardMethodResult.First().Similarity, 2);
            Assert.Equal(0.8, cosineMethodResult.First().Similarity, 2);
            Assert.Equal(0.3, nGramDistanceMethodResult.First().Similarity, 2);
            Assert.Equal(0.39, lcsMethodResult.First().Similarity, 2);
        }
    }
}