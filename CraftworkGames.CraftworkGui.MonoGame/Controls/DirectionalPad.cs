using System;
using Microsoft.Xna.Framework;

namespace CraftworkGames.CraftworkGui.MonoGame
{
	public class DirectionalPad : Control
	{
		public DirectionalPad ()
		{
		}

		public Vector2 Direction { get; private set; }

		public event EventHandler Pressed;

        #region implemented abstract members of Control

        public override void Update(IUpdateManager updateManager, float deltaTime)
        {
            throw new NotImplementedException();
        }

        public override void Draw(IDrawManager drawManager)
        {
            throw new NotImplementedException();
        }

        #endregion

//		public override void Update (float deltaTime, int x, int y, bool isInputPressed)
//		{
//			// add a little fudge factor to the collision rectangle
//			// to make the controls feel more responsive
//			int fudge = 32;
//			var collisionRectangle = new Rectangle (DestinationRectangle.X - fudge, DestinationRectangle.Y - fudge, 
//			                                        DestinationRectangle.Width + fudge * 2, DestinationRectangle.Height + fudge * 2);
//			if(isInputPressed && collisionRectangle.Contains(x, y))
//			{
//				var centre = DestinationRectangle.Center;
//				float dx = (float)(x - centre.X) / (float)collisionRectangle.Width / 2.0f;
//				float dy = (float)(y - centre.Y) / (float)collisionRectangle.Height / 2.0f;
//				Direction = new Vector2(dx, dy);
//
//				if(Pressed != null)
//					Pressed(this, EventArgs.Empty);
//			}
//			else
//			{
//				Direction = Vector2.Zero;
//			}
//		}
//
//		public override void Draw (Microsoft.Xna.Framework.Graphics.SpriteBatch spriteBatch)
//		{
//			spriteBatch.Draw(Texture, DestinationRectangle, SourceRectangle, Color.White);
//		}
	}
}

