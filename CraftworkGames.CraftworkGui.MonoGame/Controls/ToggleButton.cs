using System;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public class ToggleButton : Button
    {
        public ToggleButton()
        {
            Clicked += OnClicked;
        }

        public bool IsChecked { get; set; }
        public VisualStyle CheckedStyle { get; set; }

        private void OnClicked (object sender, EventArgs e)
        {
            IsChecked = !IsChecked;
        }

        protected override VisualStyle GetCurrentStyle()
        {
            var style = base.GetCurrentStyle();

            if(IsChecked)
            {
                if(CheckedStyle != null)
                    style = CheckedStyle;
                else
                    style = PressedStyle;
            }

            return style;
        }
    }
}

