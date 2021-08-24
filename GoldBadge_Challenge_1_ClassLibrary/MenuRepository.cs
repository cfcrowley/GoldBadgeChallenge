﻿using System;
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
            return _menuItem;
        }

        public void DeleteOurItems(MenuItem rancidFood)
        {
            _menuItem.Remove(rancidFood);
        }
    }
}
