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

