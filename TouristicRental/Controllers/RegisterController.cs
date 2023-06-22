using Microsoft.AspNetCore.Mvc;
using TouristicRental.Data;

namespace TouristicRental.Controllers
{
    public class RegisterController : Controller
    {
        private readonly TouristicRentalContext _context;

        public IActionResult Index()
        {
            return View();
        }
    }
}
