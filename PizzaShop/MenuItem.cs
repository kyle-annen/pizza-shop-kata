using System;
using System.Collections.Generic;

namespace PizzaShop
{
    public enum ItemType {Pizza, Calzone};
    public enum Size {Small, Medium, Large, Half, Full};
    public class MenuItem
    {
        public ItemType item;
        public Size size;
        public List<string> toppings = new List<string>();
        public int basePrice;
        public int toppingsPrice;

        public MenuItem(ItemType _item, Size _size)
        {
            this.item = _item;
            this.size = _size;
        }

        public void setSize(Size sizeToSet) {
            switch (item)
            {
                case ItemType.Calzone:
                    switch (sizeToSet)
                    {
                        case Size.Small: size = Size.Half; break;
                        case Size.Half: size = Size.Half; break;
                        default: size = Size.Full; break;
                    }
                    break;
                case ItemType.Pizza:
                    switch(sizeToSet)
                    {
                        case Size.Half: size = Size.Small; break;
                        case Size.Small: size = Size.Small; break;
                        case Size.Medium: size = Size.Medium; break;
                        default: size = Size.Large; break;
                    }
                    break;
            }
        } 

        public void setMenuItem(ItemType itemToSet)
        {
            this.item = itemToSet;
            setSize(this.size);
        }
        public void addTopping(String topping) => toppings.Add(topping);
        public int getPrice()
        {
            basePrice = getBasePrice();
            toppingsPrice = (int) Math.Round(getToppingsPrice());
            return basePrice + toppingsPrice;
        }

        public int getBasePrice()
        {
            switch(size)
            {
                case Size.Small: return 900;
                case Size.Medium: return 1500;
                case Size.Large: return 1800;
                case Size.Half: return 900;
                case Size.Full: return 1500;
                default: return 1800;
            }
        }
        public double getToppingsPrice() => getToppingRate() * toppings.Count;

        public double getToppingRate()
        {
            switch(size)
            {
                case Size.Small: return getBasePrice() * 0.1;
                case Size.Medium: return getBasePrice() * 0.15;
                case Size.Large: return getBasePrice() * 0.18;
                default: return getBasePrice() * 0.32;
            }
        }

        public string getDescription()
        {
            var sizeDesc = size.ToString().ToLower();
            var itemDesc = item.ToString().ToLower();
            var toppingDesc = getToppingDescription();
            return $"{sizeDesc} {itemDesc}{toppingDesc}";
        }

        public string getToppingDescription()
        {
            switch(toppings.Count)
            {
                case 0: return "";
                case 1: return $" with {toppings[0]}";
                case 2: return $" with {toppings[0]} and {toppings[1]}";
                default: return getMultiToppingDescription();
            }
        }

        public string getMultiToppingDescription()
        {
            string description = $" with {toppings[0]}";
            string ending = $", and {toppings[toppings.Count - 1]}";

            for (int i = 1; i < toppings.Count - 1; i++)
            {
                description = description + $", {toppings[i]}";
            }

            return description + ending;
        }
    }
}
