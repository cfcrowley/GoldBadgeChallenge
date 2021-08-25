using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2_Classes
{
    public class ClaimsRepository
    {
        protected readonly List<Claim> _claims = new List<Claim>();




        public void AddToClaims(Claim claim)
        {
            _claims.Add(claim);
        }

        public void DeleteOurItems(Claim badClaim)
        {
            _claims.Remove(badClaim);
        }

    }
}
