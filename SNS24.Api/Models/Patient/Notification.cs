namespace SNS24.WebApi.Models
{
    public class Notification : BaseEntity
    {
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }
        public string Message { get; set; }
        public bool IsRead { get; set; } = false;
        public DateTime NotificationDate { get; set; }
    }
}
