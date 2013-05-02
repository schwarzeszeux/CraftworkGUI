using System;
using Microsoft.Xna.Framework;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public class TextStyle
    {
        public TextStyle()
        {
            Colour = Color.White;
            HorizontalAlignment = HorizontalAlignment.Centre;
            VerticalAlignment = VerticalAlignment.Centre;
        }

        public Color Colour { get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; }
        public VerticalAlignment VerticalAlignment { get; set; }

        public void Draw(IDrawManager drawManager, string text, IRectangle destinationRectangle)
        {
            if(!string.IsNullOrEmpty(text))
                drawManager.DrawText(text, destinationRectangle, this);
        }
    }
}

