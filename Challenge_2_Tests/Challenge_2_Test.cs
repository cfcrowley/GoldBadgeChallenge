using System;
using System.Collections.Generic;
using Challenge_2_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_2_Tests
{
    [TestClass]
    public class Challenge_2_Test
    {
        private ClaimsRepository _claimLog;
        private Claim _sideSwipe;
        [TestInitialize]
        public void Arrange()
        {
            _claimLog = new ClaimsRepository();
            _sideSwipe = new Claim(1, ClaimType.Car, "someone hit my parked car", 2000, DateTime.Now, DateTime.Now);
            _claimLog.AddToClaims(_sideSwipe);
        }
        [TestMethod]
        public void AddToClaims_ShouldAddToList()
        {
            Claim fenderBender = new Claim(2, ClaimType.Car, "didn't look both ways at the roundabout", 350, DateTime.Now, DateTime.Now);
            ClaimsRepository claimFarm = new ClaimsRepository();
            claimFarm.AddToClaims(fenderBender);

            double expected = 350;
            double actual = fenderBender.DamageCost;

            Assert.AreEqual(expected, actual);
        }
        [TestMethod]
        public void GetOurClaims_ShouldReturnTrue()
        {
            Claim hugeDent = new Claim(5, ClaimType.Car, "golf ball hit the door and dented it", 500, DateTime.Now, DateTime.Now);
            ClaimsRepository typicalTuesday = new ClaimsRepository();
            typicalTuesday.AddToClaims(hugeDent);


            List<Claim> hugeDents = typicalTuesday.GetAllClaims();
            bool weHaveWork = hugeDents.Contains(hugeDent);
            Assert.IsTrue(weHaveWork);
        }
        [TestMethod]
        public void UpdateExistingContent_ShouldUpdate()
        {
            Claim newClaim = new Claim(1, ClaimType.Car, "things got worse", 4000, DateTime.Now, DateTime.Now);

            _claimLog.UpdateExistingClaim("someone hit my parked car", newClaim);

            var expected = "things got worse";
            var actual = _sideSwipe.Description;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void DeleteTheItems_ShouldReturnFalse()
        {
            Claim hugeDent = new Claim(5, ClaimType.Car, "golf ball hit the door and dented it", 500, DateTime.Now, DateTime.Now);
            ClaimsRepository typicalTuesday = new ClaimsRepository();
            typicalTuesday.AddToClaims(hugeDent);


            //
            typicalTuesday.DeleteOurItems(hugeDent);
            List<Claim> hugeDents = typicalTuesday.GetAllClaims();
            bool inOurSystem = hugeDents.Contains(hugeDent);
            Assert.IsFalse(inOurSystem);
        }
    }
}
