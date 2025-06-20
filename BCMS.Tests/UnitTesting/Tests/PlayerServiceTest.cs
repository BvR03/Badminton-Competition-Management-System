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
            string Email = null;


            // Act
            await logic.CreatePlayer(firstname, lastname, IsMale, FederationNumber, Email);

            // Assert
            Assert.AreEqual(1, fakeData.InsertedPlayers.Count);
            var inserted = fakeData.InsertedPlayers[0];
            Assert.AreEqual("Estelle", inserted.firstName);
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

        [TestMethod]
        public async Task FetchPlayerByFederationNumberAsyncTest()
        {
            // Arrange
            var fakeData = new FakePlayerRepo();
            var expectedPlayer = new PlayersDTO
            {
                ID = 1,
                FirstName = "Calumn",
                LastName = "Hemming",
                Gender = true,
                FederationNumber = 123_456
            };
            fakeData.SetPlayers(new List<PlayersDTO> { expectedPlayer });
            var logic = new PlayerService(fakeData);

            // Act
            var result = await logic.FetchPlayerByFederationNumberAsync(555_555);

            // Assert
            Assert.IsNotNull(result);
            Assert.AreEqual("Calumn", result.FirstName);
            Assert.AreEqual("Hemming", result.LastName);
            Assert.AreEqual(true, result.Gender);
            Assert.AreEqual(123_456, result.FederationNumber);
        }
    }
}
