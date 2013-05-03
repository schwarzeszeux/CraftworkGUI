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
    public abstract class LayoutControl<T> : Control
    {
        public LayoutControl()
            : base(null)
        {
            HorizontalAlignment = HorizontalAlignment.Stretch;
            VerticalAlignment = VerticalAlignment.Stretch;
            Margin = new Margin(0);
            Items = new EventList<T>();
            PositionChanged += LayoutPropertyChanged;
            SizeChanged += LayoutPropertyChanged;
        }
                
        private void LayoutPropertyChanged (object sender, EventArgs e)
        {
            PerformLayout();
        }

        public EventList<T> Items { get; private set; }

        public abstract void PerformLayout();

        protected abstract IEnumerable<Control> GetControls();

        protected void AlignControl(Control control, IRectangle rectangle)
        {
            AlignControl(control, new Rectangle(rectangle.X, rectangle.Y, rectangle.Width, rectangle.Height));
        }

        protected Size GetSize(Control control)
        {
            var desiredSize = control.DesiredSize;
            var width = desiredSize.Width + control.Margin.Left + control.Margin.Right;
            var height = desiredSize.Height + control.Margin.Top + control.Margin.Bottom;
            return new Size(width, height);
        }

        protected void AlignControl(Control control, Rectangle rectangle)
        {
            var controlSize = GetSize(control);

            switch(control.HorizontalAlignment)
            {
                case HorizontalAlignment.Left:
                    control.X = rectangle.X + control.Margin.Left;
                    break;
                case HorizontalAlignment.Right:
                    control.X = rectangle.X + rectangle.Width - controlSize.Width;
                    break;
                case HorizontalAlignment.Stretch:
                    control.X = rectangle.X + control.Margin.Left;
                    control.Width = rectangle.Width - control.Margin.Right - control.Margin.Left;
                    break;
                case HorizontalAlignment.Centre:
                    var halfWidth = rectangle.Width / 2;
                    var controlHalfWidth = control.Width / 2;
                    control.X = rectangle.X + halfWidth - controlHalfWidth;
                    break;
            }

            switch(control.VerticalAlignment)
            {
                case VerticalAlignment.Top:
                    control.Y = rectangle.Y + Margin.Top;
                    break;
                case VerticalAlignment.Bottom:
                    control.Y = rectangle.Y + rectangle.Height - controlSize.Height;
                    break;
                case VerticalAlignment.Stretch:
                    control.Y = rectangle.Y + Margin.Top;
                    control.Height = rectangle.Height - Margin.Bottom - control.Margin.Top;
                    break;
                case VerticalAlignment.Centre:
                    var halfHeight = rectangle.Height / 2;
                    var controlHalfHeight = control.Height / 2;
                    control.Y = rectangle.Y + halfHeight - controlHalfHeight;
                    break;
            }
        }

        public override void Update(IInputManager inputManager, float deltaTime)
        {
            foreach(var control in GetControls())
                control.Update(inputManager, deltaTime);
        }

        public override void Draw(IDrawManager drawManager)
        {
            foreach(var control in GetControls())
                control.Draw(drawManager);
        }
    }
}

