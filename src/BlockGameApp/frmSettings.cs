using System;
using System.Drawing;
using System.Windows.Forms;

namespace BlockGameApp
{
    public partial class frmSettings : Form
    {
        public frmSettings()
        {
            InitializeComponent();

            this.FormBorderStyle = FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.AcceptButton = btnSave;
            this.CancelButton = btnCancel;
            this.StartPosition = FormStartPosition.CenterParent;

            btnPlayerColor.Click += BtnPlayerColor_Click;
            btnEnemyColor.Click += BtnEnemyColor_Click;
            btnGoalColor.Click += BtnGoalColor_Click;
            btnBackgroundColor.Click += BtnBackgroundColor_Click;
            btnCancel.Click += BtnCancel_Click;
            btnSave.Click += BtnSave_Click;
            this.Shown += FrmSettings_Shown;
            chkRetroMode.CheckedChanged += (obj, e) =>
            {
                this.RetroMode = chkRetroMode.Checked;

                grpManualSettings.Enabled = !chkRetroMode.Checked;
            };
            this.Activated += FrmSettings_Activated;
        }

        private void FrmSettings_Activated(object sender, EventArgs e)
        {
            chkRetroMode.Checked = this.RetroMode;
            btnPlayerColor.BackColor = this.PlayerColor;
            btnEnemyColor.BackColor = this.EnemyColor;
            btnGoalColor.BackColor = this.GoalColor;
            btnBackgroundColor.BackColor = this.BackgroundColor;
        }
        private void FrmSettings_Shown(object sender, EventArgs e)
        {
            PreviousRetroMode = RetroMode;
            PreviousPlayerColor = PlayerColor;
            PreviousEnemyColor = EnemyColor;
            PreviousGoalColor = GoalColor;
            PreviousBackgroundColor = BackgroundColor;
            PreviousGameSpeed = GameSpeed;
            PreviousScreenResolution = ScreenResolution;
            PreviousSoundEnabled = SoundEnabled;
            PreviousMusicEnabled = MusicEnabled;
        }
        private void BtnSave_Click(object sender, EventArgs e)
        {
            PreviousRetroMode = RetroMode;
            PreviousPlayerColor = PlayerColor;
            PreviousEnemyColor = EnemyColor;
            PreviousGoalColor = GoalColor;
            PreviousBackgroundColor = BackgroundColor;
            PreviousGameSpeed = GameSpeed;
            PreviousScreenResolution = ScreenResolution;
            PreviousSoundEnabled = SoundEnabled;
            PreviousMusicEnabled = MusicEnabled;

            this.DialogResult = DialogResult.OK;
        }
        private void BtnCancel_Click(object sender, EventArgs e)
        {
            RetroMode = PreviousRetroMode;
            PlayerColor = PreviousPlayerColor;
            EnemyColor = PreviousEnemyColor;
            GoalColor = PreviousGoalColor;
            BackgroundColor = PreviousBackgroundColor;
            GameSpeed = PreviousGameSpeed;
            ScreenResolution = PreviousScreenResolution;
            SoundEnabled = PreviousSoundEnabled;
            MusicEnabled = PreviousMusicEnabled;

            chkRetroMode.Checked = RetroMode;
            btnPlayerColor.BackColor = PlayerColor;
            btnEnemyColor.BackColor = EnemyColor;
            btnGoalColor.BackColor = GoalColor;
            btnBackgroundColor.BackColor = BackgroundColor;
            // TODO: not yet implemented
            //GameSpeed = PreviousGameSpeed;
            //ScreenResolution = PreviousScreenResolution;
            //SoundEnabled = PreviousSoundEnabled;
            //MusicEnabled = PreviousMusicEnabled;

            this.DialogResult = DialogResult.Cancel;
        }
        private void BtnPlayerColor_Click(object sender, EventArgs e)
        {
            var colorPicker = new ColorDialog();
            if (colorPicker.ShowDialog() != DialogResult.OK)
                return;

            btnPlayerColor.BackColor = colorPicker.Color;
            this.PlayerColor = colorPicker.Color;
        }
        private void BtnEnemyColor_Click(object sender, EventArgs e)
        {
            var colorPicker = new ColorDialog();
            if (colorPicker.ShowDialog() != DialogResult.OK)
                return;

            btnEnemyColor.BackColor = colorPicker.Color;
            this.EnemyColor = colorPicker.Color;
        }
        private void BtnGoalColor_Click(object sender, EventArgs e)
        {
            var colorPicker = new ColorDialog();
            if (colorPicker.ShowDialog() != DialogResult.OK)
                return;

            btnGoalColor.BackColor = colorPicker.Color;
            this.GoalColor = colorPicker.Color;
        }
        private void BtnBackgroundColor_Click(object sender, EventArgs e)
        {
            var colorPicker = new ColorDialog();
            if (colorPicker.ShowDialog() != DialogResult.OK)
                return;

            btnBackgroundColor.BackColor = colorPicker.Color;
            this.BackgroundColor = colorPicker.Color;
        }

        public bool RetroMode { get; set; } = false;
        public Color PlayerColor { get; set; } = Color.CornflowerBlue;
        public Color EnemyColor { get; set; } = Color.Tomato;
        public Color GoalColor { get; set; } = Color.LightGreen;
        public Color BackgroundColor { get; set; } = Color.Cornsilk;
        public int GameSpeed { get; set; } = 1;
        public Size ScreenResolution { get; set; } = new Size(600, 400);
        public bool SoundEnabled { get; set; } = false;
        public bool MusicEnabled { get; set; } = false;

        public bool PreviousRetroMode { get; set; }
        public Color PreviousPlayerColor { get; set; } = Color.CornflowerBlue;
        public Color PreviousEnemyColor { get; set; } = Color.Tomato;
        public Color PreviousGoalColor { get; set; } = Color.LightGreen;
        public Color PreviousBackgroundColor { get; set; } = Color.Cornsilk;
        public int PreviousGameSpeed { get; set; } = 1;
        public Size PreviousScreenResolution { get; set; } = new Size(600, 400);
        public bool PreviousSoundEnabled { get; set; } = false;
        public bool PreviousMusicEnabled { get; set; } = false;
    }
}
