using System.ComponentModel.DataAnnotations;

namespace trainStation.Model
{
    public class Train
    {
        //Primary Key
        public int Id { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Company { get; set; } = string.Empty;

        [Required]
        [EnumDataType(typeof(Type))]
        public Type? Service { get; set; }

        [EnumDataType(typeof(Type))]
        public Type? Cargo { get; set; }

        [Required]
        public double Length { get; set; } //In Meters
        [Required]
        public double Mass { get; set; } //In Kilograms

        public bool specialHandling { get; set; }

        //Navigation Property
        public ICollection<Schedule> Schedule { get; set; } = new List<Schedule>();
    }
}
