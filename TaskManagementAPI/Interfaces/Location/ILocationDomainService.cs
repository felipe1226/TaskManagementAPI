using TaskManagementAPI.Models;

namespace TaskManagementAPI.Interfaces
{
    public interface ILocationDomainService
    {
        IQueryable<Location> getLocations();
    }
}
