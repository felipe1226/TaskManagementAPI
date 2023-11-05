using Microsoft.EntityFrameworkCore;
using TaskManagementAPI.DTO.WorkTask;
using TaskManagementAPI.Interfaces;
using TaskManagementAPI.Models;

namespace TaskManagementAPI.Data.Repositories
{
    public class WorkTaskDomainService : IWorkTaskDomainService
    {
        private readonly DBContext _context;

        public WorkTaskDomainService(DBContext context)
        {
            _context = context;
        }

        public int saveWorkTask(WorkTask workTask)
        {
            _context.WorkTask.Add(workTask);
            return _context.SaveChanges();
        }

        public int saveWorkTaskStatus(WorkTaskStatus workTaskStatus)
        {
            _context.WorkTaskStatus.Add(workTaskStatus);
            return _context.SaveChanges();
        }

        public int saveWaypoints(IEnumerable<Waypoint> waypoints)
        {
            _context.Waypoint.AddRange(waypoints);
            return _context.SaveChanges();
        }

        public WorkTask getWorkTasksById(Guid id)
        {
            return _context.WorkTask
                .Where(workTask => workTask.Id.Equals(id))
                .Include(workTask => workTask.CategoryNavigation)
                .Include(workTask => workTask.Waypoints)
                    .ThenInclude(workTask => workTask.LocationNavigation)
                .Include(workTask => workTask.WorkTaskStatuses)
                    .ThenInclude(statuses => statuses.StatusNavigation)
                .AsNoTracking()
                .FirstOrDefault();
        }

        public IQueryable<WorkTask> getWorkTasks(WorkTaskFiltersDTO filters)
        {
            IQueryable<WorkTask> workTasks = _context.WorkTask
                .Where(workTask => workTask.State)
                .Include(workTask => workTask.CategoryNavigation)
                .Include(workTask => workTask.WorkTaskStatuses)
                    .ThenInclude(statuses => statuses.StatusNavigation)
                .AsNoTracking();

            if (!string.IsNullOrEmpty(filters.UserId))
                workTasks = workTasks.Where(workTask => workTask.User.Equals(Guid.Parse(filters.UserId)));
            
            if (!string.IsNullOrEmpty(filters.CategoryId))
                workTasks = workTasks.Where(workTask => workTask.Category.Equals(Guid.Parse(filters.CategoryId)));
            
            if (!string.IsNullOrEmpty(filters.StatusId))
                workTasks = workTasks.Where(workTask => workTask.WorkTaskStatuses
                .OrderByDescending(statuses => statuses.CreatedAt)
                .FirstOrDefault().Status.Equals(Guid.Parse(filters.StatusId)));
            
            return workTasks;
        }

        public int updateStatus(WorkTaskStatus workTaskStatus)
        {
            _context.WorkTaskStatus.Add(workTaskStatus);
            return _context.SaveChanges();
        }
    }
}
