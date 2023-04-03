using Application.LogicInterfaces;
using Domain;
using Domain.DTOs.Reservation;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers;

[ApiController]
[Route("[controller]")]
public class ReservationsController : ControllerBase
{
	private readonly IReservationLogic _logic;

	public ReservationsController(IReservationLogic logic)
	{
		_logic = logic;
	}

	[HttpGet("{id:int}")]
	public async Task<ActionResult<Reservation>> GetByIdAsync([FromRoute] string id)
	{
		try
		{
			ReservationDto reservation = await _logic.GetByIdAsync(id);

			return Ok(reservation);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}

	[HttpGet]
	public async Task<ActionResult<Reservation>> GetAsync()
	{
		try
		{
			IEnumerable<ReservationDto> reservations = await _logic.GetAsync();

			return Ok(reservations);
		}
		catch (Exception e)
		{
			Console.WriteLine(e);
			return StatusCode(500, e.Message);
		}
	}

	// [HttpPost]
	// public async Task<ActionResult<Reservation> CreateAsync()
	// {
	//
	// }
}
