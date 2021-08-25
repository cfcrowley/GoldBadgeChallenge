using System;
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
            _sideSwipe = new Claim(1, ClaimType.Car, "someone hit my parked car", 2000, DateTimeOffset.Now, DateTimeOffset.Now);
            _claimLog.AddToClaims(_sideSwipe);
        }
        [TestMethod]
        public void AddToClaims_ShouldAddToList()
        {
            Claim fenderBender = new Claim(2, ClaimType.Car, "didn't look both ways at the roundabout", 350, DateTimeOffset.Now, DateTimeOffset.Now);
            ClaimsRepository claimFarm = new ClaimsRepository();
            claimFarm.AddToClaims(fenderBender);

            double expected = 350;
            double actual = fenderBender.DamageCost;

            Assert.AreEqual(expected, actual);
        }
    }
}
