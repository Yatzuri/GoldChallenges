using Komodo_Cafe.Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using static Komodo_Cafe.Classes.MenuItem;

namespace UnitTestCafe
{
    [TestClass]
    public class UnitTest1
    {
        private MenuRepo _repo = new MenuRepo();
        private List<Ingredient> _CroissantIngredients = new List<Ingredient>();

        public void Seed()
        {
            
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


        [TestMethod]
        public void AddItemGetCount()
        {
            Seed();

            //Assert
            int expected = 2;
            int actual = _repo.GetMenuList().Count;
            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void AddItemCountShouldIncrease()
        {

            MenuItem chocolateCroissant = new MenuItem(1, "Chocolate Croissant", "Croissant with chocolate filling", _CroissantIngredients, 2.99);
            bool wasAdded = _repo.AddItemToMenuList(chocolateCroissant);

            Assert.IsTrue(wasAdded);

        }

        [TestMethod]
        public void GetItemByNameShouldGetItem()
        {
            //arrange
            MenuItem chocolateCroissant = new MenuItem(1, "Chocolate Croissant", "Croissant with chocolate filling", _CroissantIngredients, 2.99);
            _repo.AddItemToMenuList(chocolateCroissant);
            MenuItem testItem = _repo.GetItemByName("Chicken Sandwich");

            //assert
            Assert.AreEqual(chocolateCroissant, testItem);
        }

        [TestMethod]
        public void RemoveFromListShouldRemove()
        {
            Seed();

            _repo.RemoveItemByName("Chocolate Croissant");
            int expected = 1;
            int actual = _repo.GetMenuList().Count;
            Assert.AreEqual(expected, actual);

        }
    }
}
