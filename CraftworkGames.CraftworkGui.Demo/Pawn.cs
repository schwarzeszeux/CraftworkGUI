using System;
using CraftworkGames.CraftworkGui.MonoGame;
using Microsoft.Xna.Framework;

namespace CraftworkGames.CraftworkGui
{
    public class Pawn : GridItem
    {
        public Pawn(string textureRegionName, int row, int column, int direction)
            : base(CreateControl(textureRegionName), row, column)
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

        private static Control CreateControl(string textureRegionName)
        {
            var button = new Button() 
            { 
                NormalStyle = new VisualStyle(textureRegionName) { BackColour = Color.LightGray }, 
                HoverStyle = new VisualStyle(textureRegionName) { BackColour = Color.White },
                Width = 64, 
                Height = 64 
            };
            return button;
        }
    }
}

