using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_Challenge_1_ClassLibrary
{
    public class ProgramUI
    {
    private readonly MenuRepository _ourMenu = new MenuRepository();
        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            MenuItem chickenLivers = new MenuItem(1, "Chicken Surprise", "a horrible meal that I wouldn't eat", "Chicken Livers and sadness", 10.50m);
            MenuItem hamburgerPizza = new MenuItem(2, "Cheeza", "We take the worst parts of a burger and ruin a pizza", "a whole darn hamburger smashed on a piza", 15.99m);
            MenuItem tacoSalad = new MenuItem(3, "Taco Party", "What we didn't use for our burgers yesterday is today's fresh taco salad", "rancid leftovers", 8.99m);
            MenuItem frenchFries = new MenuItem(4, "FreedomFries", "deliciously overcooked potato chunks", "potatoes and sadness", 2.25m);
            _ourMenu.AddToList(chickenLivers);
            _ourMenu.AddToList(hamburgerPizza);
            _ourMenu.AddToList(tacoSalad);
            _ourMenu.AddToList(frenchFries);

            Console.WriteLine("Welcome to the McDowell's restaurant... if you're a health inspector.... you have to let me know");
            Console.ReadLine();
        }

        public void Menu()
        {
            Console.Clear();
            bool keepRunning = true;
            while (keepRunning)
            {
                Console.WriteLine("Main Menu\n" + "1. Add to our Menu \n" + "2. Check our Menu\n" + "3. Delete a Menu Item\n" + "4.Exit");
                string yourInput = Console.ReadLine();
                switch (yourInput)
                {
                    case "1":
                        AddMenuItem();
                        break;
                    case "2":
                        SeeOurMenu();
                        break;
                    case "3":
                        DeleteMenuItem();
                        break;
                    case "4":
                        keepRunning = false;
                        break;
                }
            }


        }
            private void AddMenuItem()
        {
            Console.Clear();
            MenuItem item = new MenuItem();

            Console.WriteLine("Please assign a Combo number from 5-100");
            string comboNumber = Console.ReadLine();
            int comboNum = int.Parse(comboNumber);
            if(comboNum > 4)
            {

            item.MealNumber = comboNum;
            }
            else
            {
                Console.WriteLine("please use a number from 5-100");
            }


            Console.WriteLine("Please give the meal a name");
            item.MealName = Console.ReadLine();

            Console.WriteLine("Please describe the new item");
            item.Description = Console.ReadLine();

            Console.WriteLine("Please tell us the ingredients");
            item.Ingreditents = Console.ReadLine();

            Console.WriteLine("Tell us how much it costs");
            string itemCost = Console.ReadLine();
            var cost = Convert.ToDecimal(itemCost);
            item.Price = cost;


            _ourMenu.AddToList(item);
        }

        public void SeeOurMenu()
        {
            List<MenuItem> menuItems = _ourMenu.GetOurMenu();

            foreach (MenuItem menuItem in menuItems)
            {
                DisplayMenu(menuItem);
            }
        }
        public void DisplayMenu(MenuItem food)
        {
            Console.WriteLine($"{food.MealNumber} {food.MealName} {food.Description} {food.Ingreditents} {food.Price}");
        }

        private void DeleteMenuItem()
        {
            Console.Clear();
            Console.WriteLine("Which food has gone bad and needs to be removed?");
            string foodName = Console.ReadLine();
            MenuItem badFood = _ourMenu.GetMenuItemByName(foodName);
            if (badFood != null)
            {
                DisplayMenu(badFood);
                Console.WriteLine("You sure you wanna get rid of that? A local school may buy it. Please type yes or no");
                string response = Console.ReadLine();
                if (response == "yes" || response == "y")
                {
                    _ourMenu.DeleteOurItems(badFood);
                    Console.WriteLine("Good call... we've had that since the Reagan administration");
                }
                else
                {
                    Console.WriteLine("I mean that's just like your opinion, man");
                }
            }
            else
            {
                Console.WriteLine("You got rid of that last week, silly");
            }
            Console.ReadLine();
        }

        public void GetMenuItemByName()
        {
            Console.Clear();
            Console.WriteLine("Enter the name of the menu item");
            string menuItem = Console.ReadLine();
            MenuItem foodProduct = _ourMenu.GetMenuItemByName(menuItem);

            if(foodProduct == null)
            {
                Console.WriteLine("Dude get it together... that was in a dream 3 weeks ago");
            }
            else
            {
                DisplayMenu(foodProduct);
            }
            Console.ReadLine();
        }
    }

}
