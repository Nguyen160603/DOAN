using DOAN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.Extensions.Hosting;

namespace DOAN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class RoomController : Controller
    {
        private readonly AlskContext _context;

        public RoomController(AlskContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var mnRoom = _context.TbRooms.OrderBy(m=> m.RoomId).ToList();
            return View(mnRoom);
        }
        
    }
}
