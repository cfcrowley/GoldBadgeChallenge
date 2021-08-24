using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_2_Classes
{
    public class Claim
    {
        public int ClaimID { get; set; }
        public ClaimType ClaimType { get; set; }
        public string Description { get; set; }
        public double DamageCost { get; set; }
        public DateTimeOffset DateOfAccident { get; set; }
        public DateTimeOffset DateOfClaim { get; set; }
     
        
        public bool IsValid { get
            {
                TimeSpan timeFromAccident = DateOfClaim - DateOfAccident;
                if(timeFromAccident.Days >= 30)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

    }

    public enum ClaimType { Car, Home, Theft }
}
