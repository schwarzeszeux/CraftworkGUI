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

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public class ToggleButton : Button
    {
        public ToggleButton(VisualStyle normalStyle)
            : base(normalStyle)
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

