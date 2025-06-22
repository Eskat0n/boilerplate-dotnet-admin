using System.Threading.Tasks;
using Boilerplate.Jobs.Announcers;
using Boilerplate.Jobs.Repositories;

namespace Boilerplate.Jobs.HostedRunner
{
    public class QueueJobRunner : JobRunnerBase
    {
        private readonly IJobQueue _queue;

        public QueueJobRunner(IJobQueue queue, IJobRepository repository, IJobAnnouncer announcer)
            : base(repository, announcer)
        {
            _queue = queue;
        }

        public override async Task StartAsync<TJob>(string userEmail, string description, object payload)
        {
            var jobTypeName = typeof(TJob).Name;
            var job = await CreateJobAsync(userEmail, description, jobTypeName);
            var jobEvent = new JobEvent
            {
                JobId = job.Id,
                JobTypeName = jobTypeName,
                Payload = payload
            };
            
            await _queue.EnqueueAsync(jobEvent);    
        }
    }
}