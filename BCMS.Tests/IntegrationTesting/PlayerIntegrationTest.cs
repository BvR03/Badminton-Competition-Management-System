using System;
using System.Linq;
using System.Threading.Tasks;
using LogicLayer;
using DAL;
using InterfaceLayer;

namespace BCMS.Tests
{
    [TestClass]
    public class PlayerIntegrationTests
    {
        [TestMethod]
        public async Task CreatePlayerTest()
        {
            // Arrange
            bool runTest = true;
            if (!runTest)
            {
                Assert.Inconclusive("Test skipped because runTest was set to false.");
            }
            var playerRepo = new PlayerRepo();
            var playerService = new PlayerService(playerRepo);
            string firstName = "Integration";
            string lastName = "Tester";
            bool gender = true;
            int federationNumber = new Random().Next(1000000, 9999999);

            // Act
            
            await playerService.CreatePlayer(firstName, lastName, gender, federationNumber);            


            // Assert
            var allPlayers = await playerService.FetchPlayersAsync();
            var created = allPlayers.FirstOrDefault(p =>
                p.FirstName == firstName &&
                p.LastName == lastName &&
                p.Gender == gender &&
                p.FederationNumber == federationNumber);

            Assert.IsNotNull(created);
        }
    }
}