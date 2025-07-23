using exercise.enums;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection;
using System.Text.Json.Serialization;

namespace exercise.models;

[Table("User")]
public class User
{
    [Column("id")]
    public int Id { get; set; }
    [Column("email")]
    public string Email { get; set; } = string.Empty;
    [JsonIgnore]
    [Column("password")]
    public string Password { get; set; }
    [Column("role")]
    [NotMapped]
    public Role Role { get; set; } = Role.Student;
    
    
    //public Profile Profile { get; set; }

    //[Column("cohortId")]
    [NotMapped]
    public int? CohortId { get; set; }
    [NotMapped]
    [ForeignKey(nameof(CohortId))]
    public Cohort Cohort { get; set; }
    [NotMapped]
    public List<Post> Posts { get; set; } = new();
    [NotMapped]
    public List<Comment> Comments { get; set; } = new();
    [NotMapped]
    public List<DeliveryLog> DeliveryLogs { get; set; } = new();
}
