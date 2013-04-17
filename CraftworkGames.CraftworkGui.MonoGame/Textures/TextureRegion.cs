using System;
using System.Collections.Generic;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public interface ITextureRegion : IRectangle
    {
        string Name { get; }
    }

    internal class TextureRegion : ITextureRegion
    {
        public TextureRegion(TextureAtlas textureAtlas, string name, int x, int y, int width, int height)
        {
            TextureAtlas = textureAtlas;
            Name = name;
            X = x;
            Y = y;
            Width = width;
            Height = height;
        }

        public TextureAtlas TextureAtlas { get; set; }
        public string Name { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }
    
}
