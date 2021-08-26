using System;
using System.Collections.Generic;
using Challenge_3_Classes;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Challenge_3_Tests
{
    [TestClass]
    public class OutingTest
    {
        private OutingRepository _parties;
        private Outing _outing;
        [TestInitialize]
        public void Arrange()
        {
            _parties = new OutingRepository();
            DateTime bowling = new DateTime(2021, 11, 05);
            _outing = new Outing(EventType.Bowling, bowling, 150, 3000);

            _parties.AddToList(_outing);

        }
        [TestMethod]
        public void AddContent_ShouldReturnEqual()
        {
            OutingRepository birthdays = new OutingRepository();
            DateTime kingsIsland = new DateTime(2021, 06, 22);
            Outing party = new Outing(EventType.AmusementPark, kingsIsland, 300, 7000);
            birthdays.AddToList(party);

            double expected = 7000;
            double actual = party.CostOfEvent;

            Assert.AreEqual(expected, actual);
        }

        [TestMethod]
        public void GetOuting_ShouldReturnTrue()
        {
            OutingRepository grandCanyon = new OutingRepository();
            DateTime ohReally = new DateTime(2021, 03, 29);
            Outing fieldTrip = new Outing(EventType.Concert, ohReally, 60, 3000);
            grandCanyon.AddToList(fieldTrip);
            List<Outing> workHere = grandCanyon.GetAllOutings();
            bool weHaveIt = workHere.Contains(fieldTrip);
            Assert.IsTrue(weHaveIt);
        }

        [TestMethod]
        public void UpdateExistingOuting_ShouldUpdate()
        {
           DateTime bowling = new DateTime(2019, 3, 21);
            Outing outing = new Outing(EventType.Bowling, bowling, 500, 4000);

            _parties.UpdateExistingOuting(EventType.Bowling, outing);

            var expected = 500;
            var actual = _outing.PeopleAttend;

            Assert.AreEqual(expected, actual);
        }
    }
}
