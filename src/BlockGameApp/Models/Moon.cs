using System.Drawing;

namespace BlockGameApp.Models
{
    public class Moon : Player
    {
        public Moon(int x, int y, int width, int height, Rectangle bounds, int velocity) :
            this(x, y, width, height, bounds, velocity, Color.Empty, Color.Empty)
        { }
        public Moon(int x, int y, int width, int height, Rectangle bounds, int velocity, Color fill, Color outline, int outlineWidth = 2) :
            base(x, y, width, height, bounds, velocity, fill, outline, outlineWidth)
        {
            _glowBrush = new SolidBrush(Color.FromArgb(20, fill));
        }

        Brush _glowBrush;
        Rectangle[] _arrGlowShapes = null;
        public Rectangle[] GlowShapes
        {
            get
            {
                if (_arrGlowShapes == null)
                {
                    _arrGlowShapes = new Rectangle[3];

                    int centerX = (int)(X + Width * .5);
                    int centerY = (int)(Y + Height * .5);

                    int shape1Width = (int)(Width + Width * .2);
                    int shape1Height = (int)(Height + Height * .2);
                    int shape1X = (int)(centerX - shape1Width * .5);
                    int shape1Y = (int)(centerY - shape1Height * .5);

                    _arrGlowShapes[0] = new Rectangle(shape1X, shape1Y, shape1Width, shape1Height);

                    int shape2Width = (int)(Width + Width * .4);
                    int shape2Height = (int)(Height + Height * .4);
                    int shape2X = (int)(centerX - shape2Width * .5);
                    int shape2Y = (int)(centerY - shape2Height * .5);

                    _arrGlowShapes[1] = new Rectangle(shape2X, shape2Y, shape2Width, shape2Height);

                    int shape3Width = (int)(Width + Width * .6);
                    int shape3Height = (int)(Height + Height * .6);
                    int shape3X = (int)(centerX - shape3Width * .5);
                    int shape3Y = (int)(centerY - shape3Height * .5);

                    _arrGlowShapes[2] = new Rectangle(shape3X, shape3Y, shape3Width, shape3Height);
                }

                return _arrGlowShapes;
            }
        }
        public override void Draw(Graphics graphics)
        {
            graphics.FillRectangle(_glowBrush, GlowShapes[0]);
            graphics.FillRectangle(_glowBrush, GlowShapes[1]);
            graphics.FillRectangle(_glowBrush, GlowShapes[2]);

            base.Draw(graphics);
        }

        public override void Move(float delta)
        {
            int y = Y;
            int x = X;

            y -= (int)(Velocity * delta);
            x += (int)((Velocity * delta) * .8);

            if (y + Height < Bounds.Y && x > Bounds.Width)
            {
                X = Bounds.X;
                Y = Bounds.Height;
            }
            else
            {
                X = x;
                Y = y;
            }

            int centerX = (int)(X + Width * .5);
            int centerY = (int)(Y + Height * .5);

            int shape1X = (int)(centerX - GlowShapes[0].Width * .5);
            int shape1Y = (int)(centerY - GlowShapes[0].Height * .5);

            GlowShapes[0].X = shape1X;
            GlowShapes[0].Y = shape1Y;

            int shape2X = (int)(centerX - GlowShapes[1].Width * .5);
            int shape2Y = (int)(centerY - GlowShapes[1].Height * .5);

            GlowShapes[1].X = shape2X;
            GlowShapes[1].Y = shape2Y;

            int shape3X = (int)(centerX - GlowShapes[2].Width * .5);
            int shape3Y = (int)(centerY - GlowShapes[2].Height * .5);

            GlowShapes[2].X = shape3X;
            GlowShapes[2].Y = shape3Y;
        }
    }
}
