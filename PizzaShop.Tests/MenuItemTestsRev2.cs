using NUnit.Framework;
using PizzaShopRev2;
// small $9 small pizza toppings 10% of the price
// medium pizza $15 Toppings 15% - cheese, onions, bell peppers
// Large pizza $18 toppings 18% - Pep, sausage, ham
// 1/2 order calzone $9 toppings 32% Roasted Garlic, Sundried Tomato
// full order calzone $15

// Start a new pizza
// Add toppings to pizza
// get current price of the pizza
// get a description of the pizza "small pizza with sausage and cheese"
namespace Tests {
    public class MenuItemTestsRev2 {
        [Test]
        public void ItExists () {
            IMenuItem pizza = new SmallPizza ();
            Assert.Pass ();
        }

        [Test]
        public void TopingsCanBeAdded () {
            IMenuItem pizza = new SmallPizza ();
            pizza.AddTopping (new Mushrooms ());
            Assert.Pass ();
        }

        [Test]
        public void CanGetTheCurrentPriceOfPizza () {
            IMenuItem smallPizza = new SmallPizza ();
            smallPizza.AddTopping (new Mushrooms ());
            Assert.AreEqual (990, smallPizza.Price ());

            IMenuItem mediumPizza = new MediumPizza ();
            mediumPizza.AddTopping (new Mushrooms ());
            Assert.AreEqual (1725, mediumPizza.Price ());

            IMenuItem largePizza = new LargePizza ();
            largePizza.AddTopping (new Mushrooms ());
            Assert.AreEqual (2124, largePizza.Price ());
        }

        [Test]
        public void CanGetTheCurrentPriceOfCalzone () {
            IMenuItem halfCalzone = new HalfCalzone ();
            halfCalzone.AddTopping (new Mushrooms ());
            Assert.AreEqual (1152, halfCalzone.Price ());

            IMenuItem fullCalzone = new FullCalzone ();
            fullCalzone.AddTopping (new Mushrooms ());
            Assert.AreEqual (1920, fullCalzone.Price ());
        }

        [Test]
        public void CanGetDescriptionOfItem () {
            IMenuItem halfCalzone = new HalfCalzone ();
            halfCalzone.AddTopping (new Mushrooms ());
            Assert.AreEqual (
                "half calzone with mushrooms",
                halfCalzone.Description ()
            );

            IMenuItem fullCalzone = new FullCalzone ();
            fullCalzone.AddTopping (new Mushrooms ());
            fullCalzone.AddTopping (new BellPeppers ());
            Assert.AreEqual (
                "full calzone with mushrooms and bell peppers",
                fullCalzone.Description ()
            );

            IMenuItem smallPizza = new SmallPizza ();
            smallPizza.AddTopping (new Mushrooms ());
            smallPizza.AddTopping (new BellPeppers ());
            smallPizza.AddTopping (new CherryTomatoes ());
            Assert.AreEqual (
                "small pizza with mushrooms, bell peppers, and cherry tomatoes",
                smallPizza.Description ()
            );
        }
    }
}