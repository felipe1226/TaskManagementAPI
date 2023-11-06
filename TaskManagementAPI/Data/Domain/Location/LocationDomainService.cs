using TaskManagementAPI.Interfaces;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Data.Domain
{
    public class LocationDomainService : ILocationDomainService
    {
        private readonly DBContext _context;

        public LocationDomainService(DBContext context)
        {
            _context = context;
        }

        public IQueryable<Location> getLocations()
        {
            return _context.Location.
                Where(location => location.State)
                .OrderBy(location => location.Name);
        }
    }
}
