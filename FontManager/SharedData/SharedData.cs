using FontManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCSharpNghia;

namespace FontManager.SharedData
{
    public class SharedData
    {
        public static List<FontInfo> FontInfos { get; set; }
        public static List<Subset> Subsets { get; set; }
        public static bool IsSubsetsLoaded = false;
        public static bool DataChanged { get; set; }
    }
}
