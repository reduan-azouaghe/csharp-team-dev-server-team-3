using exercise.wwwapi.Models;

namespace exercise.wwwapi.DTOs.Login
{
    public class LoginSuccessDTO
    {
        public string token { get; set; }
        public User user { get; set; } = new User();
    }
}
