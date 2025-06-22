using System.Threading.Tasks;

namespace Boilerplate.Jobs
{
    public abstract class JobHandler<TPayload> : JobHandler
    {
        public abstract Task ExecuteAsync(TPayload payload);
    }
}