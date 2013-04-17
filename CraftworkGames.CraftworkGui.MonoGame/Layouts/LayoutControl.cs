using System;
using System.Collections.Generic;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public abstract class LayoutControl : Control
    {
        public LayoutControl()
        {
        }

        public abstract void PerformLayout();

        protected abstract IEnumerable<Control> GetControls();

        public override void Update(IUpdateManager updateManager, float deltaTime)
        {
            foreach(var control in GetControls())
                control.Update(updateManager, deltaTime);
        }

        public override void Draw(IDrawManager drawManager)
        {
            foreach(var control in GetControls())
                control.Draw(drawManager);
        }
    }
}

