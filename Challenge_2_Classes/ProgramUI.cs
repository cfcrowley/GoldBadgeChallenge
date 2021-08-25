using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2_Classes
{
    public class ProgramUI
    {
        private readonly ClaimsRepository _ourClaims = new ClaimsRepository();
        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
            DateTime accident = new DateTime(2018, 4, 25);
            DateTime claimFiled = new DateTime(2018, 4, 27);
            Claim highwayOops = new Claim(1,ClaimType.Car,"Car accident on 465" , 400.00, accident, claimFiled);
            DateTime accident2 = new DateTime(2018, 4, 11);
            DateTime claimFiled2 = new DateTime(2018, 4, 12);
            Claim houseOops = new Claim(2, ClaimType.Home, "House fire in kitchen", 4000.00, accident2, claimFiled2);
            DateTime accident3 = new DateTime(2018, 4, 27);
            DateTime claimFiled3 = new DateTime(2018, 6, 01);
            Claim myBreakfast = new Claim(3, ClaimType.Theft, "Stolen pancakes", 4.00, accident3, claimFiled3);

            _ourClaims.AddToClaims(highwayOops);
            _ourClaims.AddToClaims(houseOops);
            _ourClaims.AddToClaims(myBreakfast);

            Console.WriteLine("Welcome to our integrated insurance system... please tell me this isn't going to be expensive");
            Console.ReadLine();
        }

        public void Menu()
        {
            Console.Clear();
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Main Menu\n" + "1. See our Claims\n" + "2. Access the claims Queue" + "3. Add a new Claim\n" + "4. Exit the App");
                string yourInput = Console.ReadLine();
                switch (yourInput)
                {
                    case "1":
                    case "one":
                    case "ONE":
                    case "One":
                        SeeOurClaims();
                        break;
                    case "2":
                    case "two":
                    case "Two":
                    case "TWO":
                        AccessQueue();
                        break;
                    case "3":
                    case "Three":
                    case "three":
                    case "THREE":
                        AddNewClaim();
                        break;
                    case "4":
                    case "four":
                    case "FOUR":
                    case "Four":
                        keepRunning = false;
                        break;
                }
            }
        }

        public void SeeOurClaims()
        {
            List<Claim> claimItems = _ourClaims.GetOurClaims();

            foreach (Claim claimItem in claimItems)
            {
                DisplayClaim(claimItem);
            }
        }

        public void DisplayClaim(Claim claimItem)
        {
            Console.WriteLine($"{claimItem.ClaimID} {claimItem.ClaimType} {claimItem.Description} {claimItem.DamageCost} {claimItem.DateOfAccident} {claimItem.DateOfClaim} {claimItem.IsValid}");
        }

        private void AddNewClaim()
        {
            Console.Clear();
            Claim claim = new Claim();

        }
    }
}
