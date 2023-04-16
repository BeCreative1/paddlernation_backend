using Microsoft.Extensions.DependencyInjection;
using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using WebApi.Controllers;
using Moq;


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
        var dto = new OrderCreationDto(120, PaymentMethod.MobilePay, DateTime.Now,  PaymentStage.Paid, 1, 1);
        var order = new Order{         
            Id = 1,
            TotalPrice = dto.TotalPrice,
            PaymentMethod = dto.PaymentMethod,
            PaymentStage = dto.PaymentStage,
            OrderedBy = new Customer(),
            Delivery = new Delivery()
        };
        
        orderLogicMock
            .Setup(x => x.CreateAsync(dto))
            .ReturnsAsync(order);
    
        // Act
        var response = await orderController.CreateAsync(dto);
    
        
        var createdResult = response.Result as CreatedResult;
        Assert.IsNotNull(createdResult);
        var createdOrder = createdResult.Value as Order;
        Assert.IsNotNull(createdOrder);
        Assert.AreEqual(order, createdOrder);
        Assert.AreEqual($"/orders/{order.Id}", createdResult.Location);
    }

    [TestMethod]
    public async Task CreateAsync_WithInvalidOrderCreationDto_ThrowsException()
    {
        // Arrange
        var dto = new OrderCreationDto(120, PaymentMethod.CreditCard , DateTime.Now, PaymentStage.Paid, 3, 3);
        orderLogicMock
            .Setup(x => x.CreateAsync(dto))
            .ThrowsAsync(new ArgumentException());

        // Act & Assert
        await Assert.ThrowsExceptionAsync<Exception>(async () => await orderController.CreateAsync(dto));    }
}