using System.Threading.Tasks;

namespace Boilerplate.Jobs.Announcers
{
    public interface IJobAnnouncer
    {
        Task AnnounceQueuedAsync(Job job);
        Task AnnounceStartedAsync(Job job);
        Task AnnounceCompletedAsync(Job job);
    }
}