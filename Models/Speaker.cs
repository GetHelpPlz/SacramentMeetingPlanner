using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Speaker
    {
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string FirstName { get; set; }

        [Required]
        [StringLength(50)]
        public string LastName { get; set; }

        [Required]
        public string Gender { get; set; } // Man or Woman

        [Range(1, 120)]
        public int Age { get; set; }

        public string Notes { get; set; }
    }
}