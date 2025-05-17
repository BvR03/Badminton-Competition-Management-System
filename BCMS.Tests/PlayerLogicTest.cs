using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using InterfaceLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BCMS.Tests
{
    [TestClass]
    public class PlayerLogicTests
    {
        [TestMethod]
        public async Task CreatePlayer_StoresCorrectValuesInFake()
        {
            // Arrange
            var fakeData = new FakePlayerData();
            var logic = new PlayerLogic(fakeData);

            // Act
            await logic.CreatePlayer("Estelle", "van Leeuwen", false, 120950);

            // Assert
            Assert.AreEqual(1, fakeData.InsertedPlayers.Count);
            var inserted = fakeData.InsertedPlayers[0];
            Assert.AreEqual("Estelle", inserted.firstName);
            Assert.AreEqual("van Leeuwen", inserted.lastName);
            Assert.AreEqual(false, inserted.gender);
            Assert.AreEqual(120950, inserted.federationNumber);
        }

        [TestMethod]
        public async Task FetchPlayersAsync_ReturnsExpectedList()
        {
            // Arrange
            var fakeData = new FakePlayerData();
            fakeData.SetPlayers(new List<DTOPlayers>
            {
                new DTOPlayers { ID = 1, FirstName = "Euan", LastName = "Scivier", Gender = true, FederationNumber = 10 }
            });

            var logic = new PlayerLogic(fakeData);

            // Act
            var result = await logic.FetchPlayersAsync();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Euan", result[0].FirstName);
        }
    }
}
