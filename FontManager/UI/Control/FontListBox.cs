using FontManager.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FontManager.UI.Control
{
    public partial class FontListBox: ListBox
    {
        public FontListBox()
        {
            this.DrawMode = DrawMode.OwnerDrawVariable;
        }

        protected override void OnDrawItem(DrawItemEventArgs e)
        {
            if(this.Items.Count > 0)
            {
                FontInfo info = this.Items[e.Index] as FontInfo;
                FontService.FontService.DrawFontItem(e, info, this);
            }
        }

        protected override void OnMeasureItem(MeasureItemEventArgs e)
        {
            //base.OnMeasureItem(e);
            e.ItemHeight = 200;
            Console.WriteLine("dfdahfjkdshfjkasdfdsf");
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
        }
    }

    partial class FontListBox
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
        }

        #endregion
    }


}
