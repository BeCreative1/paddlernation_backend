using Microsoft.Extensions.DependencyInjection;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Domain.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Controllers;
using Moq;
using Xunit;
using Assert = Xunit.Assert;

namespace xUnit.WebAPITests;

[TestClass]
public class OrdersControllerTests
{
    private readonly Mock<IOrderLogic> orderLogicMock;
    private readonly OrdersController orderController;

    public OrdersControllerTests()
    {
        orderLogicMock = new Mock<IOrderLogic>();
        orderLogicMock.Setup(x => x.CreateAsync(It.IsAny<OrderCreationDto>())).ReturnsAsync(new Order());

        orderController = new OrdersController(orderLogicMock.Object);
    }

    [TestMethod]
    public async Task CreateAsyncTest()
    {
        // Arrange
        var dto = new OrderCreationDto(120, 1, DateTime.Now, 1, 1, 1);
        var order = new Order {         
            Id = 1,
            TotalPrice = dto.TotalPrice,
            PaymentMethod = dto.PaymentMethod,
            CreatedAt = dto.CreatedAt,
            PaymentStage = dto.PaymentStage,
            Customer = new Customer(),
            DeliveryAddress = new DeliveryAddress()
        };
        
        orderLogicMock
            .Setup(x => x.CreateAsync(dto))
            .ReturnsAsync(order);
    
        // Act
        var response = await orderController.CreateAsync(dto);
    
        // Assert
        var createdResult = Assert.IsType<CreatedResult>(response.Result);
        var createdOrder = Assert.IsType<Order>(createdResult.Value);
        Assert.Equal(order, createdOrder);
        Assert.Equal($"/orders/{order.Id}", createdResult.Location);
    }

    [Fact]
    public async Task CreateAsync_WithInvalidOrderCreationDto_ThrowsException()
    {
        // Arrange
        var dto = new OrderCreationDto(120, 1, DateTime.Now, 1, 3, 3);
        orderLogicMock
            .Setup(x => x.CreateAsync(dto))
            .ThrowsAsync(new ArgumentException());

        // Act & Assert
        await Assert.ThrowsAsync<Exception>(() => orderController.CreateAsync(dto));
    }
}