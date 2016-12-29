using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontManager.FontService
{
    public enum  InstallError
    {
        //Install font suscessful
        INSTALL_SUSCESS = 0,

        //Font Already Installed
        INSTALL_DUPLICATE = 1,
    }
}
