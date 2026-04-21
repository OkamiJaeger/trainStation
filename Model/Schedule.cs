using System.ComponentModel.DataAnnotations;

namespace trainStation.Model
{
    public class Schedule
    {
        //Primary Key
        public int Id { get; set; }

        [Required]
        public DateTime Arrival { get; set; } = DateTime.Now;

        public DateTime Departure { get; set; } = DateTime.Now;


        [EnumDataType(typeof(Type))]
        public Type? Platform { get; set; }

        //Foreign Key
        [Display(Name = "Train")]
        public int TrainID { get; set; }
        public Train? Train { get; set; }
    }
}
