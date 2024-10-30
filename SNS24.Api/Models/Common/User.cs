using SNS24.WebApi.Enums;
using SNS24.WebApi.Models.Common;

namespace SNS24.WebApi.Models
{
    public abstract class User : BaseEntity
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Gender { get; set; }
        public string DocumentNumber { get; set; }
        public string Password { get; set; }
        public Address Address { get; set; }
        public string PhoneNumber { get; set; }
        public DateTime BirthDate { get; set; }
        public Role Role { get; set; }
    }
}
