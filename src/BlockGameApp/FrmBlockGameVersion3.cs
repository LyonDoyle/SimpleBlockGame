using BlockGameApp.Models;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Threading;
using System.Windows.Forms;
using static BlockGameApp.GameTools;
using Timer = System.Windows.Forms.Timer;

namespace BlockGameApp
{
    public partial class FrmBlockGameVersion3 : Form
    {
        #region graphics objects

        Bitmap _background;
        Graphics _drawSurface;
        Graphics _displaySurface;
        Rectangle _screen = new Rectangle(0, 0, 800, 600);
        Font _gameFont = DefaultFont;

        bool _retroMode = false;

        #endregion graphics objects

        #region timing objects

        Timer _timer = new Timer();
        int _interval = 17;
        Stopwatch _stopwatch = new Stopwatch();
        long _lastTime;
        float _delta;
        bool _paused = false;

        #endregion timing objects

        #region colors/brushes/pens

        Color _playerFill = Color.DeepSkyBlue;
        Color _playerOutline = Color.CornflowerBlue;
        Color _goalFill = Color.LightGreen;
        Color _goalOutline = Color.DarkGreen;
        Color _enemyFill = Color.Tomato;
        Color _enemyOutline = Color.DarkRed;
        Color _starFill = Color.LightYellow;
        Color _starOutline = Color.SandyBrown;

        Brush _bgGradientBrush;

        #endregion colors/brushes/pens

        #region gaming objects

        Player _player;
        Sprite _goal;
        List<Npc> _enemies = new List<Npc>();
        List<Star> _starsForeground = new List<Star>();
        List<Star> _starsBackground = new List<Star>();
        Moon _moon = null;

        int _playerVelocity = 20;
        int _objectSize = 45;
        int _noOfEnemies = 3;
        int _noOfEnemiesIncrement = 2;
        const int _DEFAULT_NO_OF_ENEMIES = 3;
        int _noOfStars = 3;
        int _noOfStarsIncrement = 2;
        const int _DEFAULT_NO_OF_STARS = 3;

        int _score = 0;
        int _numberOfMoves = 0;
        bool _gameOver;
        #endregion gaming objects

        #region controls

        Direction _lastPressed;

        #endregion controls

        public FrmBlockGameVersion3()
        {
            InitializeComponent();

            Text = "Simple Block Game v2";
            SetClientSizeCore(_screen.Width, _screen.Height);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            _timer.Interval = _interval;

            _timer.Tick += (a, b) =>
            {
                CalculateDelta();
                UpdateGameObjects();
                CollisionDetection();
                if (_delta <= _interval)
                    Draw();
            };

            Shown += (a, b) =>
            {
                SetupGame();
            };

            KeyDown += (a, b) =>
            {
                if (b.KeyCode == Keys.Space)
                {
                    if (_paused)
                    {
                        _paused = false;
                        Start();
                    }
                    else
                    {
                        _paused = true;
                        Stop();
                    }
                    return;
                }

                switch (b.KeyCode)
                {
                    case Keys.Up:
                        {
                            if (_lastPressed == Direction.Up)
                                return;

                            _numberOfMoves++;
                            _lastPressed = Direction.Up;
                            break;
                        }
                    case Keys.Down:
                        {
                            if (_lastPressed == Direction.Down)
                                return;

                            _numberOfMoves++;
                            _lastPressed = Direction.Down;
                            break;
                        }
                    case Keys.Left:
                        {
                            if (_lastPressed == Direction.Left)
                                return;

                            _numberOfMoves++;
                            _lastPressed = Direction.Left;
                            break;
                        }
                    case Keys.Right:
                        {
                            if (_lastPressed == Direction.Right)
                                return;

                            _numberOfMoves++;
                            _lastPressed = Direction.Right;
                            break;
                        }
                    default:
                        {
                            _lastPressed = Direction.None;
                            break;
                        }
                }
            };

            KeyUp += (a, b) =>
            {
                _lastPressed = Direction.None;
            };

            FormClosing += (a, b) =>
            {
                _timer.Dispose();
                _drawSurface.Dispose();
                _background.Dispose();
                _displaySurface.Dispose();
            };
        }

        private void SetupGame()
        {
            #region graphics objects

            _background = new Bitmap(_screen.Width, _screen.Height);
            _drawSurface = Graphics.FromImage(_background);
            _drawSurface.Clip = new Region(_screen);
            _displaySurface = CreateGraphics();

            #endregion graphics objects

            #region brushes/pens

            _bgGradientBrush = new LinearGradientBrush(_screen, Color.Transparent, Color.FromArgb(60, Color.OrangeRed), 90f);

            #endregion brushes/pens

            #region game objects

            _player = new Player((int)((_screen.Width * .5) - (_objectSize * .5)), 0, _objectSize, _objectSize, _screen, _playerVelocity, _playerFill, _playerOutline);
            _goal = new Sprite(-5, _screen.Height - _objectSize, _screen.Width + 10, _objectSize + 10, _goalFill, _goalOutline);

            _enemies.Clear();

            Rectangle bounds = new Rectangle(0, _objectSize + 10, _screen.Width, _screen.Height - _objectSize);

            for (int i = 0; i < _noOfEnemies; i++)
            {
                int enemySize = GameTools.GetRandomNumber(15, 100);
                int randomStartX = GameTools.GetRandomNumber(bounds.X, bounds.Width - enemySize);
                int randomStartY = GameTools.GetRandomNumber(bounds.Y, bounds.Height - enemySize);
                int enemyVelocity = 400 / enemySize; // TODO: improve so as not to use division.

                Npc enemy = new Npc(randomStartX, randomStartY, enemySize, enemySize, bounds, enemyVelocity, _enemyFill, _enemyOutline);

                _enemies.Add(enemy);
            }

            _starsBackground.Clear();

            for (int i = 0; i < _noOfStars; i++)
            {
                int x = GameTools.GetRandomNumber(_screen.X, _screen.Width);
                int y = GameTools.GetRandomNumber(_screen.Y, _screen.Height);
                int width = GameTools.GetRandomNumber(1, 5);
                int height = width * 3;
                int velocity = GameTools.GetRandomNumber(3,5);

                _starsForeground.Add(new Star(x, y, width, height, _screen, velocity, Color.FromArgb(50, _starOutline), Color.FromArgb(50, _starFill)));
            }

            _starsForeground.Clear();

            for (int i = 0; i < _noOfStars; i++)
            {
                int x = GameTools.GetRandomNumber(_screen.X, _screen.Width);
                int y = GameTools.GetRandomNumber(_screen.Y, _screen.Height);
                int width = GameTools.GetRandomNumber(3, 7);
                int height = width * 5;
                int velocity = GameTools.GetRandomNumber(7, 14);

                _starsForeground.Add(new Star(x, y, width, height, _screen, velocity, Color.FromArgb(100, _starFill), Color.FromArgb(100, _starOutline)));
            }

            if (_moon == null)
                _moon = new Moon(_screen.X, _screen.Height, 175, 175, _screen, 3, Color.LightGoldenrodYellow, Color.NavajoWhite);

            #endregion game objects

            _lastPressed = Direction.None;
            _numberOfMoves = 0;

            // TODO: temp code
            _firstFrame = true;

            _stopwatch.Restart();
            _lastTime = _stopwatch.ElapsedMilliseconds;
            _timer.Enabled = true;

            // TODO: end temp code
        }
        bool _firstFrame;
        private void CalculateDelta()
        {
            long currentTime = _stopwatch.ElapsedMilliseconds;
            _delta = (currentTime - _lastTime) / 100f;
            _lastTime = currentTime;
        }
        private void UpdateGameObjects()
        {
            _player.Direction = _lastPressed;
            _player.Move(_delta);
            _enemies.ForEach(enemy => enemy.Move(_delta));
            _starsForeground.ForEach(star => star.Move(_delta));
            _starsBackground.ForEach(star => star.Move(_delta));
            _moon.Move(_delta);
        }
        private void Draw()
        {
            if (_gameOver)
                return;

            if (_retroMode)
            {
                //_drawSurface.Clear(SystemColors.Control);
                //_drawSurface.DrawRectangle(Pens.Red, _goal);
                //_enemies.ForEach(enemy => _drawSurface.DrawRectangle(Pens.Red, enemy.Rectangle));
                //_drawSurface.DrawRectangle(Pens.Blue, _player.Rectangle);
            }
            else
            {
                _drawSurface.Clear(Color.LightBlue);

                _starsBackground.ForEach(star => star.Draw(_drawSurface));
                _starsForeground.ForEach(star => star.Draw(_drawSurface));
                _moon.Draw(_drawSurface);

                _goal.Draw(_drawSurface);
                _enemies.ForEach(enemy => enemy.Draw(_drawSurface));
                _player.Draw(_drawSurface);

                _drawSurface.FillRectangle(_bgGradientBrush, _screen);
            }

            _drawSurface.DrawString(
                $"Score: {_score}\n" +
                $"Time: {_stopwatch.Elapsed.ToString("mm\\:ss\\.ff")}\n" +
                $"Moves: {_numberOfMoves}\n" +
                $"Enemies: {_noOfEnemies}", _gameFont, Brushes.Black, 10, 10);

            _displaySurface.DrawImage(_background, 0, 0);

            if (_firstFrame)
            {
                _firstFrame = false;
                Stop(true);
                Thread.Sleep(500);
                Start();
            }
        }
        private void CollisionDetection()
        {
            if (Rectangle.Intersect(_player.Rectangle, _goal.Rectangle) != Rectangle.Empty)
            {
                Stop(true);
                CalculateScore();
                _noOfEnemies += _noOfEnemiesIncrement;
                _noOfStars += _noOfStarsIncrement;
                SetupGame();
            }
            else
            {
                foreach (Npc enemy in _enemies)
                {
                    if (Rectangle.Intersect(_player.Rectangle, enemy.Rectangle) != Rectangle.Empty)
                    {
                        Stop(true);
                        if (MessageBox.Show($"Final score: {_score}\nNew game?", "Game over", MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            _score = 0;
                            _moon = null;
                            _noOfEnemies = _DEFAULT_NO_OF_ENEMIES;
                            _noOfStars = _DEFAULT_NO_OF_STARS;
                            SetupGame();
                        }
                        else
                        {
                            _gameOver = true;
                            Close();
                        }
                        break;
                    }
                }
            }
        }
        private void Stop(bool suppressPauseMessage = false)
        {
            _timer.Stop();
            _stopwatch.Stop();
            if (!suppressPauseMessage)
            {
                _drawSurface.DrawString("Paused", _gameFont, Brushes.Black, 10, 60);
                _displaySurface.DrawImage(_background, 0, 0);
            }
        }
        private void Start(bool stopwatchReset = false)
        {
            _timer.Start();

            if (stopwatchReset)
                _stopwatch.Restart();
            else
                _stopwatch.Start();
        }
        private void CalculateScore()
        {
            int enemyBonus = _noOfEnemies * 100;
            long timeBonus = 15000 - _stopwatch.ElapsedMilliseconds;
            int movesBonus = 10000 - _numberOfMoves * 100;

            _score += enemyBonus;

            if (timeBonus > 0)
                _score += (int)timeBonus;

            if (movesBonus > 0)
                _score += (int)movesBonus;
        }
    }
}