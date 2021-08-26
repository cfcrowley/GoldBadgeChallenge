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



        //Create
        public void AddToClaims(Claim claim)
        {
            _claims.Add(claim);
        }

        //Read
        public List<Claim> GetAllClaims()
        {
            List<Claim> allClaims = new List<Claim>();
            foreach(Claim c in _claims)
            {
                allClaims.Add(c);
            }
            return allClaims;
        }

        public void DeleteOurItems(Claim badClaim)
        {
            _claims.Remove(badClaim);
        }
        // didn't use this and directions didn't call for one, but always handy to  have around



    }
}
