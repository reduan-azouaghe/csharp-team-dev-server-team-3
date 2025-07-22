using exercise.enums;

namespace exercise.models;

public class User
{
    public int Id { get; set; }
    public required string Email { get; set; }
    public required string Password { get; set; }
    public Role Role { get; set; } = Role.Student;

    public Profile Profile { get; set; }
    public int? CohortId { get; set; }
    public Cohort Cohort { get; set; }

    public List<Post> Posts { get; set; } = new();
    public List<Comment> Comments { get; set; } = new();
    public List<DeliveryLog> DeliveryLogs { get; set; } = new();
}
