namespace exercise.models;

public class Cohort
{
    public int Id { get; set; }
    public required string Name { get; set; }

    public List<User> Users { get; set; }
    public List<DeliveryLog> DeliveryLogs { get; set; }
}
