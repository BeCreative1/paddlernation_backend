using Application.LogicInterfaces;
using Domain;
using Domain.DTOs;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class CustomersController : ControllerBase
{
    private readonly ICustomerLogic customerLogic;

    public CustomersController(ICustomerLogic customerLogic)
    {
        this.customerLogic = customerLogic;
    }

    [HttpPost]
    public async Task<ActionResult<int>> CreateAsync(CustomerCreationDto dto)
    {
        try
        {
            var customerId = await customerLogic.CreateAsync(dto);
            return Ok(customerId);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }

    //TODO created just for tests - to delete later
    [HttpGet("{id:int}")]
    public async Task<ActionResult<Customer>> GetById([FromRoute] int id)
    {
        try
        {
            Customer? post = await customerLogic.GetByIdAsync(id);
            return Ok(post);
        }
        catch (Exception e)
        {
            Console.WriteLine(e);
            return StatusCode(500, e.Message);
        }
    }
}