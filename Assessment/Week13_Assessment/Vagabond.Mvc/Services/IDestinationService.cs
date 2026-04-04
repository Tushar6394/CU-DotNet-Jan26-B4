using Vagabond.Mvc.Models;

namespace Vagabond.Mvc.Services;

public interface IDestinationService
{
    Task<IReadOnlyList<DestinationViewModel>> GetAllAsync();
}
