using System.ComponentModel.DataAnnotations;

namespace TouristicRental.Models
{
    public class Worker
    {
        [Key]
        public int WorkerId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Position { get; set; }
        public float Salary { get; set; }
    }
}
