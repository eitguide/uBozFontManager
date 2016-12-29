using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FontManager.FontService
{
    public class NameTableId
    {
        /*************************************************************************/
        /*                                                                       */
        /* Possible values of the `name' identifier field in the name records of */
        /* the TTF `name' table.  These values are platform independent.         */
        /*                                                                       */
        public const ushort TT_NAME_ID_COPYRIGHT = 0;
        public const ushort TT_NAME_ID_FONT_FAMILY = 1;
        public const ushort TT_NAME_ID_FONT_SUBFAMILY = 2;
        public const ushort TT_NAME_ID_UNIQUE_ID = 3;
        public const ushort TT_NAME_ID_FULL_NAME = 4;
        public const ushort TT_NAME_ID_VERSION_STRING = 5;
        public const ushort TT_NAME_ID_PS_NAME = 6;
        public const ushort TT_NAME_ID_TRADEMARK = 7;

        /* the following values are from the OpenType spec */
        public const ushort TT_NAME_ID_MANUFACTURER = 8;
        public const ushort TT_NAME_ID_DESIGNER = 9;
        public const ushort TT_NAME_ID_DESCRIPTION = 10;
        public const ushort TT_NAME_ID_VENDOR_URL = 11;
        public const ushort TT_NAME_ID_DESIGNER_URL = 12;
        public const ushort TT_NAME_ID_LICENSE = 13;
        public const ushort TT_NAME_ID_LICENSE_URL = 14;
        /* number 15 is reserved */
        public const ushort TT_NAME_ID_PREFERRED_FAMILY = 16;
        public const ushort TT_NAME_ID_PREFERRED_SUBFAMILY = 17;
        public const ushort TT_NAME_ID_MAC_FULL_NAME = 18;

        /* The following code is new as of 2000-01-21 */
        public const ushort TT_NAME_ID_SAMPLE_TEXT = 19;

        /* This is new in OpenType 1.3 */
        public const ushort TT_NAME_ID_CID_FINDFONT_NAME = 20;

        /* This is new in OpenType 1.5 */
        public const ushort TT_NAME_ID_WWS_FAMILY = 21;
        public const ushort TT_NAME_ID_WWS_SUBFAMILY = 22;
    }
}
