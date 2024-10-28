using MediatR;
using Microsoft.AspNetCore.Mvc;
using Moq;
using OnlineShopping.CatalogService.Application.Categories.Queries;
using WebApi.Controllers;

namespace WebApiTest;

public class Tests
{
    [Test]
    public void DeleiteMethdTest()
    {
        var categoryId = 22;
        var categoryName = "New Category";
        // Arrange
        var mockSender = new Mock<ISender>();
        mockSender.Setup(service => service.Send(It.Is<GetCategoryCommand>(x => x.Id == categoryId), It.IsAny<CancellationToken>()))
            .ReturnsAsync(new CategoryDto { Name = categoryName, Id = categoryId });

        var controller = new CategoriesController(mockSender.Object);

        // Act
        var result = controller.Get(new GetCategoryCommand(categoryId));

        var dto = (result.Result as OkObjectResult)?.Value as CategoryDto;
        // Assert
        Assert.That(dto, Is.Not.Null);
        Assert.That(dto.Id, Is.EqualTo(categoryId));
        Assert.That(dto.Name, Is.EqualTo(categoryName));
    }
}