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
            return _outing;
        }

    }
}
