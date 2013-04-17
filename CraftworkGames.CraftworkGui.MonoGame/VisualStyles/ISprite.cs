using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public interface ISprite
    {
        string TextureRegionName { get; }
        Color BackColour { get; }
        Color ForeColour { get; }
        float Rotation { get; }
        Vector2 Origin { get; }
        Vector2 Scale { get; }
        SpriteEffects Effect { get; }
        float Depth { get; set; }
    }
    
}
