using System.ComponentModel.DataAnnotations;

namespace SacramentMeetingPlanner.Models
{
    public class Hymn
    {
        public int Id { get; set; }

        [Required]
        public int Number { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }
    }
}
