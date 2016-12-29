using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontManager.Callback
{

    public delegate void SearchFailedHandler(object sender, SearchFailedEventArgs e);
    public class SearchFailedEventArgs
    {
        public string Message { get; set; }

        public SearchFailedEventArgs(string message)
        {
            this.Message = message;
        }
    }
}
