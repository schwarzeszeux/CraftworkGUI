using System;
using CraftworkGames.CraftworkGui.MonoGame;
using Microsoft.Xna.Framework;

namespace CraftworkGames.CraftworkGui
{
    public class Pawn : GridItem
    {
        public Pawn(ITextureRegion textureRegion, int row, int column, int direction)
            : base(CreateControl(textureRegion), row, column)
        {
            Direction = direction;
            var button = Control as Button;
            button.Clicked += HandleClicked;
        }

        public int Direction { get; private set; }

        private void HandleClicked (object sender, EventArgs e)
        {
            Column += Direction;
        }

        private static Control CreateControl(ITextureRegion textureRegion)
        {
            var button = new Button() 
            { 
                NormalStyle = new VisualStyle(textureRegion) { BackColour = Color.LightGray }, 
                HoverStyle = new VisualStyle(textureRegion) { BackColour = Color.White },
                Width = 64, 
                Height = 64 
            };
            return button;
        }
    }
}

