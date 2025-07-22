namespace exercise.models;

public class Profile
{
    public int Id { get; set; }
    public int UserId { get; set; }
    public User User { get; set; } = new();

    public required string FirstName { get; set; }
    public required string LastName { get; set; }
    public string? Bio { get; set; }
    public string GithubUrl { get; set; } = string.Empty;
}
