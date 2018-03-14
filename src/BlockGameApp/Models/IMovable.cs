using System.Drawing;

namespace BlockGameApp.Models
{
    interface IMovable
    {
        Rectangle Bounds { get; set; }
        int Velocity { get; set; }
        void Move(float delta);
    }
}
