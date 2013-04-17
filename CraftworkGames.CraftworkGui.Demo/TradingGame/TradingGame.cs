using System;
using System.Linq;

namespace CraftworkGames.CraftworkGui
{
    public class TradingGame
    {
        public TradingGame()
        {
            PlayerRed = new Player(new Product("Red"));
            PlayerRed.Account.Deposit(1000);

            PlayerGreen = new Player(new Product("Green"));
            PlayerGreen.Account.Deposit(1000);

            PlayerBlue = new Player(new Product("Blue"));
            PlayerBlue.Account.Deposit(1000);

            Market = new Market();
            Market.SubmitProduct(PlayerRed.Production, 1000, 100);
            Market.SubmitProduct(PlayerGreen.Production, 1000, 100);
            Market.SubmitProduct(PlayerBlue.Production, 1000, 100);
        }

        public Market Market { get; private set; }
        public Player PlayerRed { get; private set; }
        public Player PlayerGreen { get; private set; }
        public Player PlayerBlue { get; private set; }

        public bool Update(float deltaTime)
        {
            PlayerRed.Update(deltaTime);
            PlayerGreen.Update(deltaTime);
            PlayerBlue.Update(deltaTime);
            return true;
        }

        public void Buy()
        {
//            if(Market.Products.Any())
//            {
//                var selectedProduct = Market.Products.First();
//
//                if(Market.Buy(selectedProduct))
//                {
//                    Player.Account.Withdraw(selectedProduct.Price);
//                    Player.Inventory.Products.Add(selectedProduct);
//                }
//            }
        }
    }
}

