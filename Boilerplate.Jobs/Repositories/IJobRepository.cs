using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boilerplate.Jobs.Repositories
{
    public interface IJobRepository
    {
        IEnumerable<Job> GetAllByStatus(int offset, int pageSize, params JobStatus[] statuses);
        Task<IEnumerable<Job>> GetAllByStatusAsync(int offset, int pageSize, params JobStatus[] statuses);
        Job GetById(Guid id);
        Task<Job> GetByIdAsync(Guid id);
        void Save(Job job);
        Task SaveAsync(Job job);
    }
}