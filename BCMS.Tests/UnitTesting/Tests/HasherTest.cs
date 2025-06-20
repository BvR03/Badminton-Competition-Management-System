using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BCMS.Tests.UnitTesting.Tests
{
    [TestClass]
    public class HasherTest
    {
        [TestMethod]
        public void HashTest()
        {
            //Arrange
            string Password = "ThisIsAPassword";
            string ExpectedResult = "4ad371ae554684864912df9d54f410f8ba2331fced604363a8271eef116f6def";
            //Act
            var result = LogicLayer.Hasher.Hash(Password);
            //Assert
            Assert.IsNotNull(result);
            Assert.AreEqual(result, ExpectedResult);
        }
    }
}
