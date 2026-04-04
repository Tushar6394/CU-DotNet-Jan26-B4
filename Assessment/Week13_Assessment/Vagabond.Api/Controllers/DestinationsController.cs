using Microsoft.AspNetCore.Mvc;
using Vagabond.Api.Exceptions;
using Vagabond.Api.Models;
using Vagabond.Api.Repositories;

namespace Vagabond.Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class DestinationsController(IDestinationRepository destinationRepository) : ControllerBase
{
    [HttpGet]
    public async Task<ActionResult<IEnumerable<Destination>>> GetAllDestinations()
    {
        var destinations = await destinationRepository.GetAllAsync();
        return Ok(destinations);
    }

    [HttpGet("{id:int}")]
    public async Task<ActionResult<Destination>> GetDestinationById(int id)
    {
        var destination = await destinationRepository.GetByIdAsync(id);

        if (destination is null)
        {
            throw new DestinationNotFoundException($"Destination with id {id} was not found.");
        }

        return Ok(destination);
    }

    [HttpPost]
    public async Task<ActionResult<Destination>> AddDestination(DestinationCreateDto destination)
    {
        var createdDestination = await destinationRepository.AddAsync(new Destination
        {
            CityName = destination.CityName,
            Country = destination.Country,
            Description = destination.Description,
            Rating = destination.Rating,
            LastVisited = destination.LastVisited
        });
        return CreatedAtAction(nameof(GetDestinationById), new { id = createdDestination.Id }, createdDestination);
    }

    [HttpPut("{id:int}")]
    public async Task<IActionResult> UpdateDestination(int id, Destination destination)
    {
        if (id != destination.Id)
        {
            return BadRequest(new
            {
                StatusCode = StatusCodes.Status400BadRequest,
                Message = "Route id and destination id must match."
            });
        }

        await destinationRepository.UpdateAsync(destination);
        return NoContent();
    }

    [HttpDelete("{id:int}")]
    public async Task<IActionResult> DeleteDestination(int id)
    {
        await destinationRepository.DeleteAsync(id);
        return NoContent();
    }
}
