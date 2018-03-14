using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlockGameApp.Models
{
    public partial class Npc : Player
    {
        Timer _timer = new Timer();

        public Npc(int x, int y, int width, int height, Rectangle bounds, int velocity)
            : this(x, y, width, height, bounds, velocity, Color.Empty, Color.Empty)
        {

        }
        public Npc(int x, int y, int width, int height, Rectangle bounds, int velocity, Color fill, Color outline, int outlineWidth = 2) :
            base(x, y, width, height, bounds, velocity, fill, outline, outlineWidth)
        {
            _timer.Interval = GameTools.GetRandomNumber((int)(1000 * .25), (int)(1000 * .5));
            _timer.Tick += Timer_Tick;
            IsRunning = true;
            _timer.Enabled = true;
        }

        private void Timer_Tick(object sender, EventArgs e)
        {
            Direction = GameTools.GetRandomDirection();
        }

        public void Stop()
        {
            _timer.Stop();
            IsRunning = false;
        }
        public void Start()
        {
            _timer.Start();
            IsRunning = true;
        }
        public override void Dispose()
        {
            _timer.Dispose();
            base.Dispose();
        }

        public bool IsRunning { get; set; }
    }
}