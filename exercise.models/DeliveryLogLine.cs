namespace exercise.models;

public class DeliveryLogLine
{
    public int Id { get; set; }
    public string Content { get; set; }

    public int LogId { get; set; }
    public DeliveryLog Log { get; set; }
}
