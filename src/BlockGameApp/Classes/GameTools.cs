using System;
using System.Diagnostics;
using System.Drawing;

namespace BlockGameApp
{
    public partial class GameTools
    {
        static Random _random;
        public static int GetRandomNumber(int lowestPossible, int highestPossible, bool zeroIsValid = false)
        {
            if (_random == null)
                _random = new Random();

            int temp = _random.Next(lowestPossible, highestPossible + 1);

            if (zeroIsValid)
                return temp;

            return temp == 0 ? GetRandomNumber(lowestPossible, highestPossible, zeroIsValid) : temp;
        }
        public static Color GetRandomColor()
        {
            int r = GetRandomNumber(0, 255);
            int g = GetRandomNumber(0, 255);
            int b = GetRandomNumber(0, 255);

            return Color.FromArgb(r, g, b);
        }
        public static Color GetRandomAlphaColor()
        {
            int a = GetRandomNumber(0, 255);
            int r = GetRandomNumber(0, 255);
            int g = GetRandomNumber(0, 255);
            int b = GetRandomNumber(0, 255);

            return Color.FromArgb(a, r, b, g);
        }
        public static Direction GetRandomDirection()
        {
            return (Direction)GetRandomNumber(0, 4, true);
        }
    }
}