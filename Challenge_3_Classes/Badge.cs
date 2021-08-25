using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3_Classes
{
    public class Outing
    {
        public EventType EventType { get; set; }
        public DateTime Date { get; set; }
        public double PeopleAttend { get; set; }
        public double CostOfEvent { get; set; }
        public double CostPerPerson
        {
            get
            {
                double costs = CostOfEvent / PeopleAttend;
                return costs;
            }
        }
        
    }

    public enum EventType { Golf = 1, Bowling, AmusementPark, Concert }
}
