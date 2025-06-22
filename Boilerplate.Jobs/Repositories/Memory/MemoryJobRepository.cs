using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Boilerplate.Jobs.Repositories.Memory
{
    public class MemoryJobRepository : IJobRepository
    {
        private readonly List<Job> _jobs = new();

        public IEnumerable<Job> GetAllByStatus(int offset, int pageSize, params JobStatus[] statuses) =>
            _jobs
                .Where(x => statuses.Contains(x.Status))
                .OrderByDescending(x => x.StartedAt)
                .Skip(offset)
                .Take(pageSize)
                .ToArray();

        public Task<IEnumerable<Job>> GetAllByStatusAsync(int offset, int pageSize, params JobStatus[] statuses)
            => Task.FromResult(GetAllByStatus(offset, pageSize, statuses));

        public Job GetById(Guid id) =>
            _jobs.FirstOrDefault(x => x.Id == id);

        public Task<Job> GetByIdAsync(Guid id) =>
            Task.FromResult(GetById(id));

        public void Save(Job job)
        {
            var existingJob = _jobs.FirstOrDefault(x => x.Id == job.Id);
            if (existingJob != null)
                _jobs.Remove(existingJob);
            
            _jobs.Add(job);
        }

        public Task SaveAsync(Job job)
        {
            Save(job);
            return Task.CompletedTask;
        }
    }
}