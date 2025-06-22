using System;
using System.Threading.Tasks;

namespace Boilerplate.Jobs
{
    public interface IJobRunner
    {
        Task StartAsync<TJob>(string userEmail, string description, object payload);

        Task CompleteJobAsync(Job job);

        Task CompleteJobAsync(Job job, Exception exception);
    }
}