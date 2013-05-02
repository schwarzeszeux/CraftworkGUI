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

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public class ListBoxItem : IRectangle
    {
        public ListBoxItem(string text)
        {
            Text = text;
        }

        public string Text { get; set; }
        public object Tag { get; set; }

        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }
    }

    public class ListBox : Control
    {
        public ListBox()
            : this(null)
        {
        }

        public ListBox(VisualStyle itemStyle)
            : base(null)
        {
            ItemStyle = itemStyle;
            Items = new List<ListBoxItem>();
        }

        public List<ListBoxItem> Items { get; private set; }
        public ListBoxItem SelectedItem { get; set; }
        public ListBoxItem HoveredItem { get; set; }

        public VisualStyle ItemStyle { get; set; }
        public TextStyle ItemTextStyle { get; set; }
        public VisualStyle SelectedItemStyle { get; set; }
        public VisualStyle HoveredItemStyle { get; set; }

        public int ItemHeight { get; set; }

        public override void Update(IInputManager inputManager, float deltaTime)
        {
            ListBoxItem hoveredItem = null;

            foreach(var item in Items)
            {
                if(item.ContainsPoint(inputManager.MousePosition))
                    hoveredItem = item;
            }

            HoveredItem = hoveredItem;

            if(inputManager.IsInputPressed && ContainsPoint(inputManager.MousePosition))
                SelectedItem = HoveredItem;
        }

        public override void Draw(IDrawManager drawManager)
        {
            int y = Y;

            foreach(var item in Items)
            {
                item.X = X;
                item.Y = y;
                item.Width = Width;
                item.Height = ItemHeight;

                var style = ItemStyle;

                if(SelectedItemStyle != null && item == SelectedItem)
                {
                    style = SelectedItemStyle;
                }
                else
                {
                    if(HoveredItemStyle != null && item == HoveredItem)
                        style = HoveredItemStyle;
                    else
                        style = ItemStyle;
                }

                style.Draw(drawManager, item);
                ItemTextStyle.Draw(drawManager, item.Text, item);

                y += ItemHeight;
            }
        }
    }
}

