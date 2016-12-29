using FontManager.Model;
using SharpFont;
using SharpFont.TrueType;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontManager.Utils
{
    public class Logger
    {
        public static bool Debug = true;

        public static void FontInfomation(FontInfo info)
        {
            if (Debug)
            {
                Console.WriteLine("###Font Info###");

                Console.WriteLine(info.Copyright == null ? "NULL" : "CopyRight: " + info.Copyright);
                Console.WriteLine(info.FontFamily == null ? "NULL" : "FontFamily: " + info.FontFamily);
                Console.WriteLine(info.FontSubFamily == null ? "NULL" : "FontSubFamily: " + info.FontSubFamily);
                Console.WriteLine(info.UniqueId == null ? "NULL" : "UniqueId: " + info.UniqueId);
                Console.WriteLine(info.FullName == null ? "NULL" : "FullName: " + info.FullName);
                Console.WriteLine(info.Version == null ? "NULL" : "Version: " + info.Version);
                Console.WriteLine(info.PostscriptName == null ? "NULL" : "PostscriptName: " + info.PostscriptName);
                Console.WriteLine(info.TradeMark == null ? "NULL" : "TradeMark: " + info.TradeMark);

                Console.WriteLine(info.Manufacturer == null ? "NULL" : "Manufacturer: " + info.Manufacturer);
                Console.WriteLine(info.Designer == null ? "NULL" : "Designer: " + info.Designer);
                Console.WriteLine(info.Description == null ? "NULL" : "Description: " + info.Description);
                Console.WriteLine(info.VendorURL == null ? "NULL" : "Vender URL: " + info.VendorURL);
                Console.WriteLine(info.DesignerURL == null ? "NULL" : "Designer URL: " + info.DesignerURL);
                Console.WriteLine(info.License == null ? "NULL" : "License: " + info.License);
                Console.WriteLine(info.StringLanguageSupported == null ? "NULL" : "Language Supported: " + info.StringLanguageSupported);

                Console.WriteLine(info.PreferredFamily == null ? "NULL" : "Preperred Family: " + info.PreferredFamily);
                Console.WriteLine(info.PreferredSubFamily == null ? "NULL" : "Preperred SubFamily: " + info.PreferredSubFamily);
                Console.WriteLine(info.MacFullName == null ? "NULL" : info.MacFullName);
                Console.WriteLine(info.MacFullName == null ? "NULL" : info.MacFullName);

            }
        }


        public static void CodeIdsFont(Face face)
        {
            if (Debug)
            {
                int count = (int)face.GetSfntNameCount();
                for (int i = 0; i < count; i++)
                {
                    SfntName sfnt = face.GetSfntName((uint)i);
                    d("Platform: " + sfnt.PlatformId + ", Encoding ID: " + sfnt.EncodingId + "Language Id:  " + sfnt.LanguageId + ", NameId: " + sfnt.NameId);
                }
            }
        }

        public static void d(String str)
        {
            if (Debug)
                Console.WriteLine(str);
        }

        public static void d(int value)
        {
            if (Debug)
                Console.WriteLine(value);
        }
    }
}
