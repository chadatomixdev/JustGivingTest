using JG.FinTechTest.API.Controllers;
using Microsoft.AspNetCore.Mvc;
using Xunit;

namespace JG.FinTechTest.UnitTests
{
    public class TestControllerUnitTests
    {
        TestController _testController;

        public TestControllerUnitTests()
        {
            _testController = new TestController();
        }

        [Fact]
        public void GetTestShouldReturnOkResult()
        {
            //Act
            var okResult = _testController.Test();

            // Assert
            Assert.IsType<OkResult>(okResult);
        }
    }
}