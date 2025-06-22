namespace Boilerplate.Jobs
{
    public enum JobStatus
    {
        /// <summary>
        /// Job currency in queue and waiting for start
        /// </summary>
        Queued,

        /// <summary>
        /// Job in running
        /// </summary>
        Running,

        /// <summary>
        /// Job completed successfully
        /// </summary>
        Success,

        /// <summary>
        /// Job completed with error
        /// </summary>
        Error,
    }
}