using Komodo_Cafe.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Komodo_Cafe.Classes.MenuItem;

namespace Komodo_Cafe
{
    class ProgramUI
    {

        private MenuRepo _repo = new MenuRepo();

        public void Run()
        {
            SeedMenuList();
            RunMenu();
        }

        private void RunMenu()
        {

            Console.Title = "ASCII Art";
            string title = @"


    _    _                      _           ______       ___  ___           
   | |  / )                    | |         / _____)     / __)/ __)          
   | | / / ___  ____   ___   _ | | ___    | /      ___ | |__| |__ ____ ____ 
   | |< < / _ \|    \ / _ \ / || |/ _ \   | |     / _ \|  __)  __) _  ) _  )
   | | \ \ |_| | | | | |_| ( (_| | |_| |  | \____| |_| | |  | | ( (/ ( (/ / 
   |_|  \_)___/|_|_|_|\___/ \____|\___/    \______)___/|_|  |_|  \____)____)                   

                                    ,                            
                                  **                              
                                 *********                        
                                        **                        
                                   ****                           
                                **. ******** ***                  
                                       *****                      
                                 *** ,***,*                       
                                    ,#%&&%#*                      
                        (       *((((((((((((((*      &&          
                        &  &&&&%   ./((((((/.  (&&&&&&&&&&&&&&&   
                        & *  ********************** &&&&      &&. 
                        & *  ********************** &&&&       && 
                         & *  ********************* &&&        &% 
                           **  ******************* &&&#       &&  
                           %.** ***************** &&&       &&&   
                            & *****************. &&& &&&&&&&      
                              * ,************  &&&                
                  &&      &&&     &&&&/,/&&&&&     %&&      &&    
                      &&&&&&,                       &&&&&&        
                              &&&&&&&&&&&&&&&&&&&&         
                                                                 ";

            Console.WriteLine(title);
            Console.WriteLine("Press any key to continue");
            Console.Read();

            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of your selection: \n" +
                    "1. Add New Menu Item\n" +
                    "2. Delete Menu Item\n" +
                    "3. Print Full Menu List\n" +
                    "4. Exit"
                    );

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        CreateNewMenuItem();
                        Console.ReadKey();
                        break;
                    case "2":
                        RemoveItemFromMenu();
                        Console.ReadKey();
                        break;
                    case "3":
                        PrintMenu();
                        Console.ReadKey();
                        break;
                    case "4":
                        continueToRun = false;
                        Console.WriteLine("Goodbye!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Enter a given option");
                        Console.ReadKey();
                        break;
                }
            }
        }

       


        public void CreateNewMenuItem()
        {
            Console.Clear();
            Console.Write("Enter a meal number: ");
            int mealNumber = Convert.ToInt32(Console.ReadLine());

            Console.Write("What's the new item called? ");
            string name = Console.ReadLine();

            Console.Write("What's the item description: ");
            string description = Console.ReadLine();

            Console.Write("List of ingredients: ");
            string list = Console.ReadLine();
            string[] words = list.Split(',');

            List<Ingredient> _ingredientList = new List<Ingredient>();
            foreach (string ingredientItem in words)
            {
                Ingredient i = new Ingredient(ingredientItem);
                _ingredientList.Add(i);
            }

            Console.Write("How much will it cost? ");

            double price = Convert.ToDouble(Console.ReadLine());


            MenuItem newItem = new MenuItem(mealNumber, name, description, _ingredientList, price);

            _repo.AddItemToMenuList(newItem);
            Console.WriteLine("New item was added!");
            Console.ReadLine();
        }



        private void RemoveItemFromMenu()
        {
            Console.Write("Enter a menu item to remove: ");
            string nameEntry = Console.ReadLine();

            _repo.RemoveItemByName(nameEntry);
            Console.WriteLine("This item is off the menu!");
        }



        
        public void PrintMenu()
        {
            Console.Clear();
            List<MenuItem> listOfItems = _repo.GetMenuList();

            foreach (MenuItem menuItem in listOfItems)
            {
                DisplayContent(menuItem);
            }
        }
        public void DisplayContent(MenuItem item)
        {
            Console.WriteLine($"{item.MealNumber}. A {item.Description} is {item.Price}.");
        }



        private void SeedMenuList()
        {
            List<Ingredient> _CroissantIngredients = new List<Ingredient>();
            Ingredient bread = new Ingredient("bread");
            Ingredient filling = new Ingredient("filling");

            
            _CroissantIngredients.Add(bread);
            _CroissantIngredients.Add(filling);

            
            MenuItem chocolateCroissant = new MenuItem(1, "Chocolate Croissant", "Croissant with chocolate filling", _CroissantIngredients, 2.99);
            MenuItem DulceDeLecheCroissant = new MenuItem(2, "Dulce de Leche Croissant", "Croissant with dulce de leche filling", _CroissantIngredients, 2.99);
            MenuItem RegularCroissant = new MenuItem(3, "Croissant", "Regular Croissant", _CroissantIngredients, 2.55);

            
            _repo.AddItemToMenuList(chocolateCroissant);
            _repo.AddItemToMenuList(DulceDeLecheCroissant);
            _repo.AddItemToMenuList(RegularCroissant);

        }
    }
}
