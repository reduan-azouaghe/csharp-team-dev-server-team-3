using exercise.wwwapi.Models;
using System.Text.Json.Serialization;

namespace exercise.wwwapi.DTOs
{
    public class UserDataDto
    {
        [JsonPropertyName("users")]
        public List<User> Users { get; set; }
    }

}
