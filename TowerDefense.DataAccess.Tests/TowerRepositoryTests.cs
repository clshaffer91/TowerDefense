using Microsoft.VisualStudio.TestTools.UnitTesting;
using TowerDefense.DataAccess;
using TowerDefense.Logic;
using System.Linq;

namespace TowerDefense.DataAccess.Tests
{
    //Integration Tests
    [TestClass]
    public class TowerRepositoryTests
    {
        [TestMethod]
        public void FetchList_TowerRepository_ReturnsList()
        {
            //Arrange
            var repo = new TowerRepository();

            //Act
            var towers = repo.FetchList();

            //Assert
            Assert.IsTrue(towers.Count() > 0);
        }
    }
}