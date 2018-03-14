using System;
using System.Drawing;

namespace BlockGameApp.Models
{
    public class Sprite : IDisposable
    {
        public Sprite(int x, int y, int width, int height) :
            this(x, y, width, height, Color.LightGray, Color.DarkGray)
        {

        }
        public Sprite(int x, int y, int width, int height, Color fill, Color outline, float outlineWidth = 2)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Pen = new Pen(outline, outlineWidth);
            Pen.Alignment = System.Drawing.Drawing2D.PenAlignment.Inset;
            Brush = new SolidBrush(fill);
        }

        public virtual void Draw(Graphics graphics)
        {
            graphics.FillRectangle(Brush, Rectangle);
            graphics.DrawRectangle(Pen, Rectangle);
        }
        public virtual void Dispose()
        {
            if (Brush != null)
                Brush.Dispose();

            if (Pen != null)
                Pen.Dispose();
        }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(X, Y, Width, Height);
            }
        }
        private Brush Brush { get; set; }
        private Pen Pen { get; set; }
    }
}
