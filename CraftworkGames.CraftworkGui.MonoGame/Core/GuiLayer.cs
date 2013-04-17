using System;
using System.Collections.Generic;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public class GuiLayer : IUpdate, IDraw, IRectangle
    {
        public GuiLayer(int width, int height)
        {
            Width = width;
            Height = height;
            Controls = new List<Control>();
        }

        public int X { get { return 0; } }
        public int Y { get { return 0; } }
        public int Width { get; private set; }
        public int Height { get; private set; }

        public string BackgroundName { get; set; }
        public List<Control> Controls { get; private set; }

        public void Update(IUpdateManager updateManager, float deltaTime)
        {
            foreach(var control in Controls)
                control.Update(updateManager, deltaTime);
        }
        
        public void Draw(IDrawManager drawManager)
        {
            drawManager.StartBatch();

            if(!string.IsNullOrEmpty(BackgroundName))
                drawManager.DrawTexture(BackgroundName, this);

            foreach(var control in Controls)
                control.Draw(drawManager);

            drawManager.EndBatch();
        }
    }
}

