namespace SQS.Model
{
    public class Notification
    {
        public string Type { get; set; } = "Notification";
        public string MessageId { get; set; }
        public string TopicArn { get; set; }
        public string Message { get; set; }
        public string Timestamp { get; set; }
        public string SignatureVersion { get; set; }
        public string Signature { get; set; }
        public string SignatureCertURL { get; set; }
        public MessageAttributes MessageAttributes { get; set; }
    }
}