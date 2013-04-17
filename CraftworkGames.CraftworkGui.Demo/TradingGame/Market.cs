using System;
using System.Collections.Generic;

namespace CraftworkGames.CraftworkGui
{
    public class Market
    {
        public Market()
        {
            _productMap = new Dictionary<Product, int>();
        }

        public Dictionary<Product, int> _productMap;

        public void SubmitProduct(Product product, int quantity, decimal price)
        {
        }
    }
}

