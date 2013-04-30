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
    /// <summary>
    /// This is a work in progress, use at your own risk.
    /// </summary>
    public class BorderedVisualStyle : VisualStyle
    {
        public BorderedVisualStyle(int borderThickness)
            : base(null)
        {
            BorderThickness = borderThickness;
        }

        public ITextureRegion TopLeftRegion { get; set; }
        public ITextureRegion TopRegion { get; set; }
        public ITextureRegion TopRightRegion { get; set; }
        public ITextureRegion LeftRegion { get; set; }
        public ITextureRegion CentreRegion { get; set; }
        public ITextureRegion RightRegion { get; set; }
        public ITextureRegion BottomLeftRegion { get; set; }
        public ITextureRegion BottomRegion { get; set; }
        public ITextureRegion BottomRightRegion { get; set; }
        public int BorderThickness { get; set; }

        private class Rect : IRectangle
        {
            public int X { get; set; }
            public int Y { get; set; }
            public int Width { get; set; }
            public int Height { get; set; }
        }

        private IRectangle ToRect(Microsoft.Xna.Framework.Rectangle rectangle)
        {
            return new Rect()
            {
                X = rectangle.X,
                Y = rectangle.Y,
                Width = rectangle.Width,
                Height = rectangle.Height
            };
        }

        public override void Draw(IDrawManager drawManager, IRectangle destinationRectangle)
        {
            var border = new Border(destinationRectangle, BorderThickness);

            drawManager.Draw(TopLeftRegion, ToRect(border.TopLeft));
            drawManager.Draw(TopRegion, ToRect(border.Top));
            drawManager.Draw(TopRightRegion, ToRect(border.TopRight));
            drawManager.Draw(LeftRegion, ToRect(border.Left));
            drawManager.Draw(CentreRegion, ToRect(border.Centre));
            drawManager.Draw(RightRegion, ToRect(border.Right));
            drawManager.Draw(BottomLeftRegion, ToRect(border.BottomLeft));
            drawManager.Draw(BottomRegion, ToRect(border.Bottom));
            drawManager.Draw(BottomRightRegion, ToRect(border.BottomRight));
        }
    }
}

