using System;

namespace CraftworkGames.CraftworkGui
{
    public class Product : IEquatable<Product>
    {
        public Product(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
        public Player Owner { get; set; }

        public bool Equals(Product other)
        {
            if(ReferenceEquals(other, null))
                return false;

            return Name.Equals(other.Name);
        }

        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
    }
}

