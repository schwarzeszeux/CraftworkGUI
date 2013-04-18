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
using System.Linq;
using System.Collections.Generic;
using Microsoft.Xna.Framework;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public enum DockStyle
    {
        Left,
        Top,
        Right,
        Bottom, 
        Fill
    }

    public class DockItem
    {
        public DockItem(Control control, DockStyle dockStyle)
        {
            Control = control;
            DockStyle = dockStyle;
        }

        public DockStyle DockStyle { get; set; }
        public Control Control { get; private set; }
    }

    public class DockLayout : LayoutControl
    {
        public DockLayout()
        {
            Controls = new List<DockItem>();
        }

        public List<DockItem> Controls { get; private set; }

        public override void PerformLayout()
        {
            var rectangle = new Rectangle(X, Y, Width, Height);

            foreach(var dockItem in Controls.Where(c => c.DockStyle != DockStyle.Fill))
            {
                var control = dockItem.Control;

                switch(dockItem.DockStyle)
                {
                    case DockStyle.Left:
                        control.X = rectangle.X;
                        control.Y = rectangle.Y;
                        control.Height = rectangle.Height;
                        rectangle.X += control.Width;
                        rectangle.Width -= control.Width;
                        break;
                    case DockStyle.Right:
                        control.X = rectangle.X + rectangle.Width - control.Width;
                        control.Y = rectangle.Y;
                        control.Height = rectangle.Height;
                        rectangle.Width -= control.Width;
                        break;
                    case DockStyle.Top:
                        control.X = rectangle.X;
                        control.Y = rectangle.Y;
                        control.Width = rectangle.Width;
                        rectangle.Y += control.Height;
                        rectangle.Height -= control.Height;
                        break;
                    case DockStyle.Bottom:
                        control.X = rectangle.X;
                        control.Y = rectangle.Y + rectangle.Height - control.Height;
                        control.Width = rectangle.Width;
                        rectangle.Height -= control.Height;
                        break;
                }
            }

            foreach(var dockItem in Controls.Where(c => c.DockStyle == DockStyle.Fill))
            {
                var control = dockItem.Control;
                control.X = rectangle.X;
                control.Y = rectangle.Y;
                control.Width = rectangle.Width;
                control.Height = rectangle.Height;
            }
        }

        protected override IEnumerable<Control> GetControls()
        {
            return Controls.Select(i => i.Control);
        }
    }
}

