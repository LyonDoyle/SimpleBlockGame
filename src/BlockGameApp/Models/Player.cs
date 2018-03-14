using System;
using System.Drawing;
using static BlockGameApp.GameTools;

namespace BlockGameApp.Models
{
    public class Player : Sprite, IMovable
    {
        public Player(int x, int y, int width, int height, Rectangle bounds, int velocity) : this(x, y, width, height, bounds, velocity, Color.Empty, Color.Empty)
        {

        }
        public Player(int x, int y, int width, int height, Rectangle bounds, int velocity, Color fill, Color outline, int outlineWidth = 2) :
            base(x, y, width, height, fill, outline, outlineWidth)
        {
            Bounds = bounds;
            Velocity = velocity;
        }

        public virtual void Move(float delta)
        {
            if (Direction == Direction.None)
                return;

            int x = X;
            int y = Y;

            switch (Direction)
            {
                case Direction.Up:
                    {
                        y = (int)(y - Velocity * delta);
                        break;
                    }
                case Direction.Down:
                    {
                        y = (int)(y + Velocity * delta);
                        break;
                    }
                case Direction.Left:
                    {
                        x = (int)(x - Velocity * delta);
                        break;
                    }
                case Direction.Right:
                    {
                        x = (int)(x + Velocity * delta);
                        break;
                    }
                default:
                    break;
            }

            if (x < Bounds.X || x > Bounds.Width - Width)
                x = X;

            if (y < Bounds.Y || y > Bounds.Height - Height)
                y = Y;

            X = x;
            Y = y;
        }
        public Direction Direction { get; set; } = Direction.None;
        public Rectangle Bounds { get; set; }
        public int Velocity { get; set; }
    }
}
