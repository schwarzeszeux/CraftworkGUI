using System;
using Microsoft.Xna.Framework.Graphics;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public interface IRectangle
    {
        int X { get; }
        int Y { get; }
        int Width { get; }
        int Height { get; }
    }

    public static class IRectangleExtensions
    {
        public static bool ContainsPoint(this IRectangle rectangle, int x, int y)
        {
            if(x < rectangle.X || x > rectangle.X + rectangle.Width)
                return false;

            if(y < rectangle.Y || y > rectangle.Y + rectangle.Height)
                return false;

            return true;
        }
    }
}
