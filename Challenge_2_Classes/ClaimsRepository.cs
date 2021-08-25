using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2_Classes
{
    public class ClaimsRepository
    {
        private readonly List<Claim> _claims = new List<Claim>();




        public void AddToClaims(Claim claim)
        {
            _claims.Add(claim);
        }
        public List<Claim> GetOurClaims()
        {
            return _claims;
        }

        public void DeleteOurItems(Claim badClaim)
        {
            _claims.Remove(badClaim);
        }
        // didn't use this and directions didn't call for one, but always handy to  have around



    }
}
