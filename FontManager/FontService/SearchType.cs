using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontManager.FontService
{
    public enum SearchType
    {
        All = 0,
        PostScript = 1,
        Family = 2,
        Style = 3,
        Copyright = 4,
        Language = 5,
        FileName = 6,
        Manufactuer = 7,
        Designer = 8,  
        Subset = 9,
    }
}
