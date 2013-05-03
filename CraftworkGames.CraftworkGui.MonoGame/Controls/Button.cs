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
using Microsoft.Xna.Framework.Audio;

namespace CraftworkGames.CraftworkGui.MonoGame
{
	public class Button : TextControl
	{
        public Button (VisualStyle normalStyle)
            : base(normalStyle)
        {
            NormalStyle = normalStyle;
        }
        		
		public bool IsPressed {	get; set; }
		public bool IsMouseOver { get; set; }
		public bool IsRepeating { get; set; }
        public object Tag { get; set; }

        public VisualStyle NormalStyle { get; set; }
        public VisualStyle PressedStyle { get; set; }
        public VisualStyle HoverStyle { get; set; }

		public event EventHandler Clicked;
		
		public void Click ()
		{
			if(Clicked != null)
				Clicked(this, EventArgs.Empty);
		}
        		
		private const float _repeatDelay = 0.18f;
		private float _remainingRepeatDelay = _repeatDelay;

        public override void Update (IInputManager inputManager, float deltaTime)
		{
			IsMouseOver = ContainsPoint(inputManager.MousePosition);
			
			if(IsMouseOver)
			{
				if(IsPressed)
				{
					if(!inputManager.IsInputPressed || (_remainingRepeatDelay <= 0 && IsRepeating))
					{
						_remainingRepeatDelay = _repeatDelay;
						Click();
					}

					if(IsRepeating)
						_remainingRepeatDelay -= deltaTime;
				}
				
                IsPressed = inputManager.IsInputPressed;
			}
			else
			{
				IsPressed = false;
				_remainingRepeatDelay = _repeatDelay;
			}		
		}

        protected virtual VisualStyle GetCurrentStyle()
        {
            var style = NormalStyle;

            if (IsPressed && PressedStyle != null)
            {
                style = PressedStyle;
            }
            else if (IsMouseOver && HoverStyle != null)
            {
                style = HoverStyle;
            }

            return style;
        }

        public override void Draw(IDrawManager drawManager)
        {
            var style = GetCurrentStyle();
            style.Draw(drawManager, this);
            TextStyle.Draw(drawManager, Text, this);
        }
	}
}

