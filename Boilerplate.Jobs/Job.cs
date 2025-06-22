using System;
using System.Collections.Generic;

namespace Boilerplate.Jobs
{
    public class Job
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public string Name { get; set; }
        public string Type { get; set; }
        public string UserId { get; set; }
        public string UserEmail { get; set; }
        public Dictionary<string, object> Data { get; set; }
        public JobStatus Status { get; set; } = JobStatus.Queued;
        public ErrorData Error { get; set; }
        public DateTime StartedAt { get; set; } = DateTime.UtcNow;
        public DateTime CompletedAt { get; set; }
    }
}