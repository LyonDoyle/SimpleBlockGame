using System;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BlockGameApp.Models
{
    public class Trap : IDisposable
    {
        Timer _timer;
        Stopwatch _stopwatch;

        public Trap(int x, int y, int width, int height, long duration)
        {
            X = x;
            Y = y;
            Width = width;
            Height = height;
            Duration = duration;
            IsActive = true;
            _stopwatch = new Stopwatch();
            _timer = new Timer();
            _timer.Interval = 1000;
            _timer.Tick += (a, b) =>
            {
                if (_stopwatch.ElapsedMilliseconds >= duration)
                    IsActive = false;
            };

            _timer.Enabled = true;
            _stopwatch.Start();
        }

        public void Pause()
        {
            if (_timer != null)
                _timer.Stop();

            if (_stopwatch != null)
                _stopwatch.Stop();
        }
        public void Resume()
        {
            if (_timer != null)
                _timer.Start();

            if (_stopwatch != null)
                _stopwatch.Start();
        }
        public void Dispose()
        {
            if (_timer != null)
            {
                _timer.Enabled = false;
                _timer.Dispose();
            }
        }

        public Rectangle Rectangle
        {
            get
            {
                return new Rectangle(X, Y, Width, Height);
            }
        }
        public Point[] Points
        {
            get
            {
                // top-left, top-right, bottom-right, bottom-left
                return new[]
                {
                    new Point(this.X, this.Y),
                    new Point(this.X + this.Width, this.Y),
                    new Point(this.X + this.Width, this.Y + this.Height),
                    new Point(this.X, this.Y + this.Height)
                };
            }
        }
        /// <summary>
        /// Time this trap is active. 1000 = 1 sec
        /// </summary>
        public long Duration { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
        public bool IsActive { get; set; }
    }
}
