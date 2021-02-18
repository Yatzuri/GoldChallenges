using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Komodo_Cafe.Classes.MenuItem;

namespace Komodo_Cafe.Classes
{
    public class MenuRepo
    {
        private List<MenuItem> _menuList = new List<MenuItem>();

        public bool AddItemToMenuList(MenuItem item)
        {
            int startingCount = _menuList.Count;
            _menuList.Add(item);
            bool wasAdded = _menuList.Count == startingCount + 1;
            return wasAdded;
        }

        public List<MenuItem> GetMenuList()
        {
            return _menuList;
        }

        public MenuItem GetItemByName(string name)
        {
            foreach (MenuItem item in _menuList)
            {
                if (item.MealName.ToLower() == name.ToLower())
                {
                    return item;
                }
            }
            return null;

        }

        public bool RemoveItemByName(string name)
        {
            MenuItem item = GetItemByName(name);

            if (item == null)
            {
                Console.WriteLine("You no longer want this item.");
                return false;
            }
            else
            {
                _menuList.Remove(item);
                return true;
            }
        }


        public void MenuSeed()
        {

            List<Ingredient> _CroissantIngredients = new List<Ingredient>();
            Ingredient bread = new Ingredient("bread");
            Ingredient filling = new Ingredient("filling");

            _CroissantIngredients.Add(bread);
            _CroissantIngredients.Add(filling);

            MenuItem chocolateCroissant = new MenuItem(1, "Chocolate Croissant", "Croissant with chocolate filling", _CroissantIngredients, 2.99);
            MenuItem DulceDeLecheCroissant = new MenuItem(2, "Dulce de Leche Croissant", "Croissant with dulce de leche filling", _CroissantIngredients, 2.99);
            MenuItem RegularCroissant = new MenuItem(3, "Croissant", "Regular Croissant", _CroissantIngredients, 2.55);

            
            AddItemToMenuList(chocolateCroissant);
            AddItemToMenuList(DulceDeLecheCroissant);
            AddItemToMenuList(RegularCroissant);

        }

    }
}
