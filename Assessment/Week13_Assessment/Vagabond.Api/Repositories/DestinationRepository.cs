using Microsoft.EntityFrameworkCore;
using Vagabond.Api.Data;
using Vagabond.Api.Exceptions;
using Vagabond.Api.Models;

namespace Vagabond.Api.Repositories;

public class DestinationRepository(VagabondDbContext dbContext) : IDestinationRepository
{
    public async Task<IEnumerable<Destination>> GetAllAsync()
    {
        return await dbContext.Destinations
            .AsNoTracking()
            .OrderBy(d => d.CityName)
            .ToListAsync();
    }

    public async Task<Destination?> GetByIdAsync(int id)
    {
        return await dbContext.Destinations
            .AsNoTracking()
            .FirstOrDefaultAsync(d => d.Id == id);
    }

    public async Task<Destination> AddAsync(Destination destination)
    {
        dbContext.Destinations.Add(destination);
        await dbContext.SaveChangesAsync();
        return destination;
    }

    public async Task UpdateAsync(Destination destination)
    {
        var existingDestination = await dbContext.Destinations.FirstOrDefaultAsync(d => d.Id == destination.Id);

        if (existingDestination is null)
        {
            throw new DestinationNotFoundException($"Destination with id {destination.Id} was not found.");
        }

        existingDestination.CityName = destination.CityName;
        existingDestination.Country = destination.Country;
        existingDestination.Description = destination.Description;
        existingDestination.Rating = destination.Rating;
        existingDestination.LastVisited = destination.LastVisited;

        await dbContext.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var destination = await dbContext.Destinations.FirstOrDefaultAsync(d => d.Id == id);

        if (destination is null)
        {
            throw new DestinationNotFoundException($"Destination with id {id} was not found.");
        }

        dbContext.Destinations.Remove(destination);
        await dbContext.SaveChangesAsync();
    }
}
