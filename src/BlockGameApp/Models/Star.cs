using System.Drawing;

namespace BlockGameApp.Models
{
    public class Star : Player
    {
        public Star(int x, int y, int width, int height, Rectangle bounds, int velocity) :
            this(x, y, width, height, bounds, velocity, Color.Empty, Color.Empty)
        { }
        public Star(int x, int y, int width, int height, Rectangle bounds, int velocity, Color fill, Color outline, int outlineWidth = 2) :
            base(x, y, width, height, bounds, velocity, fill, outline, outlineWidth)
        {

        }

        public override void Move(float delta)
        {
            int y = Y - (int)(Velocity * delta);

            if (y < Bounds.Y - Height)
            {
                X = GameTools.GetRandomNumber(Bounds.X, Bounds.Width);
                Y = Bounds.Height;
            }
            else
            {
                Y = y;
            }
        }
    }
}
