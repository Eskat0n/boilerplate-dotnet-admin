using System;
using System.Threading.Tasks;
using Boilerplate.Jobs.Announcers;
using Boilerplate.Jobs.Repositories;

namespace Boilerplate.Jobs
{
    public abstract class JobRunnerBase : IJobRunner
    {
        private readonly IJobRepository _repository;
        private readonly IJobAnnouncer _announcer;

        protected JobRunnerBase(IJobRepository repository, IJobAnnouncer announcer)
        {
            _repository = repository;
            _announcer = announcer;
        }
        
        public abstract Task StartAsync<TJob>(string userEmail, string description, object payload);
        
        public async Task CompleteJobAsync(Job job)
        {
            job.Status = JobStatus.Success;
            job.CompletedAt = DateTime.UtcNow;

            await _repository.SaveAsync(job);
            await _announcer.AnnounceCompletedAsync(job);
        }

        public async Task CompleteJobAsync(Job job, Exception exception)
        {
            job.Status = JobStatus.Error;
            job.Error = ErrorData.FromException(exception);
            job.CompletedAt = DateTime.UtcNow;

            await _repository.SaveAsync(job);
            await _announcer.AnnounceCompletedAsync(job);
        }

        protected async Task<Job> CreateJobAsync(string userEmail, string description, string type)
        {
            var job = new Job
            {
                Name = description,
                Type = type,
                UserEmail = userEmail 
            };

            await _repository.SaveAsync(job);
            await _announcer.AnnounceQueuedAsync(job);
            
            return job;
        }
    }
}