using System;
using Microsoft.Xna.Framework.Graphics;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public interface IDrawManager
    {
        void StartBatch();
        void EndBatch();
        void DrawTexture(string textureName, IRectangle destinationRectangle);
        void Draw(ISprite sprite, IRectangle destinationRectangle);
        void Draw(string textureRegionName, IRectangle destinationRectangle);
        void DrawText(string text, IRectangle destinationRectangle, ISprite style);
    }
}

