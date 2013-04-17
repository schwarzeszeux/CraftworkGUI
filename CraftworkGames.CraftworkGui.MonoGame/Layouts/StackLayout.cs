using System;
using System.Collections.Generic;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public enum Orientation
    {
        Horizontal, 
        Vertical
    }

    public class StackLayout : LayoutControl
    {
        public StackLayout()
        {
            Controls = new List<Control>();
            Orientation = Orientation.Vertical;
        }

        public List<Control> Controls { get; private set; }
        public Orientation Orientation { get; set; }

        public override void PerformLayout()
        {
            int xOffset = 0;
            int yOffset = 0;

            foreach(var control in Controls)
            {
                if(Orientation == Orientation.Horizontal)
                {
                    control.X = X + xOffset;
                    control.Y = Y;
                }
                else
                {
                    control.X = X;
                    control.Y = Y + yOffset;
                }

                xOffset += control.Width;
                yOffset += control.Height;
            }
        }

        protected override IEnumerable<Control> GetControls()
        {
            return Controls;
        }
    }
}

