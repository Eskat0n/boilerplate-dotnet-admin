using System;
using System.Threading;
using System.Threading.Channels;
using System.Threading.Tasks;

namespace Boilerplate.Jobs.HostedRunner
{
    public class JobQueue : IJobQueue
    {
        private readonly Channel<JobEvent> _queue;

        public JobQueue(int capacity = 100)
        {
            var options = new BoundedChannelOptions(capacity)
            {
                FullMode = BoundedChannelFullMode.Wait
            };
            _queue = Channel.CreateBounded<JobEvent>(options);
        }

        public async ValueTask EnqueueAsync(JobEvent jobEvent)
        {
            if (jobEvent == null)
                throw new ArgumentNullException(nameof(jobEvent));

            await _queue.Writer.WriteAsync(jobEvent);
        }

        public async ValueTask<JobEvent> DequeueAsync(CancellationToken cancellationToken)
        {
            return await _queue.Reader.ReadAsync(cancellationToken);
        }
    }
}