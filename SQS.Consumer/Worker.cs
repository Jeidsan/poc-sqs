using System.Text.Json;
using Amazon.Runtime;
using Amazon.SQS;

namespace SQS.Consumer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;

        public Worker(ILogger<Worker> logger)
        {
            _logger = logger;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var accessKey = "AKIA6NXGTF4VFN672R2R";
                var secretKey = "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";
                var sqsUrl = "https://sqs.us-west-2.amazonaws.com/991547305770/poc-sqs";

                var credentials = new BasicAWSCredentials(accessKey, secretKey);
                var client = new AmazonSQSClient(credentials, Amazon.RegionEndpoint.USWest2);
                var response = await client.ReceiveMessageAsync(sqsUrl);

                foreach (var message in response.Messages) {
                    Console.WriteLine(JsonSerializer.Serialize(message));
                }                

                await Task.Delay(1000, stoppingToken);
            }
        }
    }
}