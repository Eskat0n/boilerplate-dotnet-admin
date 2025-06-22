using System.Threading;
using System.Threading.Tasks;

namespace Boilerplate.Jobs.HostedRunner
{
    public interface IJobQueue
    {
        ValueTask EnqueueAsync(JobEvent jobEvent);

        ValueTask<JobEvent> DequeueAsync(CancellationToken cancellationToken);
    }
}