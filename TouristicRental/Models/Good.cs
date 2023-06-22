using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace TouristicRental.Models
{
    public class Good
    {
        [Key]
        public int GoodId { get; set; }
        public string Name { get; set; }
        public double DailyPrice { get; set; }
        public string Description { get; set; }
        public string Category { get; set; }
        public bool IsFree { get; set; }
        public string? ImagePath { get; set; }   

    }
}
