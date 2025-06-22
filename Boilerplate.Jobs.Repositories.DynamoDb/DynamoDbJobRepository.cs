using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Boilerplate.Jobs.Repositories.DynamoDb
{
    public class DynamoDbJobRepository : IJobRepository
    {
        public IEnumerable<Job> GetAllByStatus(int offset, int pageSize, params JobStatus[] statuses)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<Job>> GetAllByStatusAsync(int offset, int pageSize, params JobStatus[] statuses)
        {
            throw new NotImplementedException();
        }

        public Job GetById(Guid id)
        {
            throw new NotImplementedException();
        }

        public Task<Job> GetByIdAsync(Guid id)
        {
            throw new NotImplementedException();
        }

        public void Save(Job job)
        {
            throw new NotImplementedException();
        }

        public Task SaveAsync(Job job)
        {
            throw new NotImplementedException();
        }
    }
}