using System.Text.Json.Serialization;

namespace exercise.wwwapi.DTOs
{
    public class Payload<T> where T : class
    {
        public string status { get; set; }
        [JsonPropertyName("users")]
        public T data { get; set; }
    }
}
