using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Audio;

namespace CraftworkGames.CraftworkGui.MonoGame
{
	public class Button : Control
	{
		public Button ()
		{
		}

        public Button (VisualStyle normalStyle)
        {
            NormalStyle = normalStyle;
        }

		public string Text { get; set; }
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

		private int _borderThickness = 4;
		private const float _repeatDelay = 0.18f;
		private float _remainingRepeatDelay = _repeatDelay;

        public override void Update (IUpdateManager updateManager, float deltaTime)
		{
			IsMouseOver = ContainsPoint(updateManager.X, updateManager.Y);
			
			if(IsMouseOver)
			{
				if(IsPressed)
				{
					if(!updateManager.IsInputPressed || (_remainingRepeatDelay <= 0 && IsRepeating))
					{
						_remainingRepeatDelay = _repeatDelay;
						Click();
					}

					if(IsRepeating)
						_remainingRepeatDelay -= deltaTime;
				}
				
                IsPressed = updateManager.IsInputPressed;
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

            // text
            if(!string.IsNullOrEmpty(Text))
            {
                drawManager.DrawText(Text, this, style);
            }
        }
	}
}

