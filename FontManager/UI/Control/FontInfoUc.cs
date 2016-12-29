using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using SharpFont.PostScript.Internal;
using FontManager.Utils;

namespace FontManager.UI.Control
{
    public partial class FontInfoUc : UserControl
    {
        public FontInfoUc()
        {
            InitializeComponent();
        }

        public FontInfoUc(string titleName, string content)
        {           
            InitializeComponent();
            txtUcTitleName.Text = titleName;
            txtUcContent.Text = content;
            txtUcTitleName.ForeColor = ColorHelper.ConvertToARGB("#353535");
            //this.Dock = DockStyle.Fill;           
        }

        public void ContentChange(string content)
        {
            txtUcContent.Text = content;
        }
        private void FontInfoUc_Load(object sender, EventArgs e)
        {

        }
    }
}
