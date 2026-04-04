using Day71.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace Day71.Services;

public sealed class LaptopService
{
    private readonly IMongoCollection<Laptop> _laptopCollection;

    public LaptopService(IOptions<DatabaseSettings> databaseSettings)
    {
        var settings = databaseSettings.Value;
        var mongoClient = new MongoClient(settings.ConnectionString);
        var database = mongoClient.GetDatabase(settings.DatabaseName);
        _laptopCollection = database.GetCollection<Laptop>(settings.CollectionName);
    }

    public async Task CreateAsync(Laptop newLaptop)
    {
        ArgumentNullException.ThrowIfNull(newLaptop);

        await _laptopCollection.InsertOneAsync(newLaptop);
    }

    public async Task<List<Laptop>> GetAsync()
    {
        return await _laptopCollection.Find(_ => true).ToListAsync();
    }
}
