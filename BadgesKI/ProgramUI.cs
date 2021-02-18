using BadgesKI.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BadgesKI
{
    public class ProgramUI
    {
        private BadgeRepo _repo = new BadgeRepo();

        public void Run()
        {
            _repo.DictionarySeed();
            RunMenu();
        }

        private void RunMenu()
        {
            _repo.ConvertListToDictionary();
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();
                Console.WriteLine("Corporate Security Badge Database 2.0\n");
                Console.WriteLine("Enter the number of your selection: \n" +
                    "1. Add A Security Badge\n" +
                    "2. Edit A Security Badge\n" +
                    "3. List All Badges\n" +
                    "4. Exit"
                    );

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        CreateNewBadge();
                        Console.ReadKey();
                        break;
                    case "2":
                        UpdateBadge();
                        Console.ReadKey();
                        break;
                    case "3":
                        PrintAllBadges();
                        Console.ReadKey();
                        break;
                    case "4":
                        continueToRun = false;
                        Console.WriteLine("Come back soon!");
                        Console.ReadKey();
                        break;
                    default:
                        Console.WriteLine("Error");
                        Console.ReadKey();
                        break;
                }
            }
        }

        
        public void CreateNewBadge()
        {
            Console.Clear();
            Console.Write("Enter BadgeID: ");
            string aBadgeID = Console.ReadLine();

            
            Console.Write("List Out All Needed Access Doors (i.e. A1,A3,A4): ");
            string list = Console.ReadLine();
            string[] words = list.Split(',');

            List<string> _doorList = new List<string>();
            foreach (string door in words)
            {
                _doorList.Add(door);
            }

            Badge newBadge = new Badge(aBadgeID, _doorList);
            _repo.AddBadgeToDirectory(newBadge);
            Console.WriteLine("New badge was added.");
            Console.ReadLine();
            RunMenu();
        }



        public void UpdateBadge()
        {
            Console.Clear();
            Console.Write("What Is The Badge Number To Update? ");
            string aBadgeID = Console.ReadLine();

            Badge a = _repo.GetBadgeByID(aBadgeID);


            Console.Write($"Badge {a.BadgeID} has access to door(s) {a.DoorNames}\n");
            Console.WriteLine("What would you like to do:\n" +
                "1. Remove A Door From Badge\n" +
                "2. Remove All Doors From Badge\n" +
                "3. Add A Door To Badge");
            string response = Console.ReadLine();

            switch (response)
            {
                case "1":
                    RemoveDoor(a);
                    Console.ReadKey();
                    break;
                case "2":
                    RemoveAllDoors(a);
                    Console.ReadKey();
                    break;
                case "3":
                    AddADoor(a);
                    Console.ReadKey();
                    break;
                default:
                    Console.WriteLine("Error");
                    Console.ReadKey();
                    break;
            }

        }
        public void RemoveDoor(Badge item)
        {
            Console.Write("Which Door To Remove: ");
            string door = Console.ReadLine();

            item.DoorNames.Remove(door);
            Console.WriteLine($"Door {door} has been removed");
            Console.ReadKey();
            Console.WriteLine($"Badge {item.BadgeID} has access to door(s) {String.Join(", ", item.DoorNames)}");
            Console.ReadKey();
            RunMenu();

        }
        public void RemoveAllDoors(Badge item)
        {
            Console.WriteLine($"Are You Sure You Want To Clear All Doors From Badge {item.BadgeID}?\n");
            Console.Write("Enter Yes or No: ");
            string answer = Console.ReadLine();

            if (answer == "Yes" || answer == "yes" || answer == "y")
            {
                item.DoorNames.Clear();
                Console.WriteLine($"Badge {item.BadgeID} Is No Longer Assigned To Any Doors.");
                Console.ReadKey();
                RunMenu();
            }
            else
            {
                RunMenu();
            }
        }
        public void AddADoor(Badge item)
        {
            Console.WriteLine($"What Door(s) Would You Like To Add To Badge {item.BadgeID}?\n");
            Console.Write("List Out All Needed Access Doors (i.e. A1,A3,A4): ");
            string list = Console.ReadLine();
            string[] words = list.Split(',');

            List<string> _doorList2 = new List<string>();
            foreach (string door in words)
            {
                _doorList2.Add(door);
            }
            Badge newBadge1 = new Badge(item.BadgeID, _doorList2);
            _repo.UpdateBadgeByID(item.BadgeID, newBadge1);

            Console.Write($"Badge {item.BadgeID} has access to door(s) {item.DoorNames}\n");
            RunMenu();
        }


        public void PrintAllBadges()
        {
            Console.Clear();
            List<Badge> listOfBadges = _repo.GetBadgeList();

            Console.WriteLine($"\n {"Badge#",-20}  {"Door Access",-30}\n");
            foreach (var line in listOfBadges)
            {
                DisplayContent(line);
            }
            Console.ReadLine();
            RunMenu();
        }
        public void DisplayContent(Badge item)
        {
            Console.WriteLine($"{item.BadgeID,-20} {String.Join(", ", item.DoorNames),-30}\n");

        }

    }
}
