using KomodoClaims.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;

namespace KomodoClaims
{
    class ProgramUI
    {
        private ClaimRepo _repo = new ClaimRepo();
        private List<Claim> newList;
        public void Run()
        {
            SeedClaimList();
            RunMenu();
        }

        private void RunMenu()
        {
            bool continueToRun = true;
            while (continueToRun)
            {
                Console.Clear();

                Console.WriteLine("Enter the number of your selection: \n" +
                    "1. See All Claims\n" +
                    "2. Take Care Of Next Claim\n" +
                    "3. Enter A New Claim\n" +
                    "4. Exit"
                    );

                string selection = Console.ReadLine();

                switch (selection)
                {
                    case "1":
                        PrintAllClaims();
                        Console.ReadKey();
                        break;
                    case "2":
                        NextClaim();
                        Console.ReadKey();
                        break;
                    case "3":
                        CreateNewClaim();
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

        
        // prompt 1 (Show a claims agent menu)
        public void PrintAllClaims()
        {
            Console.Clear();
            List<Claim> listOfClaims = _repo.GetContents();

            Console.WriteLine($"\n {"ClaimID",-20}  {"Type",-30} {"Description",-30} {"Amount",-30} {"DateOfIncident",-30}{"DateOfClaim",-30} {"IsValid",-30}\n");
            foreach (Claim line in listOfClaims)
            {
                DisplayContent(line);
            }
        }
        public void DisplayContent(Claim item)
        {
            Console.WriteLine($"{item.ClaimID,-20} {item.Type,-30} {item.Description,-30} {item.ClaimAmount,-30}{item.DateOfIncident,-30}{item.DateOfClaim,-30}{item.IsValid,-30}\n");
        }

        // pt 2 of prompt (For #2, when a claims agent needs to deal with an item they see the next item in the queue.)
        public void NextClaim()
        {
            newList = _repo.GetContents();

            Claim item1 = newList.FirstOrDefault();

            Console.WriteLine("Here are the details for the next claim to be handled: \n" +
                $"ClaimID: {item1.ClaimID} \n" +
                $"Incident Type: {item1.Type} \n" +
                $"Description: {item1.Description} \n" +
                $"Amount: {item1.ClaimAmount} \n" +
                $"DateOfAccident: {item1.DateOfIncident} \n" +
                $"DateOfClaim: {item1.DateOfClaim} \n" +
                $"IsValid: {item1.IsValid}\n");

            Console.Write("Do you want to deal with this claim now(y/n)? ");
            string answer = Console.ReadLine();
            if (answer == "y" || answer == "yes")
            {
                _repo.RemoveClaimByID(item1.ClaimID);
            }
            else
            {
                RunMenu();
            }

        }

        // pt 3 of prompt

        public void CreateNewClaim()
        {
            Console.Clear();
            Console.Write("Enter ClaimID: ");
            string claimID = Console.ReadLine();

            Console.Write("Enter a Claim Type (CarAccident, CarBurglary, HomeFire, HomeBurglary, or CustomerInjury: ");
            string type = Console.ReadLine();
            ClaimType Type = ClaimType.CarAccident;
            if (type == "CarAccident")
            {
                Type = ClaimType.CarAccident;
            }
            else if (type == "CarBurglary")
            {
                Type = ClaimType.CarBurglary;
            }
            else if (type == "HomeFire")
            {
                Type = ClaimType.HomeFire;
            }
            else if (type == "HomeBurglary")
            {
                Type = ClaimType.HomeBurglary;
            }
            else if (type == "CustomerInjury")
            {
                Type = ClaimType.CustomerInjury;
            }
            else
            {
                Console.WriteLine("Not A Valid Entry");
                RunMenu();
            }

            Console.Write("Describe The Claim: ");
            string description = Console.ReadLine();

            Console.Write("Amount Of Damage in $: ");
            decimal claimAmount = Convert.ToDecimal(Console.ReadLine());

            Console.Write("Date of Incident (Year, month: ");
            DateTime dateOfIncident = Convert.ToDateTime(Console.ReadLine());

            Console.Write("Date of Claim, Must Be Within 60 Days of Incident(Year, Day, Month): ");
            DateTime dateOfClaim = Convert.ToDateTime(Console.ReadLine());
            int dateTest = Convert.ToInt32((dateOfClaim - dateOfIncident).TotalDays);
            if (dateTest > 30)
            {
                Console.WriteLine("We can not accept this claim, Komodo Insurance will not accept claims made outside of a 60day window.");
                Console.ReadKey();
                RunMenu();
            }

            Console.Write("By entering this claim, you are liabile for complete honesty in your report, Press Any Key To Continue...\n");
            Console.ReadKey();

            Claim newClaim = new Claim(claimID, Type, description, claimAmount, dateOfIncident, dateOfClaim, true);

            _repo.AddClaimToDirectory(newClaim);
            Console.WriteLine("New claim has been created.");
            Console.ReadLine();
            RunMenu();
        }

        private void SeedClaimList()
        {
            Claim Ashley = new Claim("460", ClaimType.HomeBurglary, "Stolen pancakes.", 1000.00m, new DateTime(2021, 01, 25), new DateTime(2021, 02, 05), true);    
            
            Claim Bob = new Claim("461", ClaimType.CustomerInjury, "My professor hit me with his car.", 1000.00m, new DateTime(2021, 02, 14), new DateTime(2021, 02, 18), true); 
            
            Claim Andrew = new Claim("462", ClaimType.HomeFire, "One of my students set my home on fire, and while I tried to back out of my driveway to save my car, I ran him over.", 1000.00m, new DateTime(2021, 02, 14), new DateTime(2021, 02, 18), true);

            _repo.AddClaimToDirectory(Ashley);
            _repo.AddClaimToDirectory(Bob);
            _repo.AddClaimToDirectory(Andrew);

        }



    }
}
