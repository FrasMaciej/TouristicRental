using Microsoft.AspNetCore.Authorization;
using System.ComponentModel.DataAnnotations;

namespace TouristicRental.Models
{
    public class Client
    {
        [Key]
        public int ClientId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime JoinDate { get; set; }
        public string userId { get; set; }

        public Client()
        {
            JoinDate = DateTime.Now;
        }
    }
}
