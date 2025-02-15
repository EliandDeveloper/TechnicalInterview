using Xunit;
using Moq;
using Microsoft.AspNetCore.Mvc;
using Technical.Api.Controllers;
using Technical.Application.Contracts;
using Technical.Application.Dtos.Products;
using Technical.Application.Core;
using System.Collections.Generic;

public class ProductsControllerTests
{
    private readonly Mock<IProductsService> _mockService;
    private readonly ProductsController _controller;

    public ProductsControllerTests()
    {
        _mockService = new Mock<IProductsService>();
        _controller = new ProductsController(_mockService.Object);
    }

    [Fact]
    public void Get_ReturnsOkResult_WhenSuccess()
    {
        // Arrange
        var expectedResponse = new ServiceResult { Success = true };
        _mockService.Setup(s => s.GetAll()).Returns(expectedResponse);

        // Act
        var result = _controller.Get();

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedResponse, okResult.Value);
    }

    [Fact]
    public void Post_ReturnsOkResult_WhenSuccess()
    {
        // Arrange
        var dto = new ProductsDtoAdd();
        var expectedResponse = new ServiceResult { Success = true };
        _mockService.Setup(s => s.Save(dto)).Returns(expectedResponse);

        // Act
        var result = _controller.Post(dto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedResponse, okResult.Value);
    }

    [Fact]
    public void Put_ReturnsOkResult_WhenSuccess()
    {
        // Arrange
        var dto = new ProductsDtoUpdate();
        var expectedResponse = new ServiceResult { Success = true };
        _mockService.Setup(s => s.Update(dto)).Returns(expectedResponse);

        // Act
        var result = _controller.Put(dto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedResponse, okResult.Value);
    }

    [Fact]
    public void Remove_ReturnsOkResult_WhenSuccess()
    {
        // Arrange
        var dto = new ProductsDtoRemove();
        var expectedResponse = new ServiceResult { Success = true };
        _mockService.Setup(s => s.Remove(dto)).Returns(expectedResponse);

        // Act
        var result = _controller.Remove(dto);

        // Assert
        var okResult = Assert.IsType<OkObjectResult>(result);
        Assert.Equal(expectedResponse, okResult.Value);
    }
}
