using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_3_Classes
{
    public class OutingRepository
    {
        private readonly List<Outing> _outing = new List<Outing>();

        public void AddToList(Outing party)
        {
            _outing.Add(party);
        }

        public List<Outing> GetAllOutings()
        {
            List<Outing> allOutings = new List<Outing>();
            foreach(Outing o in _outing)
            {
                allOutings.Add(o);
            }
            return allOutings;
        }

        public Outing GetOutingByEventType(EventType eventType)
        {

            foreach (Outing o in _outing) 
            {
                if(o.EventType == eventType)
                {
                    return o;
                }
            }
            return null;
        }

        public bool UpdateExistingOuting(EventType eventType, Outing outing)
        {
            Outing partA = GetOutingByEventType(eventType);

            if (partA != null)
            {
                partA.EventType = outing.EventType;
                partA.Date = outing.Date;
                partA.PeopleAttend = outing.PeopleAttend;
                partA.CostOfEvent = outing.PeopleAttend;

                return true;
            }

            return false;
        }
    }
}
