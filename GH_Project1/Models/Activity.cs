using System.Reflection.Metadata.Ecma335;

namespace GH_Project1.Models
{
    public class Activity:BaseClass
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }
        public string Place { get; set; }

        public ICollection<ActivityParticipants>? Participants { get; set; }
    }
}
