using FontManager.Utils;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FontManager.Board
{
    public class Board
    {
        private Pen pen;
        public int Column { get; set; }
        public int Row { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        public float ItemHeight { get; set; }
        public float ItemWidth { get; set; }

        public Board()
        {
            InitPaint();
        }

        private void InitPaint()
        {
            pen = new Pen(ColorHelper.ConvertToARGB("#ecf0f1"));
        }

        public void MeasureBoard(int width, int height, int column, int row)
        {
            this.Width = width;
            this.Height = height;
            this.Column = column;
            this.Row = row;

            this.ItemWidth = this.Width / (float)this.Column;
            this.ItemHeight = this.ItemWidth;
        }

      
        public void SetData(float width, float height, int column, int row)
        {
            this.Width = width;
            this.Height = height;
            this.Column = column;
            this.Row = row;

            this.ItemWidth = this.Width / (float)this.Column;
            this.ItemHeight = this.ItemWidth;
        }


        public Board(int column, int row, int width, int height)
        {
            InitPaint();
            this.Column = column;
            this.Row = row;
            this.Height = height;
            this.Width = width;

            this.Row = (int)this.Height / this.Column;

        }

        public void Draw(System.Drawing.Graphics canvas, Panel form)
        {

            //draw line column
            for (int i = 0; i <= Column; i++)
            {
                canvas.DrawLine(pen, new Point((int)(i * this.ItemWidth), 0), new Point((int)(i * this.ItemWidth), (int)(this.Row * this.ItemHeight)));
            }


            //draw line row
            for (int i = 0; i <= Row; i++)
            {
                canvas.DrawLine(pen, new Point(0, (int)(i * this.ItemWidth)), new Point((int)this.Width, (int)(i * this.ItemWidth)));
            }
        }


    }
}
