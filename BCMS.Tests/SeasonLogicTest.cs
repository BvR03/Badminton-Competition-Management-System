using LogicLayer;
using InterfaceLayer;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Threading.Tasks;

namespace BCMS.Tests
{
    [TestClass]
    public class SeasonLogicTest
    {
        [TestMethod]
        public async Task CreateSeason_StoresCorrectValuesInFake()
        {
            // Arrange
            var fakeData = new FakeSeasonData();
            var logic = new SeasonLogic(fakeData);
            string name = "Season 2026/2027";
            DateTime start = new DateTime(2025, 1, 1);
            DateTime end = new DateTime(2025, 3, 31);

            // Act
            await logic.AddSeasonAsync(name, start, end);

            // Assert
            Assert.AreEqual(1, fakeData.CreatedSeasons.Count);
            var inserted = fakeData.CreatedSeasons[0];
            Assert.AreEqual(name, inserted.Name);
            Assert.AreEqual(start, inserted.StartDate);
            Assert.AreEqual(end, inserted.EndDate);
        }
    }
}

