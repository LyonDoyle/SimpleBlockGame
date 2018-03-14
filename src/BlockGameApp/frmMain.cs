using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlockGameApp
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();

            this.Text = "Simple Block Game";
            this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
            this.BackgroundImage = Image.FromFile("Images\\Logo.png");
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.StartPosition = FormStartPosition.CenterScreen;

            btnOriginal.Click += BtnOriginal_Click;
            btnVersion2.Click += BtnVersion2_Click;
            btnExit.Click += BtnExit_Click;
            btnAbout.Click += BtnAbout_Click;       
        }

        private void BtnAbout_Click(object sender, EventArgs e)
        {
            using (frmAbout about = new frmAbout())
            {
                about.ShowDialog();
            }
        }
        private void BtnOriginal_Click(object sender, EventArgs e)
        {
            using (var classic = new frmBlockGameClassic())
            {
                classic.ShowDialog();
            }
        }
        private void BtnVersion2_Click(object sender, EventArgs e)
        {
            using (var v2 = new FrmBlockGameVersion3())
            {
                v2.ShowDialog();
            }
        }
        private void BtnExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
