namespace SQS.Model;

public class Message
{
    public MessageHeader Header { get; set; }
    public string Data { get; set; }
}
