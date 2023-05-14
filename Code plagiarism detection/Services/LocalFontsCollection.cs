using System.Collections.Generic;
using System.Drawing.Text;

namespace CodePlagiarismDetection.Services
{
    public enum Fonts
    {
        MontserattRegular = 0,
        MontserattMedium = 1,
        MontserattThin = 2,
        Dinpro = 3,
    }
    
    public class LocalFontsCollection
    {
        private static PrivateFontCollection _instance = null;

        private static readonly Dictionary<Fonts, string> _fonts
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
        
        private static PrivateFontCollection CreatePrivateFontCollectionInstance()
        {
            var privateFontCollection = new PrivateFontCollection();
            foreach (var font in _fonts)
                privateFontCollection.AddFontFile(font.Value);
            
            return privateFontCollection;
        }
    }
}