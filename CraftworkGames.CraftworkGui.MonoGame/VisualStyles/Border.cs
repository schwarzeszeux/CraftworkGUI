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
	public class Border
	{
        public Border(int x, int y, int width, int height, int thickness)
		{
			var bw = thickness;
			var bh = thickness;
			var rx = width - bw;
			var by = height - bh;

			TopLeft = new Rectangle(x, y, bw, bh);
			TopRight = new Rectangle(x + rx, y, bw, bh);
			BottomLeft = new Rectangle(x, y + by, bw, bh);
			BottomRight = new Rectangle(x + rx, y + by, bw, bh);
            Left = new Rectangle(x, y + bh, bw, height - bh * 2);
            Right = new Rectangle(x + rx, y + bh, bw, height - bh * 2);
            Top = new Rectangle(x + bw, y, width - bw * 2, bh);
            Bottom = new Rectangle(x + bw, y + by, width - bw * 2, bh);
            Centre = new Rectangle(x + bw, y + bh, width - bw * 2, height - bh * 2);
		}

		public Border(IRectangle rectangle, int thickness)
			: this(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height, thickness)
		{
		}

		public Rectangle TopLeft { get; private set; }
		public Rectangle TopRight { get; private set; }
		public Rectangle BottomLeft { get; private set; }
		public Rectangle BottomRight { get; private set; }
		public Rectangle Left { get; private set; }
		public Rectangle Right { get; private set; }
		public Rectangle Top { get; private set; }
		public Rectangle Bottom { get; private set; }
		public Rectangle Centre { get; private set; }
	}
	
}
