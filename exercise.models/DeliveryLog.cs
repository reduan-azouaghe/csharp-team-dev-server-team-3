namespace exercise.models;

public class DeliveryLog
{
    public int Id { get; set; }
    public DateTime Date { get; set; }

    public int UserId { get; set; }
    public User User { get; set; }

    public int CohortId { get; set; }
    public Cohort Cohort { get; set; }

    public List<DeliveryLogLine> Lines { get; set; }
}
