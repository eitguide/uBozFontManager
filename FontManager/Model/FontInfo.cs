using FontManager.FontService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCSharpNghia;

namespace FontManager.Model
{
   public class FontInfo
    {
        public FontOwner Owner { get; set; }
        public string Copyright { get; set; }
        public string FontFamily { get; set; }
        public string FontSubFamily { get; set; }
        public string UniqueId { get; set; }
        public string FullName { get; set; }
        public string Version { get; set; }
        public string PostscriptName { get; set; }
        public string TradeMark { get; set; }
        public string Manufacturer { get; set; }
        public string Designer { get; set; }
        public string Description { get; set; }
        public string VendorURL { get; set; }
        public string DesignerURL { get; set; }
        public string License { get; set; }
        public string LicenseURL { get; set; }
        public string PreferredFamily { get; set; }
        public string PreferredSubFamily { get; set; }
        public string MacFullName { get; set; }
        public string StringLanguageSupported { get; set; }
        public string Location { get; set; }
        public int GlyphCount { get; set; }
        public string Platform { get; set; }
        public string VendorID { get; set; }
        public string NameInRegistry { get; set; }
        public string FileNameInRegistry { get; set; }
        public bool Disable { get; set; }
        public bool Loaded { get; set; }
        public List<Subset> Subsets { get; set; }
        public string SubsetString { get; set; }

        public FontInfo()
        {
            this.Loaded = false;
            Subsets = new List<Subset>(); 
        }
    }
}
