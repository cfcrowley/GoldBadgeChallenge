using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2_Classes
{
    public class ProgramUI
    {
        protected readonly ClaimsRepository _ourClaims = new ClaimsRepository();
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
                Console.WriteLine("Main Menu\n" + "1. See our Claims\n" + "2. Access the claims Queue\n" + "3. Add a new Claim\n" + "4. Exit the App");
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
            Console.Clear();
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

            Console.WriteLine("Please assign a claim ID from 4-100");
            string claimNumber = Console.ReadLine();
            int claimNum = int.Parse(claimNumber);
            if(claimNum > 3)
            {
                claim.ClaimID = claimNum;
            }
            else
            {
                Console.WriteLine("Please assign a number from 4-100");
            }

            Console.WriteLine("1. Car\n" + "2. Home\n" + "3. Theft\n");
            Console.Write("Claim Tpye (#): ");
            string claimInput = Console.ReadLine();
            int claimType = int.Parse(claimInput);
            claim.ClaimType = (ClaimType)claimType;

            Console.WriteLine("Please describe the incident");
            claim.Description = Console.ReadLine();

            Console.WriteLine("How much will it cost to remedy the situation?");
            string damageNumber = Console.ReadLine();
            double actualDamage = Convert.ToDouble(damageNumber);
            claim.DamageCost = actualDamage;

            Console.WriteLine("When did the incident occur? (please use the YYYY, MM, DD format");
            string accidentDate = Console.ReadLine();
            DateTime accDate = Convert.ToDateTime(accidentDate);
            claim.DateOfAccident = accDate;

            Console.WriteLine("When was the claim filed? (please use the YYYY, MM, DD format");
            string accidentDate2 = Console.ReadLine();
            DateTime accDate2 = Convert.ToDateTime(accidentDate2);
            claim.DateOfClaim = accDate2;

            _ourClaims.AddToClaims(claim);

        }

        public void AccessQueue()
        {
            Console.Clear();

            DateTime accident = new DateTime(2018, 4, 25);
            DateTime claimFiled = new DateTime(2018, 4, 27);
            Claim highwayOops = new Claim(1, ClaimType.Car, "Car accident on 465", 400.00, accident, claimFiled);
            DateTime accident2 = new DateTime(2018, 4, 11);
            DateTime claimFiled2 = new DateTime(2018, 4, 12);
            Claim houseOops = new Claim(2, ClaimType.Home, "House fire in kitchen", 4000.00, accident2, claimFiled2);
            DateTime accident3 = new DateTime(2018, 4, 27);
            DateTime claimFiled3 = new DateTime(2018, 6, 01);
            Claim myBreakfast = new Claim(3, ClaimType.Theft, "Stolen pancakes", 4.00, accident3, claimFiled3);

            Claim[] claims = new Claim[3];
            claims[0] = highwayOops;
            claims[1] = houseOops;
            claims[2] = myBreakfast;

            Queue<Claim> claimsQueue = new Queue<Claim>();

            foreach(Claim claim in claims)
            {
                claimsQueue.Enqueue(claim);
            }

            Console.WriteLine("the first claim in the queue is : {0}", claimsQueue.Peek());
            Console.WriteLine("Do you want to deal with this claim now(y/n)?");
            string yourInput = Console.ReadLine();
            switch (yourInput)
            {
                case "Y":
                case "y":
                case "yes":
                case "YES":
                case "Yes":
                    Console.WriteLine("You've processed the claim");
                    claimsQueue.Dequeue();
                    break;
                case "N":
                case "n":
                case "No":
                case "NO":
                    break;
            }
        }
    }
}
