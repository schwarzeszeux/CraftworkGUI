using System;
using CraftworkGames.CraftworkGui.MonoGame;

namespace CraftworkGames.CraftworkGui
{
    public class Player
    {
        public Player(Product production)
        {
            Inventory = new Inventory();
            Account = new Account();
            Production = production;
            Production.Owner = this;
        }

        public Inventory Inventory { get; private set; }
        public Account Account { get; private set; }
        public Product Production { get; private set; }

        private float _incrementDelay = 2.1f;
        private float _timeRemaining = 0;
        public bool Update(float deltaTime)
        { 
            _timeRemaining -= deltaTime;

            if(_timeRemaining <= 0)
            {
                Inventory.Add(Production, 1);
                _timeRemaining = _incrementDelay;
            }

            return true;
        }
    }
}

