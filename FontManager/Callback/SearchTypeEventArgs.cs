using FontManager.FontService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontManager.Callback
{

    public delegate void SearchtypeHandler(object sender, SearchTypeEventArgs e);
    public class SearchTypeEventArgs
    {
        public SearchType SearchType { get; set; }
        public SearchTypeEventArgs(SearchType type)
        {
            this.SearchType = type;
        }
    }
}
