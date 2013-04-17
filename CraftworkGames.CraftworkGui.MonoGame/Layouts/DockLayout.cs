using System;
using System.Linq;
using System.Collections.Generic;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public enum DockStyle
    {
        Left,
        Top,
        Right,
        Bottom
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
            foreach(var dockItem in Controls)
            {
                switch(dockItem.DockStyle)
                {
                    case DockStyle.Left:
                        dockItem.Control.X = X;
                        dockItem.Control.Y = Y;
                        dockItem.Control.Height = Height;
                        break;
                    case DockStyle.Right:
                        dockItem.Control.X = X + Width - dockItem.Control.Width;
                        dockItem.Control.Y = Y;
                        dockItem.Control.Height = Height;
                        break;
                    case DockStyle.Top:
                        dockItem.Control.X = X;
                        dockItem.Control.Y = Y;
                        dockItem.Control.Width = Width;
                        break;
                    case DockStyle.Bottom:
                        dockItem.Control.X = X;
                        dockItem.Control.Y = Y + Height - dockItem.Control.Height;
                        dockItem.Control.Width = Width;
                        break;
                }
            }
        }

        protected override IEnumerable<Control> GetControls()
        {
            return Controls.Select(i => i.Control);
        }
    }
}

