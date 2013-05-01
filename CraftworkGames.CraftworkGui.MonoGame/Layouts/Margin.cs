using System;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public class Margin
    {
        public Margin(int all)
            : this(all, all, all, all)
        {
        }

        public Margin(int leftRight, int topBottom)
            : this(leftRight, topBottom, leftRight, topBottom)
        {
        }

        public Margin(int left, int top, int right, int bottom)
        {
            Left = left;
            Top = top;
            Right = right;
            Bottom = bottom;
        }

        public int Left { get; set; }
        public int Top { get; set; }
        public int Right { get; set; }
        public int Bottom { get; set; }
    }
}

