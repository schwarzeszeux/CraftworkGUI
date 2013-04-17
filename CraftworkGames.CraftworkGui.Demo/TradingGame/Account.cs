using System;

namespace CraftworkGames.CraftworkGui
{
    public class Account
    {
        public Account()
        {
        }

        public decimal Balance { get; private set; }

        public void Deposit(decimal amount)
        {
            Balance += amount;
        }

        public bool Withdraw(decimal amount)
        {
            if(Balance < amount)
                return false;

            Balance -= amount;
            return true;
        }
    }
}

