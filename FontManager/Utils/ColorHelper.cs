using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontManager.Utils
{
    class ColorHelper
    {
        public static Color ConvertToARGB(string hex)
        {
            ColorConverter colorConverter = new ColorConverter();
            return (Color)colorConverter.ConvertFromString(hex);
        }
    }
}
