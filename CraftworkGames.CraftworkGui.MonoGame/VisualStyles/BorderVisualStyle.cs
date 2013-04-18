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
    public class BorderVisualStyle : VisualStyle
    {
        public BorderVisualStyle(string textureRegionName, int borderThickness)
            : base(textureRegionName)
        {
            BorderThickness = borderThickness;
        }

        public int BorderThickness { get; set; }

        
        //      public override void Draw (SpriteBatch spriteBatch)
        //      {
        //            var foregroundColour = Foreground;
        //
        //          var sourceRectangle = SourceRectangle;
        //          var sourceBorder = new Border(sourceRectangle, _borderThickness);
        //          var destinationRectangle = DestinationRectangle;
        //          var destinationBorder = new Border(destinationRectangle, _borderThickness, X, Y);
        //
        //          // corners
        //          spriteBatch.Draw(Texture, destinationBorder.TopLeft, sourceBorder.TopLeft, backgroundColour);
        //          spriteBatch.Draw(Texture, destinationBorder.BottomLeft, sourceBorder.BottomLeft, backgroundColour);
        //          spriteBatch.Draw(Texture, destinationBorder.TopRight, sourceBorder.TopRight, backgroundColour);
        //          spriteBatch.Draw(Texture, destinationBorder.BottomRight, sourceBorder.BottomRight, backgroundColour);
        //
        //          // sides
        //          spriteBatch.Draw(Texture, destinationBorder.Left, sourceBorder.Left, backgroundColour);
        //          spriteBatch.Draw(Texture, destinationBorder.Right, sourceBorder.Right, backgroundColour);
        //          spriteBatch.Draw(Texture, destinationBorder.Top, sourceBorder.Top, backgroundColour);
        //          spriteBatch.Draw(Texture, destinationBorder.Bottom, sourceBorder.Bottom, backgroundColour);
        //
        //          // centre
        //          spriteBatch.Draw(Texture, destinationBorder.Centre, sourceBorder.Centre, backgroundColour);
        //
        //          // text
        //          if(!string.IsNullOrEmpty(Text))
        //          {
        //              var size = FontRenderer.MeasureText(Text);
        //              var centre = destinationRectangle.Center;
        //              var lineHeight = FontRenderer.FontFile.Common.LineHeight;
        //              var textPosition = new Point(centre.X - size.Width / 2, centre.Y - lineHeight / 2);
        //                FontRenderer.DrawText(spriteBatch, textPosition.X, textPosition.Y, Text, foregroundColour);
        //          }
        //      }
    }
}

