using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace CraftworkGames.CraftworkGui.MonoGame
{
	public class Border
	{
		public Border(Rectangle rectangle, int thickness, int x, int y)
		{
			var bw = thickness;
			var bh = thickness;
			var rx = rectangle.Width - bw;
			var by = rectangle.Height - bh;

			TopLeft = new Rectangle(x, y, bw, bh);
			TopRight = new Rectangle(x + rx, y, bw, bh);
			BottomLeft = new Rectangle(x, y + by, bw, bh);
			BottomRight = new Rectangle(x + rx, y + by, bw, bh);
			Left = new Rectangle(x, y + bh, bw, rectangle.Height - bh * 2);
			Right = new Rectangle(x + rx, y + bh, bw, rectangle.Height - bh * 2);
			Top = new Rectangle(x + bw, y, rectangle.Width - bw * 2, bh);
			Bottom = new Rectangle(x + bw, y + by, rectangle.Width - bw * 2, bh);
			Centre = new Rectangle(x + bw, y + bh, rectangle.Width - bw * 2, rectangle.Height - bh * 2);
		}

		public Border(Rectangle rectangle, int thickness)
			: this(rectangle, thickness, rectangle.X, rectangle.Y)
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
