using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.User
{
    public class EditUser
    {
        public int Id { get; set; }

        [StringLength(100, ErrorMessage = "FirebaseID cannot be longer than 100 characters.")]
        public string? FirebaseID { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Birth Date")]
        public DateTime? BirthDate { get; set; }

        [Display(Name = "Preferred Seat Type")]
        public SeatType PreferedSeatType { get; set; }

        [Display(Name = "Preferred Seat Location")]
        public SeatLocation PreferedSeatLocation { get; set; }

        [StringLength(100)]
        public string FirstName { get; set; } = string.Empty;

        [StringLength(100)]
        public string LastName { get; set; } = string.Empty;

        [EmailAddress]
        public string? Email { get; set; }
    }
}
