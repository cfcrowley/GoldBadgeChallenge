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
        public List<Claim> GetAllClaims()
        {
            List<Claim> allClaims = new List<Claim>();
            foreach(Claim c in _claims)
            {
                allClaims.Add(c);
            }
            return allClaims;
        }
        public Claim GetClaimByDescription(string description)
        {
            foreach (Claim c in _claims)
            {
                if (c.Description == description)
                {
                    return c;
                }
            }
            return null;
        }
        public bool UpdateExistingClaim(string originalClaim, Claim claim)
        {
            Claim oldClaim = GetClaimByDescription(originalClaim);
            if (oldClaim != null)
            {
                oldClaim.ClaimType = claim.ClaimType;
                oldClaim.ClaimID = claim.ClaimID;
                oldClaim.DamageCost = claim.DamageCost;
                oldClaim.Description = claim.Description;
                oldClaim.DateOfAccident = claim.DateOfAccident;
                oldClaim.DateOfClaim = claim.DateOfClaim;
                return true;
            }
            return false;
        }
        public void DeleteOurItems(Claim badClaim)
        {
            _claims.Remove(badClaim);
        }
        


    }
}
