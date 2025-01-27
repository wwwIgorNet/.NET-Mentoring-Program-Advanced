using System.Linq.Expressions;
using AutoMapper;
using LiteDB;
using Microsoft.AspNetCore.Mvc;
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
            var cartId = $"{Guid.NewGuid()}";
            var cartItemId = 3;
            var mockCartItemsService = new Mock<ICartItemsService>();
            mockCartItemsService.Setup(service => service.Delete(It.IsAny<int>()))
                .Returns(true);
            mockCartItemsService.Setup(service => service.FindItem(It.IsAny<string>(), It.IsAny<int>()))
                .Returns(new CartItem { Id = cartItemId, CartId = cartId, Name ="Test", Price = 33 });

            var controller = new CartItemsController(mockCartItemsService.Object
                , Mock.Of<IMapper>());

            // Act
            var result = controller.Delete(cartId, cartItemId);
            var okResult = result as OkResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }


        [Test]
        public void DeleiteMethd_Integration_Test()
        {
            // Arrange
            var cartId = $"{Guid.NewGuid()}";
            var cartItemId = 3;
            var mockLiteCollection = new Mock<ILiteCollection<CartItem>>();
            mockLiteCollection.Setup(x => x.Delete(It.IsAny<BsonValue>()))
                .Returns(true);
            mockLiteCollection.Setup(x => x.Find(It.IsAny<Expression<Func<CartItem, bool>>>(), It.IsAny<int>(), It.IsAny<int>()))
                .Returns([new CartItem { Id = cartItemId, CartId = cartId, Name = "Test", Price = 33 }]);
            var mockLiteDatabase = new Mock<ILiteDatabase>();
            mockLiteDatabase.Setup(x => x.GetCollection<CartItem>(It.IsAny<string>(), It.IsAny<BsonAutoId>()))
                .Returns(mockLiteCollection.Object);

            var mockLiteDbContext = new Mock<ILiteDbContext>();
            mockLiteDbContext.Setup(c => c.Database)
                .Returns(mockLiteDatabase.Object);
            var cardRepository = new CartItemsRepository(mockLiteDbContext.Object);
            var cartItemsService = new CartItemsService(cardRepository);

            var controller = new CartItemsController(cartItemsService
                , Mock.Of<IMapper>());

            // Act
            var result = controller.Delete(cartId, cartItemId);
            var okResult = result as OkResult;

            // Assert
            Assert.IsNotNull(okResult);
            Assert.That(okResult.StatusCode, Is.EqualTo(200));
        }
    }
}
