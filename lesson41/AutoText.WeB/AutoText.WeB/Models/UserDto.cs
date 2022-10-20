using AutoText.WeB.Validations;

namespace AutoText.WeB.Models
{
    public class UserDto
    {
        [Phone]
        public string? Phone { get; set; }

        [Password(8)]
        public string? Password { get; set; }
    }
}
