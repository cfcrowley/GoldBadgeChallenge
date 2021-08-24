using System;
using System.Collections.Generic;
using GoldBadge_Challenge_1_ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace GoldBadgeChallenge_1
{
    [TestClass]
    public class McDowellsTest
    {
        private MenuRepository _valueMenu;
        private MenuItem _sandwiches;
        [TestInitialize]
        public void Arrange()
        {
            _valueMenu = new MenuRepository();
            _sandwiches = new MenuItem(1, "The McTerrible", "a wast of 3 dollars and 50 cents", "styrofoam and children's tears", 3.50m);
            _valueMenu.AddToList(_sandwiches);


        }
        [TestMethod]
        public void AddToMenu_ShouldReturnCorrectDescription()
        {
            MenuItem chickenFeet = new MenuItem();
            MenuRepository dinnerMenu = new MenuRepository();

            chickenFeet.Description = "why would you buy this?";
            chickenFeet.Ingreditents = "can't you tell?";
            chickenFeet.MealName = "The McSorry";
            chickenFeet.MealNumber = 2;
            chickenFeet.Price = 600.58m;
            // may not have needed to add all of the info, but you gotta have some fun sometimes
            string expected = "why would you buy this?";
            string actual = chickenFeet.Description;

            
            Assert.AreEqual(expected, actual);

        }

        [TestMethod]
        public void GetMenuItems_ShouldReturnTrue()
        {
            MenuItem bagelBite = new MenuItem();
            MenuRepository lunchMenu = new MenuRepository();

            bagelBite.MealNumber = 3;
            bagelBite.MealName = "Gourmet Mini Pizzas";
            bagelBite.Description = "Hand-crafted artisan pizza fir for a king";
            bagelBite.Ingreditents = "Cheese and sadness";
            bagelBite.Price = 345.67m;
            lunchMenu.AddToList(bagelBite);


            List<MenuItem> bagelBites = lunchMenu.GetOurMenu();
            bool weHaveAMenu = bagelBites.Contains(bagelBite);
            Assert.IsTrue(weHaveAMenu);


        }

        [TestMethod]
        public void DeleteTheItems_ShouldReturnFalse()
        {
            MenuItem bagelBite = new MenuItem();
            MenuRepository lunchMenu = new MenuRepository();

            bagelBite.MealNumber = 3;
            bagelBite.MealName = "Gourmet Mini Pizzas";
            bagelBite.Description = "Hand-crafted artisan pizza fir for a king";
            bagelBite.Ingreditents = "Cheese and sadness";
            bagelBite.Price = 345.67m;
            lunchMenu.AddToList(bagelBite);

            // i like to think this item definitely didn't sell 
            lunchMenu.DeleteOurItems(bagelBite);
            List<MenuItem> bagelBites = lunchMenu.GetOurMenu();
            bool onOurMenu = bagelBites.Contains(bagelBite);
            Assert.IsFalse(onOurMenu);
        }
    }
}
