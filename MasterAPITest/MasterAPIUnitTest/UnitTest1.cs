using MasterAPITest.Controllers;

namespace MasterAPIUnitTest
{
    public class UnitTest1
    {
        [Fact]
        public void Test1()
        {
            var controller = new HomeController();

            Assert.Equal("success", controller.HomeTestAPI());

        }
    }
}