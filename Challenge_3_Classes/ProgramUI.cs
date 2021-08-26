using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3_Classes
{
    public class ProgramUI
    {
        protected readonly OutingRepository _ourParties = new OutingRepository();
        public void Run()
        {
            SeedContent();
            Menu();
        }

        public void SeedContent()
        {
         
            DateTime bowling = new DateTime(2021, 04, 21);
            DateTime golf = new DateTime(2021, 05, 13);
            DateTime concert = new DateTime(2021, 07, 04);
            DateTime amusement = new DateTime(2021, 08, 21);
            Outing bowlingParty = new Outing(EventType.Bowling, bowling, 120, 2000);
            Outing golfParty = new Outing(EventType.Golf, golf, 300, 3500);
            Outing privateConcert = new Outing(EventType.Concert, concert, 400, 5000);
            Outing amuseParty = new Outing(EventType.AmusementPark, amusement, 200, 4500);

            _ourParties.AddToList(bowlingParty);
            _ourParties.AddToList(golfParty);
            _ourParties.AddToList(privateConcert);
            _ourParties.AddToList(amuseParty);

            Console.WriteLine("Come see where we spend all of our party budget!");
            Console.ReadLine();
        }

        public void Menu()
        {
            Console.Clear();
            bool keepRunning = true;

            while (keepRunning)
            {
                Console.WriteLine("Main Menu\n" + "1. See Our Events\n" + "2. Add an Event\n" + "3.Breakdown of Expenditures\n" + "4.Update an Event\n" + "5.Exit\n");
                string yourInput = Console.ReadLine();
                switch (yourInput)
                {
                    case "1":
                    case "one":
                    case "ONE":
                    case "One":
                        SeeOurEvents();
                        break;
                    case "2":
                    case "two":
                    case "Two":
                    case "TWO":
                        AddAnEvent();
                        break;
                    case "3":
                    case "Three":
                    case "three":
                    case "THREE":
                        SeeOurExpenditures();
                        break;
                    case "4":
                    case "four":
                    case "FOUR":
                    case "Four":
                        UpdateAnEvent();
                        break;
                    case "5":
                    case "five":
                    case "Five":
                    case "FIVE":
                        keepRunning = false;
                        break;
                }
            }
        }

        public void SeeOurEvents()
        {
            Console.Clear();
            List<Outing> outings = _ourParties.GetAllOutings();

            foreach(Outing outing in outings)
            {
                DisplayOuting(outing);
            }
        }

        public void DisplayOuting(Outing outing)
        {
            Console.WriteLine($"{outing.EventType} {outing.Date} {outing.PeopleAttend} {outing.CostOfEvent} {outing.CostPerPerson}");
        }

        public void AddAnEvent()
        {
            Console.Clear();
            Outing outing = new Outing();

            Console.WriteLine("1. Golf\n" + "2.Bowling\n" + "3. AmusementPark\n" + "4.Concert\n");
            Console.Write("Event Type (#): ");
            string outingInput = Console.ReadLine();
            int outingType = int.Parse(outingInput);
            outing.EventType = (EventType)outingType;

            Console.WriteLine("When was the event? (in YYYY, MM, DD format please)");
            string partyDate = Console.ReadLine();
            DateTime partyTime = Convert.ToDateTime(partyDate);
            outing.Date = partyTime;

            Console.WriteLine("How many people attended?");
            string partyPeople = Console.ReadLine();
            double actualPeople = Convert.ToDouble(partyPeople);
            outing.PeopleAttend = actualPeople;

            Console.WriteLine("How much did we use on this party");
            string partyCost = Console.ReadLine();
            double actualCost = Convert.ToDouble(partyCost);
            outing.CostOfEvent = actualCost;
        }

        public void SeeOurExpenditures()
        {
            DateTime bowling = new DateTime(2021, 04, 21);
            DateTime golf = new DateTime(2021, 05, 13);
            DateTime concert = new DateTime(2021, 07, 04);
            DateTime amusement = new DateTime(2021, 08, 21);
            Outing bowlingParty = new Outing(EventType.Bowling, bowling, 120, 2000);
            Outing golfParty = new Outing(EventType.Golf, golf, 300, 3500);
            Outing privateConcert = new Outing(EventType.Concert, concert, 400, 5000);
            Outing amuseParty = new Outing(EventType.AmusementPark, amusement, 200, 4500);
            double totalCost = bowlingParty.CostOfEvent + golfParty.CostOfEvent + privateConcert.CostOfEvent + amuseParty.CostOfEvent;

            Console.WriteLine($"The total cost of all parties is {totalCost}");
            Console.WriteLine($"The cost of bowling parties is {bowlingParty.CostOfEvent}");
            Console.WriteLine($"The cost of the golf outings is {golfParty.CostOfEvent}");
            Console.WriteLine($"The cost of the Amusement Park outings is {amuseParty.CostOfEvent}");
            Console.WriteLine($"The cost of the concert {privateConcert.CostOfEvent}");
           
        }

        public void UpdateAnEvent()
        {
            Console.WriteLine("How much did the event cost before that you wish to update?");
            string moneyPlease = Console.ReadLine();
            double monies = Convert.ToDouble(moneyPlease);
            Outing outing = _ourParties.GetOutingByCost(monies);
            Console.WriteLine("1. Golf\n" + "2.Bowling\n" + "3. AmusementPark\n" + "4.Concert\n");
            Console.Write("Event Type (#): ");
            string outingInput = Console.ReadLine();
            int outingType = int.Parse(outingInput);
            outing.EventType = (EventType)outingType;

            Console.WriteLine("When was the event? (in YYYY, MM, DD format please)");
            string partyDate = Console.ReadLine();
            DateTime partyTime = Convert.ToDateTime(partyDate);
            outing.Date = partyTime;

            Console.WriteLine("How many people attended?");
            string partyPeople = Console.ReadLine();
            double actualPeople = Convert.ToDouble(partyPeople);
            outing.PeopleAttend = actualPeople;

            Console.WriteLine("How much did we use on this party");
            string partyCost = Console.ReadLine();
            double actualCost = Convert.ToDouble(partyCost);
            outing.CostOfEvent = actualCost;

            _ourParties.UpdateExistingOuting(monies, outing);
        }

    }
}
