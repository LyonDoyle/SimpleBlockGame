using BlockGameApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Windows.Forms;

namespace BlockGameApp
{
    public partial class frmBlockGameVersion2 : Form
    {
        //#region fields

        //readonly static int[][] _screenResolutions = { new[] { 600, 400 }, new[] { 800, 600 }, new[] { 1024, 768 }, new[] { 1680, 1024 } };
        //readonly int[] _defaultScreenResolution = _screenResolutions[0];
        //int[] _screenResolution = _screenResolutions[2];
        //Graphics _graphics;

        //GameState _gameState = GameState.Uninitialized;

        //Timer _timer;
        //Stopwatch _stopWatch;
        //long? _lastTime;
        //double _delta;

        //Keys _lastPressed = Keys.None;

        //frmSettings _settings;

        //const double GAMESPEED_SLOW = .5;
        //const double GAMESPEED_NORMAL = 1;
        //const double GAMESPEED_FAST = 1.5;
        //readonly double _DEFAULT_GAMESPEED = GAMESPEED_NORMAL;
        //double _gamespeed = GAMESPEED_NORMAL;

        //bool _defaultSoundEnabled = false;
        //bool _soundEnabled = false;

        //bool _defaultMusicEnabled = false;
        //bool _musicEnabled = false;

        //bool _retroMode = false;

        //Sprite _player;
        //readonly Color _defaultPlayerColor = Color.CornflowerBlue;
        //Color _playerColor = Color.CornflowerBlue;
        //SolidBrush _playerBrush;

        //Sprite _goal;
        //readonly Color _defaultGoalColor = Color.LightGreen;
        //Color _goalColor = Color.LightGreen;
        //SolidBrush _goalBrush;

        //List<Npc> _enemies = new List<Npc>();
        //readonly int _defaultNumberOfEnemies = 3;
        //int _numberOfEnemies = 3;
        //readonly Color _defaultEnemyColor = Color.Tomato;
        //Color _enemyColor = Color.Tomato;
        //SolidBrush _enemyBrush;

        //readonly Color _defaultBackgroundFillColor = Color.Cornsilk;
        //Color _backgroundFillColor = Color.Cornsilk;
        //readonly Color _defaultBackgroundAccentColor = Color.White;
        //Color _backgroundAccentColor = Color.White;

        //#endregion fields

        //#region constructor(s)
        //public frmBlockGameVersion2()
        //{
        //    InitializeComponent();

        //    this.Text = "Simple Block Game";
        //    this.SetClientSizeCore(_screenResolution[0], _screenResolution[1]);
        //    this.FormBorderStyle = FormBorderStyle.FixedToolWindow;
        //    this.Icon = new Icon("Images//Logo.ico");
        //    this.ShowIcon = true;
        //    this.DoubleBuffered = true;
        //    this.StartPosition = FormStartPosition.CenterParent;

        //    _graphics = this.CreateGraphics();
        //    //_graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy;
        //    //_graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
        //    //_graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
        //    //_graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
        //    //_graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;

        //    _timer = new Timer();
        //    _timer.Tick += timer_Tick;
        //    _timer.Interval = 10;

        //    _stopWatch = new Stopwatch();

        //    this.KeyDown += Form_OnKeyDown;
        //    this.KeyUp += Form_OnKeyUp;
        //    this.FormClosing += Form_OnFormClosing;
        //    this.Shown += FrmBlockGameVersion2_Shown;

        //    this.Menu = new MainMenu(new[] {
        //        new MenuItem("Game", new[] {
        //            new MenuItem("Reset", resetToolStripMenuItem_Click),
        //            new MenuItem("Restart", restartToolStripMenuItem_Click),
        //            new MenuItem("Exit", exitToolStripMenuItem_Click) }),
        //        new MenuItem("Settings", optionsToolStripMenuItem_Click) });
        //}
        //#endregion constructor(s)

        //#region events
        //private void FrmBlockGameVersion2_Shown(object sender, EventArgs e)
        //{
        //    initializeGame();
        //}
        //private void Form_OnFormClosing(object sender, FormClosingEventArgs e)
        //{
        //    if (_enemies != null)
        //        _enemies.ForEach(enemy => enemy.Dispose());
        //    _enemies = null;
        //    if (_graphics != null)
        //        _graphics.Dispose();
        //    if (_timer != null)
        //        _timer.Dispose();
        //    _stopWatch = null;
        //    if (_settings != null)
        //        _settings.Dispose();
        //    if (_playerBrush != null)
        //        _playerBrush.Dispose();
        //    if (_goalBrush != null)
        //        _goalBrush.Dispose();
        //    if (_enemyBrush != null)
        //        _enemyBrush.Dispose();
        //}
        //private void restartToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    _numberOfEnemies = _defaultNumberOfEnemies;
        //    initializeGame();
        //}
        //private void exitToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    this.Close();
        //}
        //private void resetToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    _retroMode = false;
        //    _playerBrush = new SolidBrush(_defaultPlayerColor);
        //    _goalBrush = new SolidBrush(_defaultGoalColor);
        //    _enemyBrush = new SolidBrush(_defaultEnemyColor);
        //    _backgroundFillColor = _defaultBackgroundFillColor;
        //    _backgroundAccentColor = _defaultBackgroundAccentColor;
        //    _gamespeed = _DEFAULT_GAMESPEED;
        //    //_gameSpeed = _settings.GameSpeed;
        //    //_screenResolution = _settings.ScreenResolution;
        //    _soundEnabled = _defaultSoundEnabled;
        //    _musicEnabled = _defaultMusicEnabled;

        //    //initializeGame();
        //}
        //private void optionsToolStripMenuItem_Click(object sender, EventArgs e)
        //{
        //    pause();

        //    if (_settings == null)
        //        _settings = new frmSettings();

        //    if (_settings.ShowDialog() == DialogResult.OK)
        //    {
        //        //_graphics.CompositingMode = System.Drawing.Drawing2D.CompositingMode.SourceCopy; // TODO:
        //        //_graphics.CompositingQuality = System.Drawing.Drawing2D.CompositingQuality.HighSpeed;
        //        //_graphics.PixelOffsetMode = System.Drawing.Drawing2D.PixelOffsetMode.HighSpeed;
        //        //_graphics.SmoothingMode = System.Drawing.Drawing2D.SmoothingMode.HighSpeed;
        //        //_graphics.InterpolationMode = System.Drawing.Drawing2D.InterpolationMode.Low;

        //        _retroMode = _settings.RetroMode;

        //        _playerColor = _settings.PlayerColor;
        //        _playerBrush = new SolidBrush(_settings.PlayerColor);

        //        _enemyColor = _settings.EnemyColor;
        //        _enemyBrush = new SolidBrush(_settings.EnemyColor);

        //        _goalColor = _settings.GoalColor;
        //        _goalBrush = new SolidBrush(_settings.GoalColor);

        //        _backgroundFillColor = _settings.BackgroundColor;

        //        //_gameSpeed = _settings.GameSpeed;

        //        //_screenResolution = _settings.ScreenResolution;

        //        _soundEnabled = _settings.SoundEnabled;

        //        _musicEnabled = _settings.MusicEnabled;
        //    }
        //    resume();
        //}
        //private void Form_OnKeyDown(object sender, KeyEventArgs e)
        //{
        //    if (e.KeyCode == Keys.Space)
        //    {
        //        if (_gameState == GameState.Stopped)
        //            resume();
        //        else if (_gameState == GameState.Running)
        //            pause();
        //    }
        //    else
        //        _lastPressed = e.KeyCode;
        //}
        //private void Form_OnKeyUp(object sender, KeyEventArgs e)
        //{
        //    _numberOfMoves++;
        //    _lastPressed = Keys.None;
        //}
        //private void timer_Tick(object sender, EventArgs e)
        //{
        //    if (_gameState != GameState.Running)
        //    {
        //        _timer.Enabled = false;
        //        return;
        //    }

        //    calculateDelta();
        //    getPlayerInput();
        //    update();
        //    draw();
        //    collisionDetection();
        //}
        //#endregion events

        //#region methods
        //private void calculateDelta()
        //{
        //    if (_lastTime == null)
        //        _lastTime = _stopWatch.ElapsedMilliseconds;

        //    long current = _stopWatch.ElapsedMilliseconds;
        //    _delta = (current - (long)_lastTime) / 100.0;
        //    _lastTime = current;
        //}
        //private void initializeGame()
        //{
        //    _lastPressed = Keys.None;

        //    int playerSize = 50;
        //    int playerVelocity = (int)(30 * _gamespeed);

        //    // goal should be at the bottom of the game area, but still visible.
        //    _goal = new Sprite(0, (int)_graphics.VisibleClipBounds.Height - playerSize, (int)_graphics.VisibleClipBounds.Width, playerSize);

        //    // player should start at the top-center of the game area.
        //    _player = new Sprite((_screenResolution[0] / 2) - (playerSize / 2), 0, playerSize, playerSize);
        //    _player.Velocity = playerVelocity;

        //    _enemies = new List<Npc>();
        //    Rectangle enemyBounds = new Rectangle(0, playerSize, _screenResolution[0], _screenResolution[1] - playerSize);

        //    for (int i = 0; i < _numberOfEnemies; i++)
        //    {
        //        int enemySize = GameTools.GetRandomNumber(5, 85);
        //        int enemyX = GameTools.GetRandomNumber(enemyBounds.X, enemyBounds.Width - enemySize);
        //        int enemyY = GameTools.GetRandomNumber(enemyBounds.Y, enemyBounds.Height);

        //        Npc enemy = new Npc(enemyX, enemyY, enemySize, enemySize, enemyBounds);

        //        int enemyVelocity = (int)(GameTools.GetRandomNumber(20, 30) * _gamespeed);
        //        enemy.Velocity = enemyVelocity;

        //        _enemies.Add(enemy);
        //    }

        //    _playerBrush = new SolidBrush(_playerColor);
        //    _goalBrush = new SolidBrush(_goalColor);
        //    _enemyBrush = new SolidBrush(_enemyColor);

        //    _lastTime = null;
        //    _stopWatch.Reset();

        //    resume();
        //}
        //private void update()
        //{
        //    _enemies.ForEach(enemy => enemy.Patrol(_delta));
        //}
        //private void draw()
        //{
        //    if (_retroMode)
        //    {
        //        _graphics.Clear(SystemColors.Control);
        //        _graphics.DrawRectangle(Pens.Red, _goal.Rectangle);
        //        _enemies.ForEach(enemy => _graphics.DrawRectangle(Pens.Red, enemy.Rectangle));
        //        _graphics.DrawRectangle(Pens.Blue, _player.Rectangle);
        //    }
        //    else
        //    {
        //        _graphics.Clear(_backgroundFillColor);
        //        _graphics.FillRectangle(_goalBrush, _goal.Rectangle);
        //        _enemies.ForEach(enemy => _graphics.FillRectangle(_enemyBrush, enemy.Rectangle));
        //        _graphics.FillRectangle(_playerBrush, _player.Rectangle);
        //    }
        //    _graphics.DrawString(
        //            $"Score: {_score}\n" +
        //            $"Time: {_stopWatch.Elapsed.ToString("ss\\.ff")}\n" +
        //            $"Moves: {_numberOfMoves}\n" +
        //            $"Enemies: {_numberOfEnemies}", DefaultFont, Brushes.Black, 10, 10);

        //    _graphics.Flush(System.Drawing.Drawing2D.FlushIntention.Sync); // prevents flicker
        //}
        //private void getPlayerInput()
        //{
        //    switch (_lastPressed)
        //    {
        //        case Keys.Up:
        //            {
        //                if (_player.Y > 0) // if the player will move out of bounds on their next move, do not move the player.
        //                    _player.Y -= (int)(_player.Velocity * _delta);

        //                break;
        //            }
        //        case Keys.Down:
        //            {
        //                if (_player.Y < (_screenResolution[1] - _player.Height))
        //                    _player.Y += (int)(_player.Velocity * _delta);

        //                break;
        //            }
        //        case Keys.Left:
        //            {
        //                if (_player.X > 0)
        //                    _player.X -= (int)(_player.Velocity * _delta);

        //                break;
        //            }
        //        case Keys.Right:
        //            {
        //                if (_player.X < (_screenResolution[0] - _player.Width))
        //                    _player.X += (int)(_player.Velocity * _delta);

        //                break;
        //            }
        //        default:
        //            break;
        //    }
        //}
        //private void collisionDetection()
        //{
        //    Rectangle player = new Rectangle(_player.X, _player.Y, _player.Width, _player.Height);
        //    Rectangle goal = new Rectangle(_goal.X, _goal.Y, _goal.Width, _goal.Height);

        //    bool exit = false;
        //    if (player.IntersectsWith(goal))
        //    {
        //        pause();
        //        calculateScore();
        //        MessageBox.Show($"You beat {_numberOfEnemies} enemies!\nClick OK to continue.", "Victory", MessageBoxButtons.OK);
        //        _numberOfEnemies += 2;
        //        initializeGame();
        //    }
        //    else
        //    {
        //        foreach (Npc enemy in _enemies)
        //        {
        //            Rectangle enemyRect = new Rectangle(enemy.X, enemy.Y, enemy.Width, enemy.Height);

        //            if (player.IntersectsWith(enemyRect) || enemyRect.IntersectsWith(player))
        //            {
        //                pause();

        //                if (MessageBox.Show($"Final score: {_score}\nNew game?", "Game over", MessageBoxButtons.YesNo) == DialogResult.Yes)
        //                {
        //                    _numberOfEnemies = _defaultNumberOfEnemies;
        //                    initializeGame();
        //                }
        //                else
        //                {
        //                    exit = true;
        //                    break;
        //                }
        //            }
        //        }
        //    }

        //    if (exit)
        //        this.Close();
        //}
        //private void pause()
        //{
        //    _gameState = GameState.Stopped;
        //    _graphics.DrawString("Paused", DefaultFont, Brushes.Black, 10, 60);
        //    _enemies.ForEach(enemy => enemy.Pause());
        //    _timer.Stop();
        //    _stopWatch.Stop();
        //}
        //private void resume()
        //{
        //    _gameState = GameState.Running;
        //    _enemies.ForEach(enemy => enemy.Resume());
        //    _stopWatch.Start();
        //    _timer.Start();
        //}

        //int _score = 0;
        //int _numberOfMoves = 1;
        //private void calculateScore()
        //{
        //    int enemyBonus = _numberOfEnemies * 100;
        //    long timeBonus = 15000 - _stopWatch.ElapsedMilliseconds;
        //    int movesBonus = 10000 - _numberOfMoves * 100;

        //    int score = enemyBonus + (int)(timeBonus > 0 ? timeBonus : 0) + (movesBonus > 0 ? movesBonus : 0);
        //    _score += (int)(score * _gamespeed);

        //    _numberOfMoves = 1;
        //}
        //#endregion methods
    }
}
