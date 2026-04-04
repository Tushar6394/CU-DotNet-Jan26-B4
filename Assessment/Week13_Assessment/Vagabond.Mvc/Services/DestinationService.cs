using System.Text.Json;
using Vagabond.Mvc.Models;

namespace Vagabond.Mvc.Services;

public class DestinationService(HttpClient httpClient) : IDestinationService
{
    public async Task<IReadOnlyList<DestinationViewModel>> GetAllAsync()
    {
        var response = await httpClient.GetAsync("api/destinations");

        if (!response.IsSuccessStatusCode)
        {
            return [];
        }

        var content = await response.Content.ReadAsStringAsync();
        var options = new JsonSerializerOptions
        {
            PropertyNameCaseInsensitive = true
        };

        var destinations = JsonSerializer.Deserialize<List<DestinationViewModel>>(content, options);
        return destinations ?? [];
    }
}
