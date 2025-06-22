using System.Threading.Tasks;
using Amazon.Lambda;
using Amazon.Lambda.Model;
using Boilerplate.Jobs.Announcers;
using Boilerplate.Jobs.Repositories;
using Newtonsoft.Json;

namespace Boilerplate.Jobs.LambdaRunner
{
    public class LambdaJobRunner : JobRunnerBase
    {
        private readonly AmazonLambdaClient _lambdaClient;

        public LambdaJobRunner(AmazonLambdaClient lambdaClient, IJobRepository repository, IJobAnnouncer announcer)
            : base(repository, announcer)
        {
            _lambdaClient = lambdaClient;
        }

        public override async Task StartAsync<TJob>(string userEmail, string description, object payload)
        {
            var jobTypeName = typeof(TJob).Name;
            var job = await CreateJobAsync(userEmail, description, jobTypeName);
            var jobEvent = new JobEvent
            {
                JobId = job.Id,
                JobTypeName = jobTypeName,
                Payload = JsonConvert.SerializeObject(payload)
            };
            
            await _lambdaClient.InvokeAsync(new InvokeRequest
            {
                FunctionName = "1",
                InvocationType = InvocationType.Event,
                Payload = JsonConvert.SerializeObject(jobEvent)
            });
        }
    }
}