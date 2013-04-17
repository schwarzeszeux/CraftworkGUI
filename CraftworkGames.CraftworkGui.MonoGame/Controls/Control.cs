using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public abstract class Control : IUpdate, IDraw, IRectangle
	{
		public Control ()
		{
		}

		public int X { get; set; }
		public int Y { get; set; }
		public int Width { get; set; }
		public int Height { get; set; }

		public Rectangle DestinationRectangle
		{
			get
			{
				return new Rectangle(X, Y, Width, Height);
			}
		}
        		
        public abstract void Update(IUpdateManager updateManager, float deltaTime);
        public abstract void Draw(IDrawManager drawManager);

		public bool ContainsPoint (int x, int y)
		{
			var rectangle = new Rectangle(X, Y, Width, Height);
			return rectangle.Contains(x, y);
		}
	}
}

