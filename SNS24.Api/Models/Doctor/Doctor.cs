using SNS24.WebApi.Models.Common;

namespace SNS24.WebApi.Models
{
    public class Doctor : User
    {
        public string LicenseNumber { get; set; }
        public string Specialty { get; set; }
        public bool IsPlublicSector { get; set; }
        public ICollection<Institution> Institutions { get; set; } = new HashSet<Institution>();
        public ICollection<MedicalLeave> MedicalLeavesIssued { get; set; } = new HashSet<MedicalLeave>();
        public Doctor()
        {
            Role = Enums.Role.Doctor;
        }
    }
}
