using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace TouristicRental.Models
{
    public class Order
    {
        [Key]
        public int OrderId { get; set; }
        public DateTime RentDate { get; set; }

        public DateTime ReturnDate { get; set; }
        public bool isPaid { get; set; }
        public bool isFinished { get; set; }
        [ForeignKey("Good")]
        public int GoodFK { get; set; }
        [ForeignKey("Client")]
        public int ClientFK { get; set; }

    }
}
