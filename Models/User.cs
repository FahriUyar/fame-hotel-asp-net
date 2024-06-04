using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fame_Hotel.Models
{
    [Table("GuestInfo")]
    public class User
    {
        public required string FirstName { get; set; }
        public required string LastName { get; set; }
        public required string Email { get; set; }
        public required string Password { get; set; }
        public DateTime DateOfBirth { get; set; }

        [StringLength(11, ErrorMessage = "NationalId cannot be longer than 11 digits")]
        public required string NationalId { get; set; }

        [Key]
        [Required(ErrorMessage = "Phone Number is required")]
        [StringLength(13, ErrorMessage = "Phone number cannot be longer than 13 digits")]
        public required string PhoneNumber { get; set; }
    }
}
