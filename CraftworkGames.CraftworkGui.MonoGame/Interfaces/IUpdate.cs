using System;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public interface IUpdate
    {
        void Update(IUpdateManager updateManager, float deltaTime);
    }
}

