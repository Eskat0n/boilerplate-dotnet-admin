using System;
using System.Threading.Tasks;

namespace Boilerplate.Jobs.Announcers.Pusher
{
    public class PusherJobAnnouncer : IJobAnnouncer
    {
        private const string QueuedEventName = "job.queued";
        private const string StartedEventName = "job.started";
        private const string CompletedEventName = "job.completed";

        private readonly PusherServer.Pusher _pusher;
        private readonly string _channelName = "jobs";

        public PusherJobAnnouncer(PusherServer.Pusher pusher)
        {
            _pusher = pusher;
        }

        public PusherJobAnnouncer(PusherServer.Pusher pusher, string channelName)
            : this(pusher)
        {
            _channelName = channelName ?? throw new ArgumentNullException(nameof(channelName));
        }

        public async Task AnnounceQueuedAsync(Job job)
        {
            await _pusher.TriggerAsync(_channelName, QueuedEventName, new {job});
        }

        public async Task AnnounceStartedAsync(Job job)
        {
            await _pusher.TriggerAsync(_channelName, StartedEventName, new {job});
        }

        public async Task AnnounceCompletedAsync(Job job)
        {
            var data = job.Error == null
                ? new
                {
                    jobId = job.Id,
                    success = true,
                    message = $"{job.Name} completed successfully"
                }
                : new
                {
                    jobId = job.Id,
                    success = false,
                    message = $"Error while {job.Name}:\n{job.Error.Message}"
                };

            await _pusher.TriggerAsync(_channelName, CompletedEventName, data);
        }
    }
}