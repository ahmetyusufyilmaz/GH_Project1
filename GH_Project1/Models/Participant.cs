using System.ComponentModel.DataAnnotations;

namespace GH_Project1.Models
{
    public class Participant:BaseClass
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [MaxLength(11)]
        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public bool IsAvailable { get; set; }
        public ICollection<ActivityParticipants>? Activities { get; set; }

        public string FullName => $"{FirstName} {LastName}";
    }
}
