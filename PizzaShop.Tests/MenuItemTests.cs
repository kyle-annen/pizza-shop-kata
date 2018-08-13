using NUnit.Framework;
using PizzaShop;
// small $9 small pizza toppings 10% of the price
 // medium pizza $15 Toppings 15% - cheese, onlinos bell pepper
 // Large pizza $18 toppings 18% - Pep, sausage, ham
 // 1/2 order calzone $9 toppings $32% Roasted Garliz, Sundried Tomato
 // full order calzone $15

 // Start a new pizza
 // Add toppings to pizza
 // get current price of the pizza
 // get a description of the pizza "small pizza with sausage and cheese"
namespace Tests
{
    public class MenuItemTests
    {
        [Test]
        public void ItExists()
        {
            MenuItem pizza = new MenuItem(ItemType.Pizza, Size.Small);
            Assert.Pass();
        }

        [Test]
        public void SizeCanBeSet()
        {
            MenuItem pizza = new MenuItem(ItemType.Pizza, Size.Small);
            pizza.setSize(Size.Small);
            pizza.setSize(Size.Medium);
            pizza.setSize(Size.Large);
            Assert.Pass();
        }
        [Test]
        public void TopingsCanBeAdded()
        {
            MenuItem pizza = new MenuItem(ItemType.Pizza, Size.Small);
            pizza.addTopping("Mushrooms");
            Assert.Pass();
        }
        [Test]
        public void CanGetTheCurrentPriceOfPizza()
        {
            MenuItem pizza = new MenuItem(ItemType.Pizza, Size.Small);
            pizza.addTopping("Mushrooms");
            Assert.AreEqual(990, pizza.getPrice());

            pizza.setSize(Size.Medium);
            Assert.AreEqual(1725, pizza.getPrice());

            pizza.setSize(Size.Large);
            Assert.AreEqual(2124, pizza.getPrice());

            pizza.setSize(Size.Full);
            Assert.AreEqual(2124, pizza.getPrice());

            pizza.setSize(Size.Half);
            Assert.AreEqual(990, pizza.getPrice());
        }

        [Test]
        public void CanGetTheCurrentPriceOfCalzone()
        {
            MenuItem calzone = new MenuItem(ItemType.Calzone, Size.Half);
            calzone.setSize(Size.Half);
            calzone.addTopping("Mushrooms");
            Assert.AreEqual(1188, calzone.getPrice());

            calzone.setSize(Size.Full);
            Assert.AreEqual(1980, calzone.getPrice());
        }

        [Test]
        public void CanGetDescriptionOfItem()
        {
            MenuItem calzone = new MenuItem(ItemType.Calzone, Size.Half);
            calzone.addTopping("mushrooms");
            Assert.AreEqual(
                "half calzone with mushrooms",
                calzone.getDescription()
            );

            calzone.addTopping("bell peppers");
            Assert.AreEqual(
                "half calzone with mushrooms and bell peppers",
                calzone.getDescription()
            );

            calzone.addTopping("cherry tomatoes");
            Assert.AreEqual(
                "half calzone with mushrooms, bell peppers, and cherry tomatoes",
                calzone.getDescription()
            );

            calzone.setSize(Size.Full);
            Assert.AreEqual(
                "full calzone with mushrooms, bell peppers, and cherry tomatoes",
                calzone.getDescription()
            );

            calzone.setMenuItem(ItemType.Pizza);
            Assert.AreEqual(
                "large pizza with mushrooms, bell peppers, and cherry tomatoes",
                calzone.getDescription()
            );
        }
    }
}