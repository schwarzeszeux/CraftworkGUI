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
    public class DockLayout : LayoutControl<DockItem>
    {
        public DockLayout()
        {
        }

        public override void PerformLayout()
        {
            var dockArea = new Rectangle(X, Y, Width, Height);

            foreach(var dockItem in Items.Where(c => c.DockStyle != DockStyle.Fill))
            {
                var control = dockItem.Control;
                var controlSize = GetSize(control);

                switch(dockItem.DockStyle)
                {
                    case DockStyle.Left:
                        AlignControl(control, new Rectangle(dockArea.X, dockArea.Y, controlSize.Width, dockArea.Height));
                        dockArea.X += controlSize.Width;
                        dockArea.Width -= controlSize.Width;
                        break;
                    case DockStyle.Right:
                        AlignControl(control, new Rectangle(dockArea.X + dockArea.Width - controlSize.Width, dockArea.Y, controlSize.Width, dockArea.Height));
                        dockArea.Width -= controlSize.Width;
                        break;
                    case DockStyle.Top:
                        AlignControl(control, new Rectangle(dockArea.X, dockArea.Y, dockArea.Width, controlSize.Height));
                        dockArea.Y += controlSize.Height;
                        dockArea.Height -= controlSize.Height;
                        break;
                    case DockStyle.Bottom:
                        AlignControl(control, new Rectangle(dockArea.X, dockArea.Y + dockArea.Height - controlSize.Height, dockArea.Width, controlSize.Height));
                        dockArea.Height -= controlSize.Height;
                        break;
                }
            }

            foreach(var dockItem in Items.Where(c => c.DockStyle == DockStyle.Fill))
            {
                var control = dockItem.Control;
                AlignControl(control, new Rectangle(dockArea.X, dockArea.Y, dockArea.Width, dockArea.Height));
            }
        }

        protected override IEnumerable<Control> GetControls()
        {
            return Items.Select(i => i.Control);
        }
    }
}

