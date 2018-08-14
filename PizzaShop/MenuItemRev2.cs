using System;
using System.Collections.Generic;

namespace PizzaShopRev2
{
    public interface ITopping
    {
        string Description();
    }

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

    public interface IMenuItem
    {
       void AddTopping(ITopping topping);
       int Price();
       string Description();
       string ItemDescription();
    }

    public class SmallPizza : IMenuItem
    {
        private List<ITopping> toppings = new List<ITopping>();

        public void AddTopping(ITopping topping) => toppings.Add(topping);
        public virtual int ItemPrice() { return 900; }
        public virtual double ToppingRate() { return 0.1; }
        public virtual string ItemDescription() { return "small pizza"; }

        public int Price()
        {
            int toppingPrice = (int) Math.Round(ItemPrice() * ToppingRate() * toppings.Count) ;
            return toppingPrice + ItemPrice();
        }

        public string Description()
        {
            switch(toppings.Count) {
                case 1: return OneIngredientDescription(); break;
                case 2: return TwoIngredientDescription(); break;
                default: return MultiIngredientDescription(); break;
            }
        }

        public string OneIngredientDescription()
        {
            return $"{ItemDescription()} with {toppings[0].Description()}";
        }

        public string TwoIngredientDescription()
        {
            return $"{OneIngredientDescription()} and {toppings[1].Description()}";
        }

        public string MultiIngredientDescription()
        {
            string description = $"{ItemDescription()} with {toppings[0].Description()}";
            string ending = $", and {toppings[toppings.Count - 1].Description()}";

            for (int i = 1; i < toppings.Count - 1; i++)
            {
                description = description + $", {toppings[i].Description()}";
            }

            return description + ending;
        }
    }

    public class MediumPizza : SmallPizza
    {
        override public int ItemPrice() { return 1500; }
        override public double ToppingRate() { return 0.15; }
        override public string ItemDescription() { return "medium pizza"; }
    }

    public class LargePizza : SmallPizza
    {
        override public int ItemPrice() { return 1800; }
        override public double ToppingRate() { return 0.18; }
        override public string ItemDescription() { return "large pizza"; }
    }

    public class HalfCalzone : SmallPizza
    {
        override public double ToppingRate() { return 0.28; }
        override public string ItemDescription() { return "half calzone"; }
    }

    public class FullCalzone : HalfCalzone
    {
        override public int ItemPrice() { return 1500; }
        override public string ItemDescription() { return "full calzone"; }
    }
}
