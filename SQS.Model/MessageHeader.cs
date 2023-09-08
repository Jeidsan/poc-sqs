namespace SQS.Model
{
    public class MessageHeader
    {
        public string Version { get; set; }
        public string CustomerId { get; set; }
        public string EnvironmentId { get; set; }
        public string ConsentType { get; set; }        
        public string CreatedDateTime { get; set; }
        public string Event { get; set; }
    }
}