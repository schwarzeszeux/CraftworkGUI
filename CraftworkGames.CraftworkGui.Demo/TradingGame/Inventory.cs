using System;
using System.Collections.Generic;

namespace CraftworkGames.CraftworkGui
{
    public class Inventory
    {
        public Inventory()
        {
        }

        private Dictionary<Product, int> _productMap = new Dictionary<Product, int>();

        public int GetQuantity(Product product)
        {
            int quantity;

            if(_productMap.TryGetValue(product, out quantity))
                return quantity;

            return 0;
        }

        public void Add(Product product, int quantity)
        {
            if(_productMap.ContainsKey(product))
                _productMap[product] += quantity;
            else
                _productMap.Add(product, quantity);
        }

        public int Remove(Product product, int quantity)
        {
            int quantityRemaining;

            if(_productMap.TryGetValue(product, out quantityRemaining))
            {
                if(quantityRemaining >= quantity)
                {
                    quantityRemaining -= quantity;
                    _productMap[product] = quantityRemaining;
                    return quantity;
                }
                else
                {
                    _productMap[product] = 0;
                    return quantityRemaining;
                }
            }

            return 0;
        }
    }
}

