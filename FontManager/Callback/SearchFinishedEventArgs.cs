using FontManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontManager.Callback
{

   public delegate void SearchFinishedHandler(object sender, SearchFinishedEventArgs e);

   public class SearchFinishedEventArgs
    {
        public List<FontInfo> SearchResult { get;  set;}
        public SearchFinishedEventArgs(List<FontInfo> result)
        {
            this.SearchResult = result;
        }
    }
}
