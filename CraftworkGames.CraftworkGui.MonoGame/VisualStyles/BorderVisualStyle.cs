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

