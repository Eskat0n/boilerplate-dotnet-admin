using System;

namespace Boilerplate.Jobs
{
    public class JobEvent
    {
        public Guid JobId { get; set; }
        public string JobTypeName { get; set; }
        public object Payload { get; set; }
    }
}