using System;
using System.Collections.Generic;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public class ListBoxItem : IRectangle
    {
        public ListBoxItem(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
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
        {
            ItemStyle = itemStyle;
            Items = new List<ListBoxItem>();
        }

        public List<ListBoxItem> Items { get; private set; }
        public ListBoxItem SelectedItem { get; set; }
        public ListBoxItem HoveredItem { get; set; }

        public VisualStyle ItemStyle { get; set; }
        public VisualStyle SelectedItemStyle { get; set; }
        public VisualStyle HoveredItemStyle { get; set; }

        public int ItemHeight { get; set; }

        public override void Update(IUpdateManager updateManager, float deltaTime)
        {
            ListBoxItem hoveredItem = null;

            foreach(var item in Items)
            {
                if(item.ContainsPoint(updateManager.X, updateManager.Y))
                    hoveredItem = item;
            }

            HoveredItem = hoveredItem;

            if(updateManager.IsInputPressed && ContainsPoint(updateManager.X, updateManager.Y))
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
                drawManager.DrawText(item.Name, item, style);

                y += ItemHeight;
            }
        }
    }
}

