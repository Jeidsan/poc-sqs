using System.Text.Json;
using Amazon.Runtime;
using Amazon.SQS;
using SQS.Model;

namespace SQS.Producer
{
    public class Service
    {
        private readonly IConfiguration _configuration;

        public Service(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public async Task<string> SendMessage(Pessoa pessoa)
        {
            var message = new Message()
            {
                Header = new MessageHeader()
                {
                    Event = Event.CREATED,
                    DateTime = DateTime.UtcNow.ToString()
                },
                Data = new MessageData()
                {
                    Pessoa = pessoa
                }
            };

            var sqsUrl = _configuration.GetSection("SQS").GetSection("Url").Value;
            var accessKey = _configuration.GetSection("SQS").GetSection("AccessKey").Value;
            var secretKey = _configuration.GetSection("SQS").GetSection("SecretKey").Value;

            var credentials = new BasicAWSCredentials(accessKey, secretKey);
            var client = new AmazonSQSClient(credentials, Amazon.RegionEndpoint.USWest2);
            var response = await client.SendMessageAsync(sqsUrl, JsonSerializer.Serialize(message));            

            return $"{response.HttpStatusCode} - {response.MessageId}";
        }
    }
}