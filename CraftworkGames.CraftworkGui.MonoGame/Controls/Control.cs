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
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public abstract class Control : IUpdate, IDraw, IRectangle
	{
		public Control(VisualStyle defaultStyle)
		{
            HorizontalAlignment = HorizontalAlignment.Centre;
            VerticalAlignment = VerticalAlignment.Centre;

            if(defaultStyle != null && defaultStyle.TextureRegion != null)
            {
                Width = defaultStyle.TextureRegion.Width;
                Height = defaultStyle.TextureRegion.Height;
            }

            Margin = new Margin(4);
		}

		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }
        public Margin Margin { get; set; }
        public HorizontalAlignment HorizontalAlignment { get; set; }
        public VerticalAlignment VerticalAlignment { get; set; }

		public Rectangle DestinationRectangle
		{
			get
			{
				return new Rectangle(X, Y, Width, Height);
			}
		}
        		
        public abstract void Update(IInputManager inputManager, float deltaTime);
        public abstract void Draw(IDrawManager drawManager);

        public bool ContainsPoint(Point point)
        {
            return ContainsPoint(point.X, point.Y);
        }

		public bool ContainsPoint (int x, int y)
		{
			var rectangle = new Rectangle(X, Y, Width, Height);
			return rectangle.Contains(x, y);
		}
	}
}

