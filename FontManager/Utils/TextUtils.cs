using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TestCSharpNghia;

namespace FontManager.Utils
{
    public class TextUtils
    {
        public static string GetLanguageFromConstant(string str)
        {
            if (str.Length < Config.LanguagePrefix.Length)
                return string.Empty;

            String subString = str.Remove(0, Config.LanguagePrefix.Length).Replace('_', ' ').ToLower();
            return Regex.Replace(subString, @"\b(\w)", m => m.Value.ToUpper());
    
        }

        public static string DecodeFontValue(string fileName)
        {
            return Regex.Replace(fileName, @"-", "");
        }

        public static string GetSubsetFontText(List<Subset> subset)
        {
            StringBuilder builder = new StringBuilder();
            for (int i = 0; i < subset.Count; i++)
            {
                builder.Append(subset[i].name + ", ");
            }

            return builder.ToString();
        }
    }
}
