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
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public class GridLayout : LayoutControl<GridItem>
    {
        public GridLayout(int rows, int columns)
        {
            Rows = rows;
            Columns = columns;
        }

        public int Rows { get; private set; }
        public int Columns { get; private set; }

        public override Size DesiredSize
        {
            get
            {
                return CalculateDesiredSize();
            }
        }

        private Size CalculateDesiredSize()
        {
            var rowHeight = Items.Max(i => i.Control.Height);
            var columnWidth = Items.Max(i => i.Control.Width);

            return new Size(columnWidth * Columns, rowHeight * Rows);
        }

        public override void PerformLayout()
        {
            int cellWidth = Width / Columns;
            int cellHeight = Height / Rows;

            foreach(var gridItem in Items)
            {
                var rectangle = new Rectangle(X + gridItem.Column * cellWidth, Y + gridItem.Row * cellHeight, cellWidth, cellHeight);
                AlignControl(gridItem.Control, rectangle);
            }
        }

        protected override IEnumerable<Control> GetControls()
        {
            return Items.Select(i => i.Control);
        }
    }
}

