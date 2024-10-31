using AutoMapper;
using LiteDB;
using Microsoft.Extensions.Logging;
using Moq;
using OnlineShopping.CartService.WebApi.BLL;
using OnlineShopping.CartService.WebApi.DAL;
using OnlineShopping.CartService.WebApi.DAL.Entities;
using OnlineShopping.CartService.WebApi.UI.Controllers;

namespace TestWebApi
{
    [TestFixture]
    internal class CartItemsControllerTest
    {
        [Test]
        public void DeleiteMethdTest()
        {
            // Arrange
            var mockCartItemsService = new Mock<ICartItemsService>();
            mockCartItemsService.Setup(service => service.Delete(It.IsAny<int>()))
                .Returns(true);

            var controller = new CartItemsController(Mock.Of<ILogger<CartItemsController>>()
                , mockCartItemsService.Object
                , Mock.Of<IMapper>());

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.True(result);
        }


        [Test]
        public void DeleiteMethd_Integration_Test()
        {
            // Arrange
            var mockLiteCollection = new Mock<ILiteCollection<CartItem>>();
            mockLiteCollection.Setup(x => x.Delete(It.IsAny<BsonValue>()))
                .Returns(true);
            var mockLiteDatabase = new Mock<ILiteDatabase>();
            mockLiteDatabase.Setup(x => x.GetCollection<CartItem>(It.IsAny<string>(), It.IsAny<BsonAutoId>()))
                .Returns(mockLiteCollection.Object);

            var mockLiteDbContext = new Mock<ILiteDbContext>();
            mockLiteDbContext.Setup(c => c.Database)
                .Returns(mockLiteDatabase.Object);
            var cardRepository = new CartItemsRepository(mockLiteDbContext.Object);
            var cartItemsService = new CartItemsService(cardRepository);

            var controller = new CartItemsController(Mock.Of<ILogger<CartItemsController>>()
                , cartItemsService
                , Mock.Of<IMapper>());

            // Act
            var result = controller.Delete(1);

            // Assert
            Assert.True(result);
        }
    }
}
