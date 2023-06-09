﻿using System.Collections.Generic;
using System.IO;
using System.Linq;


namespace CodePlagiarismDetection.Services
{
    //Класс для загрузки файлов
    public class FileLoader
    {
        public static List<string> filter = new List<string>(); //Список фильтров обрабатываемых файлов
        
        //Метод для загрузки файлов из директории
        public static IEnumerable<string> LoadFiles(DirectoryInfo folder, SearchOption option)
        {
            if (filter.Count == 0)
                return folder.GetFiles("*.*", option)
                .Select(file => file.FullName);

            var fileList = Enumerable.Empty<string>();
            foreach (var pattern in filter)
            {
                fileList = fileList
                    .Concat(folder.GetFiles(pattern, option)
                    .Select(file => file.FullName));
            }
            return fileList;
        }
    }
}
