using System;

namespace CraftworkGames.CraftworkGui.MonoGame
{
    public interface IUpdateManager
    {
        bool IsInputPressed { get; }
        int X { get; }
        int Y { get; }
    }
}

