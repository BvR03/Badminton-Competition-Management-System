using LogicLayer;
using InterfaceLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace BCMS.Tests
{
    [TestClass]
    public class SeasonServiceTest
    {
        [TestMethod]
        public async Task CreateSeasonTest()
        {
            // Arrange
            var fakeData = new FakeSeasonRepo();
            var logic = new SeasonService(fakeData);
            string name = "Season 2026/2027";
            DateTime startdate = new DateTime(2025, 1, 1);
            DateTime enddate = new DateTime(2025, 3, 31);

            // Act
            await logic.AddSeasonAsync(name, startdate, enddate);

            // Assert
            Assert.AreEqual(1, fakeData.CreatedSeasons.Count);
            var inserted = fakeData.CreatedSeasons[0];
            Assert.AreEqual(name, inserted.Name);
            Assert.AreEqual(startdate, inserted.StartDate);
            Assert.AreEqual(enddate, inserted.EndDate);
        }
    }
}

