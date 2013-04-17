#region Using Statements
using System;
using System.Collections.Generic;
using System.Linq;

#endregion

namespace CraftworkGames.CraftworkGui.Test
{
    static class Program
    {
        private static GameMain _game;

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            _game = new GameMain();
            _game.Run();
        }
    }
}
