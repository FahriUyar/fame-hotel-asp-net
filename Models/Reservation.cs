using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Fame_Hotel.Models
{
    [Table("Reservations")]
    public class Reservation
    {
        public int ReservationID { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime EntryDate { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime ExitDate { get; set; }

        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Please enter a valid number for adults.")]
        public int AdultCount { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Please enter a valid number for children.")]
        public int ChildCount { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime BirthDate { get; set; }

        [Required]
        [EmailAddress]
        [StringLength(100)]
        public string Email { get; set; }

        [Required]
        [Phone]
        [StringLength(20)]
        public string PhoneNumber { get; set; }

        [Required]
        [StringLength(50)]
        public string City { get; set; }
    }
}