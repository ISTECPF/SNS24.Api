using SNS24.WebApi.Models.Common;

namespace SNS24.WebApi.Models
{
    public class Institution : BaseEntity
    {
        public string Name { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public ICollection<Doctor> Doctors { get; set; } = new HashSet<Doctor>();
    }
}
