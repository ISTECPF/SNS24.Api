using SNS24.WebApi.Models;

namespace SNS24.WebApi.Models
{
    public class Patient : User
    {
        public string SNSNumber { get; set; }
        public ICollection<MedicalLeave> MedicalLeaves { get; set; } = new HashSet<MedicalLeave>();
        public ICollection<Notification> Notifications { get; set; } = new HashSet<Notification>();
        public Patient()
        {
            Role = Enums.Role.Patient;
        }
    }
}
