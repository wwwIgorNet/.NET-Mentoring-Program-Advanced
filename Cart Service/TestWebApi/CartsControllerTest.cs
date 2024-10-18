using AutoMapper;
using Microsoft.Extensions.Logging;
using Moq;
using OnlineShopping.CartService.WebApi.BLL;
using OnlineShopping.CartService.WebApi.UI.Controllers;

namespace TestWebApi
{
    [TestFixture]
    internal class CartsControllerTest
    {
        [Test]
        public async Task DeleiteMethdTest()
        {
            // Arrange
            var mockCartItemsService = new Mock<ICartItemsService>();
            mockCartItemsService.Setup(service => service.Delete(It.IsAny<int>()))
                .Returns(true);

            var controller = new CartsController(Mock.Of<ILogger<CartsController>>()
                , mockCartItemsService.Object
                , Mock.Of<IMapper>());

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.True(result);
        }
    }
}
