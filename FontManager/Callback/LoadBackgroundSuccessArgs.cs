using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontManager.Callback
{
   public delegate void LoadBackgroundSuccessHandler(object sender, LoadBackgroundSuccessArgs e);
   public class LoadBackgroundSuccessArgs
    {
        public LoadBackgroundSuccessArgs()
        {

        }
    }
}
