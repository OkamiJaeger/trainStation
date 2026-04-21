using System.ComponentModel.DataAnnotations;

namespace trainStation.Model
{
    public enum ServiceType
    {
        Passenger,
        Freight,
        Maintenance,
        Switching
    }
    public enum CargoType
    {
        None,
        Hoppers,
        Flatbed,
        Boxcar,
        Tanker,
        Livestock
    }
    public class Train
    {
        //Primary Key
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; } = string.Empty;

        [Required]
        [StringLength(100)]
        public string Company { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Service Type")]
        public ServiceType? Service { get; set; }

        [Display(Name = "Cargo Type")]
        public CargoType? Cargo { get; set; }

        [Required]
        [Range(0, double.MaxValue, ErrorMessage = "Length must be a positive number.")]
        [Display(Name = "Length (Meters)")]
        public double Length { get; set; } //In Meters

        [Display(Name = "Mass (Kilograms)")]
        [Range(0, double.MaxValue, ErrorMessage = "Mass must be a positive number.")]
        public double Mass { get; set; } //In Kilograms

        [Display(Name = "Requires Special Handling")]
        public bool SpecialHandling { get; set; }

        //Navigation Property
        public ICollection<Schedule> Schedules { get; set; } = new List<Schedule>();
    }
}
