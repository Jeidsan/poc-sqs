using System.Text.Json;
using Amazon.Runtime;
using Amazon.SQS;

namespace SQS.Consumer
{
    public class Worker : BackgroundService
    {
        private readonly ILogger<Worker> _logger;
        private readonly IConfiguration _configuration;

        public Worker(ILogger<Worker> logger, IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                _logger.LogInformation("Worker running at: {time}", DateTimeOffset.Now);

                var sqsUrl = _configuration.GetSection("SQS").GetSection("Url").Value;
                var accessKey = _configuration.GetSection("SQS").GetSection("AccessKey").Value;
                var secretKey = _configuration.GetSection("SQS").GetSection("SecretKey").Value;
                
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