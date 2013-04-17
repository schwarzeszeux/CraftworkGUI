using System;
using Microsoft.Xna.Framework;

namespace CraftworkGames.CraftworkGui.MonoGame
{
	public class StatusBar : Control
	{
		public StatusBar ()
		{
		}

        public override void Update(IUpdateManager updateManager, float deltaTime)
        {
            throw new NotImplementedException();
        }
        
        public override void Draw(IDrawManager drawManager)
        {
            throw new NotImplementedException();
        }

//		public override void Draw (SpriteBatch spriteBatch)
//		{
//			var destinationRectangle = new Rectangle(X, Y, Width, Height);
//			spriteBatch.Draw(Texture, destinationRectangle, SourceRectangle, Color.White);
//		}
	}
}

