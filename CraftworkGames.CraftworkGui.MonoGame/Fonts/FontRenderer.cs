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

