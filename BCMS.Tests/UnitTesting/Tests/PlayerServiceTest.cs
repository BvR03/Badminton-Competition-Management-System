using Microsoft.VisualStudio.TestTools.UnitTesting;
using LogicLayer;
using InterfaceLayer;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BCMS.Tests
{
    [TestClass]
    public class PlayerServiceTest
    {
        [TestMethod]
        public async Task CreatePlayerTest()
        {
            // Arrange
            var fakeData = new FakePlayerRepo();
            var logic = new PlayerService(fakeData);
            string firstname = "Estelle";
            string lastname = "van Leeuwen";
            bool IsMale = false;
            int FederationNumber = 120_950;

            // Act
            await logic.CreatePlayer(firstname, lastname, IsMale, FederationNumber);

            // Assert
            Assert.AreEqual(1, fakeData.InsertedPlayers.Count);
            var inserted = fakeData.InsertedPlayers[0];
            Assert.AreEqual("Estellx", inserted.firstName);
            Assert.AreEqual("van Leeuwen", inserted.lastName);
            Assert.AreEqual(false, inserted.gender);
            Assert.AreEqual(120950, inserted.federationNumber);
        }

        [TestMethod]
        public async Task FetchPlayersAsyncTest()
        {
            // Arrange
            var fakeData = new FakePlayerRepo();
            fakeData.SetPlayers(new List<PlayersDTO>
            {
                new PlayersDTO { ID = 1, FirstName = "Euan", LastName = "Scivier", Gender = true, FederationNumber = 10 }
            });

            var logic = new PlayerService(fakeData);

            // Act
            var result = await logic.FetchPlayersAsync();

            // Assert
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Euan", result[0].FirstName);
        }
    }
}
