using FontManager.Model;
using FontManager.Utils;
using SharpFont;
using SharpFont.TrueType;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TestCSharpNghia;

namespace FontManager.FontService
{
    public class FontReading
    {
        private Library lib;

        public FontReading()
        {
            lib = new Library();
        }

        public FontInfo ReadingFontInfo(String filePath, ref FontInfo fontInfo)
        {
            if (string.IsNullOrEmpty(filePath))
                return null;

            try
            {
                Face face = new Face(this.lib, filePath);

                //Logger.CodeIdsFont(face);
                if (face == null)
                    return null;

                fontInfo.Location = filePath;
                fontInfo.FontFamily = face.FamilyName;
                fontInfo.FontSubFamily = face.StyleName;
                fontInfo.PostscriptName = face.GetPostscriptName();
                fontInfo.FullName = Path.GetFileName(fontInfo.Location);

                fontInfo.GlyphCount = face.GlyphCount;

                //Find subset of a font
                if (SharedData.SharedData.IsSubsetsLoaded)
                {
                    if (fontInfo.Subsets.Count == 0)
                    {
                        for (int i = 0; i < SharedData.SharedData.Subsets.Count; i++)
                        {
                            Subset item = SharedData.SharedData.Subsets[i];
                            int start = int.Parse(item.start, System.Globalization.NumberStyles.HexNumber);
                            int end = int.Parse(item.end, System.Globalization.NumberStyles.HexNumber);

                            for (int index = start; index <= end; index++)
                            {
                                if (face.GetCharIndex((uint)index) != 0)
                                {
                                    fontInfo.Subsets.Add(item);
                                    break;
                                }
                            }
                        }
                    }
                }

                if(fontInfo.Subsets.Count != 0)
                {
                    fontInfo.SubsetString = String.Join(", ", fontInfo.Subsets.Select(x => x.name));
                }

              
                StringBuilder stringBuilder = new StringBuilder();
                for (int i = 0; i < face.CharmapsCount; i++)
                {
                    stringBuilder.Append(face.CharMaps[i].PlatformId);

                    if (i != face.CharmapsCount - 1)
                    {
                        stringBuilder.Append(", ");
                    }
                }

                fontInfo.Platform = stringBuilder.ToString();

                OS2 os2 = face.GetSfntTable(SfntTag.OS2) as OS2;
                if (os2 != null)
                    fontInfo.VendorID = System.Text.Encoding.UTF8.GetString(os2.VendorId);
                else
                    fontInfo.VendorID = null;

                int count = (int)face.GetSfntNameCount();
                int curentNameIndex = -1;
                // Utils.Logger.CodeIdsFont(face);
                //fontInfo.LanguageSupported = GetLanguageSupport(face);
                //fontInfo.StringLanguageSupported = string.Join(", ", fontInfo.LanguageSupported.ToArray());


                #region Read Font Info
                StringBuilder languageBuilder = new StringBuilder();

                int currentLanguageId = -1;
                for (int i = 0; i < count; i++)
                {
                    SfntName sfnt = face.GetSfntName((uint)i);

                    if (sfnt.PlatformId == PlatformId.Microsoft && currentLanguageId != sfnt.LanguageId)
                    {
                        currentLanguageId = sfnt.LanguageId;
                        LanguageMapping mapping = (LanguageMapping)sfnt.LanguageId;
                        String lang = TextUtils.GetLanguageFromConstant(mapping.ToString());
                        if (lang != string.Empty)
                        {
                            languageBuilder.Append(lang + ", ");
                        }
                    }

                    if (sfnt.PlatformId == PlatformId.Macintosh)
                    {
                        

                        if (sfnt.NameId < curentNameIndex)
                            break;

                        curentNameIndex++;
                        switch (sfnt.NameId)
                        {
                            case NameTableId.TT_NAME_ID_COPYRIGHT:
                                fontInfo.Copyright = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_FONT_FAMILY:
                                fontInfo.FontFamily = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_FONT_SUBFAMILY:
                                fontInfo.FontSubFamily = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_UNIQUE_ID:
                                fontInfo.UniqueId = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_FULL_NAME:
                                fontInfo.FullName = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_VERSION_STRING:
                                fontInfo.Version = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_PS_NAME:
                                fontInfo.PostscriptName = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_TRADEMARK:
                                fontInfo.TradeMark = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_MANUFACTURER:
                                fontInfo.Manufacturer = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_DESIGNER:
                                fontInfo.Designer = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_DESCRIPTION:
                                fontInfo.Description = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_VENDOR_URL:
                                fontInfo.VendorURL = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_DESIGNER_URL:
                                fontInfo.DesignerURL = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_LICENSE:
                                fontInfo.License = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_LICENSE_URL:
                                fontInfo.LicenseURL = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_PREFERRED_FAMILY:
                                fontInfo.PreferredFamily = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_PREFERRED_SUBFAMILY:
                                fontInfo.PreferredSubFamily = sfnt.StringAnsi;
                                break;
                            case NameTableId.TT_NAME_ID_MAC_FULL_NAME:
                                fontInfo.MacFullName = sfnt.StringAnsi;
                                break;
                            default:
                                break;
                        }
                    }
                }

                #endregion

               //languageBuilder.Remove(languageBuilder.Length - 1, 1);
               fontInfo.StringLanguageSupported = languageBuilder.ToString();

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

            return fontInfo;
        }


        public List<string> GetLanguageSupport(Face face)
        {
            List<string> listLangSupported = new List<string>();
            int count = (int)face.GetSfntNameCount();

            int currentLanguageId = -1;
            for (int i = 0; i < count; i++)
            {
                SfntName sfnt = face.GetSfntName((uint)i);

                if (sfnt.PlatformId == PlatformId.Microsoft && currentLanguageId != sfnt.LanguageId)
                {
                    currentLanguageId = sfnt.LanguageId;
                    LanguageMapping mapping = (LanguageMapping)sfnt.LanguageId;
                    String lang = TextUtils.GetLanguageFromConstant(mapping.ToString());
                    if (lang != string.Empty)
                    {
                        listLangSupported.Add(lang);
                    }
                }
            }

            return listLangSupported;

        }
    }
}
