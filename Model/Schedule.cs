using System.ComponentModel.DataAnnotations;

namespace trainStation.Model
{
    // Enum for the Platform Dropdown
    public enum PlatformType
    {
        [Display(Name = "Platform 1")]
        Platform1,
        [Display(Name = "Platform 2")]
        Platform2,
        [Display(Name = "Platform 3")]
        Platform3,
        [Display(Name = "Platform 4")]
        Platform4,
        [Display(Name = "Platform 5")]
        Platform5,
        [Display(Name = "Maintenance House")]
        MaintenanceHouse
    }

    public class Schedule
    {
        //Primary Key
        public int Id { get; set; }

        [Required]
        [Display(Name = "Arrival Time")]
        public DateTime Arrival { get; set; } = DateTime.Now;

        [Display(Name = "Departure Time")]
        public DateTime? Departure { get; set; }

        [Required]
        [Display(Name = "Platform / Location")]
        public PlatformType Platform { get; set; }

        //Foreign Key
        [Display(Name = "Train")]
        public int TrainID { get; set; }
        public Train? Train { get; set; }
    }
}
