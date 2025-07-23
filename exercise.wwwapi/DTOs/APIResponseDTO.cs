using System.Text.Json.Serialization;

namespace exercise.wwwapi.DTOs
{
    public class APIResponseDTO
    {
        [JsonPropertyName("status")]
        public string Status { get; set; }

        [JsonPropertyName("data")]
        public UserDataDto Data { get; set; }
    }
}
