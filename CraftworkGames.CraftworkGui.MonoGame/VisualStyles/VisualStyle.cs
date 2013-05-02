#region License
/*
MIT License
Copyright © 2013 Craftwork Games

All rights reserved.

Authors:
Dylan Wilson

Permission is hereby granted, free of charge, to any person obtaining a copy
of this software and associated documentation files (the "Software"), to deal
in the Software without restriction, including without limitation the rights
to use, copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the Software is
furnished to do so, subject to the following conditions:

The above copyright notice and this permission notice shall be included in all
copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR
IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY,
FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE
AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER
LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM,
OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE
SOFTWARE.
*/
#endregion License

using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public class VisualStyle : IGuiSprite
    {
        public VisualStyle(ITextureRegion textureRegion)
        {
            TextureRegion  = textureRegion;
            Colour = Color.White;
            Rotation = 0;
            Origin = Vector2.Zero;
            Scale = Vector2.One;
            Effect = SpriteEffects.None;
            Depth = 0;
        }

        public ITextureRegion TextureRegion { get; set; }
        public Color Colour { get; set; }
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

