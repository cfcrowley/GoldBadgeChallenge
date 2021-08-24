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
                        return;
                    case "3":
                        DeleteMenuItem();
                        return;
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
            item.MealNumber = comboNum;


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
            Console.Clear();
            List<MenuItem> menuItems = _ourMenu.GetOurMenu();

            foreach (MenuItem menuItem in menuItems)
            {
                DisplayContent(menuItem);
            }
        }
    }
}
