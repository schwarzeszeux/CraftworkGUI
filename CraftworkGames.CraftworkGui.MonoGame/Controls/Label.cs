using System;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;

namespace CraftworkGames.CraftworkGui.MonoGame
{
	public class Label : Control
	{
		public Label ()
		{
            Style = new VisualStyle();
		}

		public string Text { get; set; }
        public VisualStyle Style { get; set; }

        public override void Update(IUpdateManager updateManager, float deltaTime)
        {
        }

        public override void Draw(IDrawManager drawManager)
        {
            if(!string.IsNullOrEmpty(Text))
            {
                drawManager.DrawText(Text, this, Style);
            }
        }
	}
}

