using System.Text.Json.Serialization;

namespace SQS.Model
{
    public class MessageAttributes
    {
        [JsonPropertyName("event_type")]
        public Attribute EventType { get; set; }
        
        [JsonPropertyName("consent_name")]
        public Attribute ConsentNamespace { get; set; }

        [JsonPropertyName("environment_id")]
        public Attribute EnvironmentId { get; set; }

        [JsonPropertyName("id")]
        public Attribute Id { get; set; }

        [JsonPropertyName("customer_id")]
        public Attribute CustomerId { get; set; }

        [JsonPropertyName("consent_type")]
        public Attribute ConsentType { get; set; }

        [JsonPropertyName("timestamp")]
        public Attribute Timestamp { get; set; }
    }
}