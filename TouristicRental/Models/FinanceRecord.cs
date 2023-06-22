using System.ComponentModel.DataAnnotations;

namespace TouristicRental.Models
{
    public class FinanceRecord
    {
        [Key]
        public int FinanceRecordId { get; set; }
        public float Value { get; set; }
        public DateTime Date { get; set; }
        public string? Description { get; set; } 

    }
}
