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
            await logic.CreatePlayer("John", "Doe", true, 123);

            // Assert
            Assert.AreEqual(1, fakeData.InsertedPlayers.Count);
            var inserted = fakeData.InsertedPlayers[0];
            Assert.AreEqual("John", inserted.firstName);
            Assert.AreEqual("Doe", inserted.lastName);
            Assert.AreEqual(true, inserted.gender);
            Assert.AreEqual(123, inserted.federationNumber);
        }

        [TestMethod]
        public async Task FetchPlayersAsync_ReturnsExpectedList()
        {
            // Arrange
            var fakeData = new FakePlayerData();
            fakeData.SetPlayers(new List<DTOPlayers>
            {
                new DTOPlayers { ID = 1, FirstName = "A", LastName = "B", Gender = true, FederationNumber = 10 }
            });

            var logic = new PlayerLogic(fakeData);

            // Act
            var result = await logic.FetchPlayersAsync();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("A", result[0].FirstName);
        }
    }
}
