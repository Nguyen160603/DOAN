using DOAN.Models;
using Microsoft.AspNetCore.Mvc;

namespace DOAN.Controllers
{
    public class BookingController : Controller
    {
        public readonly AlskContext _context;
        public BookingController(AlskContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            return View();
        }
    }
}
