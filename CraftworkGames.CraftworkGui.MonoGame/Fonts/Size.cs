using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CraftworkGames.CraftworkGui.MonoGame
{
	public struct Size
	{
		public Size(int width, int height)
			: this()
		{
			Width = width;
			Height = height;
		}

		public int Width { get; private set; }
		public int Height { get; private set; }
	}	
}
