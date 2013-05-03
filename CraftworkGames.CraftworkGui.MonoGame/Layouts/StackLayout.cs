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
using Microsoft.Xna.Framework;


#endregion License

using System;
using System.Collections.Generic;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public enum Orientation
    {
        Horizontal, 
        Vertical
    }

    public class StackLayout : LayoutControl<Control>
    {
        public StackLayout()
        {
            Orientation = Orientation.Vertical;
        }

        public Orientation Orientation { get; set; }

        public override void PerformLayout()
        {
            int xOffset = 0;
            int yOffset = 0;
            int width = 0;
            int height = 0;

            foreach(var control in Items)
            {
                var controlSize = GetSize(control);
                Rectangle rectangle;

                if(Orientation == Orientation.Horizontal)
                {
                    width = xOffset + controlSize.Width;
                    height = controlSize.Height > height ? controlSize.Height : height;

                    rectangle = new Rectangle(X + xOffset, Y, controlSize.Width, height);
                }
                else
                {
                    width = controlSize.Width > width ? controlSize.Width : width;
                    height = yOffset + controlSize.Height;

                    rectangle = new Rectangle(X, Y + yOffset, width, controlSize.Height);
                }

                AlignControl(control, rectangle);

                xOffset += controlSize.Width;
                yOffset += controlSize.Height;
            }

            Width = width;
            Height = height;
        }

        protected override IEnumerable<Control> GetControls()
        {
            return Items;
        }
    }
}

