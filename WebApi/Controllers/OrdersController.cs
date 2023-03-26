using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class OrdersController : ControllerBase
{
    private IOrderLogic orderLogic;

    public OrdersController(IOrderLogic orderLogic)
    {
        this.orderLogic = orderLogic;
    }

    [HttpPost]
    public async Task<ActionResult<Order>> CreateAsync([FromBody] OrderCreationDto dto)
    {
        try
        {
            Order order = await orderLogic.CreateAsync(dto);
            return Created($"/orders/{order.Id}", order);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            throw new Exception(e.Message);
        }
    }
}