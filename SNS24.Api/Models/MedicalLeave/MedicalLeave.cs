using SNS24.WebApi.Enums;
using SNS24.WebApi.Models;

namespace SNS24.WebApi.Models
{
    public class MedicalLeave : BaseEntity
    {
        public Guid PatientId { get; set; }
        public Patient Patient { get; set; }

        public Guid DoctorId { get; set; }
        public Doctor Doctor { get; set; }

        public string Diagnosis { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Recommendations { get; set; }

        public bool IsPublicSector { get; set; }

        public string Employer { get; set; } 
        public string JobFunction { get; set; }
        public string EducationLevel { get; set; } 

        public MedicalLeaveStatus Status { get; set; }
    }
}
