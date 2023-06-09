﻿using System.Collections.Generic;
using System.Drawing.Text;

namespace CodePlagiarismDetection.Services
{
    public enum Fonts //Перечисление для определения необходимого шрифта из коллекции загружаемых шрифтов
    {
        MontserattRegular = 0,
        MontserattMedium = 1,
        MontserattThin = 2,
        Dinpro = 3,
    }
    
    //Класс подгрузки внешних шрифтов
    public class LocalFontsCollection
    {
        private static PrivateFontCollection _instance = null; //Экземпляр объекта для хранения загружаемых шрифтов

        private static readonly Dictionary<Fonts, string> _fonts //Словарь определения
            = new Dictionary<Fonts, string>()
            {
                {Fonts.MontserattRegular, @"Fonts\Montserrat-Regular.ttf"},
                {Fonts.MontserattMedium, @"Fonts\Montserrat-Medium.ttf"},
                {Fonts.MontserattThin, @"Fonts\Montserrat-Thin.ttf"},
                {Fonts.Dinpro, @"Fonts\Dinpro.otf"}
            };
        
        private LocalFontsCollection() { }

        public static PrivateFontCollection GetPrivateFontCollectionInstance()
        {
            return _instance ?? (_instance = CreatePrivateFontCollectionInstance());
        }
        
        //Создания списка внешних шрифтов
        private static PrivateFontCollection CreatePrivateFontCollectionInstance()
        {
            var privateFontCollection = new PrivateFontCollection();
            foreach (var font in _fonts)
                privateFontCollection.AddFontFile(font.Value);
            
            return privateFontCollection;
        }
    }
}