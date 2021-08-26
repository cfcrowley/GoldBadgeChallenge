using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GoldBadge_Challenge_1_ClassLibrary
{
    public class MenuRepository
    {
        private readonly List<MenuItem> _menuItem = new List<MenuItem>();


        
        public void AddToList(MenuItem food)
        {
    
            _menuItem.Add(food);

            

        }

        public List<MenuItem> GetOurMenu()
        {
            List<MenuItem> allMenu = new List<MenuItem>();
            foreach(MenuItem m in _menuItem)
            {
                allMenu.Add(m);
            }
            return allMenu;
        }

        public void DeleteOurItems(MenuItem rancidFood)
        {
            _menuItem.Remove(rancidFood);
        }

        public MenuItem GetMenuItemByName(string mealName)
        {
            foreach(MenuItem daFood in _menuItem)
            {
                if(daFood.MealName == mealName)
                {
                    return daFood;
                }
            }
            return null;
        }
    }
}
