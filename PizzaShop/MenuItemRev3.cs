using System;
using System.Collections.Generic;

namespace PizzaShopRev3
{
    public interface ITopping { string Description(); }
    public class Mushrooms : ITopping
    {
        public string Description() { return "mushrooms"; }
    }
    public class BellPeppers : ITopping
    {
        public string Description() { return "bell peppers"; }

    }
    public class CherryTomatoes : ITopping
    {
        public string Description() { return "cherry tomatoes"; }
    }

    public abstract class MenuItem
    {
        private List<ITopping> toppings = new List<ITopping>();

        public void AddTopping(ITopping topping)
        {
            toppings.Add(topping);
        }

        public int Price()
        {
            int basePrice = BasePrice();
            int toppingsPrice = (int) Math.Round(toppings.Count * ToppingRate() * basePrice);
            return basePrice + toppingsPrice;
        }

        virtual public int BasePrice() { return 900; }

        virtual public double ToppingRate() { return 0.1; }

        public string Description() {
            string description =  $"{BaseDescription()}";

            if (toppings.Count > 0)
            {
                description = description + $" with {toppings[0].Description()}";
            }

            if (toppings.Count > 2)
            {
                for (int i = 1; i <= toppings.Count - 2; i++)
                {
                    description = description + $", {toppings[i].Description()}";
                }
            }

            if (toppings.Count > 1)
            {
                description = description + $" and {toppings[toppings.Count - 1].Description()}";
            }


            return description;
        }

        virtual public string BaseDescription() { return "menu item"; }
    }

    public class SmallPizza : MenuItem
    {
        override public string BaseDescription() { return "small pizza"; }
    }

    public class MediumPizza : MenuItem
    {
        override public int BasePrice() { return 1500; }
        override public double ToppingRate() { return 0.15; }
        override public string BaseDescription() { return "medium pizza"; }
    }

    public class LargePizza : MenuItem
    {
        override public int BasePrice() { return 1800; }
        override public double ToppingRate() { return 0.18; }
        override public string BaseDescription() { return "large pizza"; }
    }

    public class HalfCalzone : MenuItem
    {
        override public int BasePrice() { return 900; }
        override public double ToppingRate() { return 0.32; }
        override public string BaseDescription() { return "half calzone"; }
    }

    public class FullCalzone : HalfCalzone
    {
        override public int BasePrice() { return 1500; }
        override public string BaseDescription() { return "full calzone"; }
    }
}
