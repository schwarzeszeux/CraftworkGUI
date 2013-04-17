using System;
using System.Collections.Generic;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CraftworkGames.CraftworkGui.MonoGame
{
	public class FontRenderer
	{
		public FontRenderer (FontFile fontFile, Texture2D fontTexture)
		{
			_fontFile = fontFile;
			_texture = fontTexture;
			_characterMap = new Dictionary<char, FontChar>();
			
			foreach(var fontCharacter in _fontFile.Chars)
			{
				char c = (char)fontCharacter.ID;
				_characterMap.Add(c, fontCharacter);
			}
		}

		private FontFile _fontFile;
		public FontFile FontFile
		{
			get
			{
				return _fontFile;
			}
		}

		private Dictionary<char, FontChar> _characterMap;

		private Texture2D _texture;
		public void DrawText(SpriteBatch spriteBatch, int x, int y, string text, Color colour)
		{
			int dx = x;
			int dy = y;
			foreach(char c in text)
			{
				FontChar fc;
				if(_characterMap.TryGetValue(c, out fc))
				{
					var sourceRectangle = new Rectangle(fc.X, fc.Y, fc.Width, fc.Height);
					var position = new Vector2(dx + fc.XOffset, dy + fc.YOffset);

                    spriteBatch.Draw(_texture, position, sourceRectangle, colour);
					dx += fc.XAdvance;
				}
			}
		}

		public Size MeasureText (string text)
		{
			int width = 0;
			int height = 0;
			foreach(char c in text)
			{
				FontChar fc;
				if(_characterMap.TryGetValue(c, out fc))
				{
					width += fc.XAdvance;

					if(fc.Height > height)
						height = fc.Height;
				}
			}

			return new Size(width, height);
		}
	}
}

