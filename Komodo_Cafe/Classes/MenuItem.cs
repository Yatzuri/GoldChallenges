using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Komodo_Cafe.Classes
{
    public class MenuItem
    {
        public class Ingredient
        {
            public string MealName { get; set; }

            public Ingredient()
            {

            }


            public Ingredient(string mealname)
            {
                MealName = mealname;
            }
        }

        public int MealNumber { get; set; }
        public string MealName { get; set; }
        public string Description { get; set; }
        public List<Ingredient> Ingredients { get; set; }
        public double Price { get; set; }

        public MenuItem(int mealNumber, string mealName, string description, List<Ingredient> ingredients, double price)
        {
            MealNumber = mealNumber;
            MealName = mealName;
            Description = description;
            Ingredients = ingredients;
            Price = price;
        }


    }
}
