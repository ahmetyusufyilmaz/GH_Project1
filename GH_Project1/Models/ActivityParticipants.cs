namespace GH_Project1.Models
{
    public class ActivityParticipants:BaseClass
    {
        public Guid ActivityId { get; set; }
        public Guid ParticipantId { get; set; }
        public Activity? Activity { get; set; }
        public Participant? Participant { get; set; }

        public string? ActivityName { get; set; }
        public string? ParticipantName { get; set; }
    }
}
