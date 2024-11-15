using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Routing;
using Moq;
using OnlineShopping.CatalogService.Application.Categories.Queries;
using WebApi.Controllers;

namespace WebApiTest;

public class CategoriesControllerTests
{
    [Test]
    public async Task DeleiteMethdTest()
    {
        var categoryId = 22;
        var categoryName = "New Category";
        // Arrange
        var mockSender = new Mock<ISender>();
        mockSender.Setup(service => service.Send(It.Is<GetCategoryCommand>(x => x.Id == categoryId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new CategoryDto { Name = categoryName, Id = categoryId });

        var mockController = new Mock<CategoriesController>();


        var controller = new CategoriesController(mockSender.Object);
        controller.ControllerContext = new ControllerContext()
        {
            HttpContext = new DefaultHttpContext(),
        };
        var mockUrlHelper = new Mock<IUrlHelper>(MockBehavior.Strict);
        mockUrlHelper.Setup(x => x.Action(It.IsAny<UrlActionContext>()))
            .Returns("Url")
            .Verifiable();
        controller.Url = mockUrlHelper.Object;

        // Act
        var result = await controller.Get(categoryId) as OkObjectResult;

        // Assert
        Assert.IsNotNull(result);
        Assert.IsNotNull(result.Value);
        Assert.That(result.StatusCode, Is.EqualTo(200));
    }
}