using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public class VisualStyle : ISprite
    {
        public VisualStyle()
            : this(null)
        {
        }

        public VisualStyle(string textureRegionName)
        {
            TextureRegionName  = textureRegionName;
            BackColour = Color.White;
            ForeColour = Color.White;
            Rotation = 0;
            Origin = Vector2.Zero;
            Scale = Vector2.One;
            Effect = SpriteEffects.None;
            Depth = 0;
        }

        public string TextureRegionName { get; set; }
        public Color BackColour { get; set; }
        public Color ForeColour { get; set; }
        public float Rotation { get; set; }
        public Vector2 Origin { get; set; }
        public Vector2 Scale { get; set; }
        public SpriteEffects Effect { get; set; }
        public float Depth { get; set; }

        public virtual void Draw(IDrawManager drawManager, IRectangle destinationRectangle)
        {
            drawManager.Draw(this, destinationRectangle);
        }
    }
}

