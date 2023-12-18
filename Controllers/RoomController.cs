using DOAN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DOAN.Controllers
{
    public class RoomController : Controller
    {
        private readonly AlskContext _context;

        public RoomController(AlskContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 6;

            // Thêm điều kiện kiểm tra IsActive không null trước khi thực hiện ToPagedList
            var Blogs = _context.TbRooms
                .Where(i => i.IsActive != null && (bool)i.IsActive)
                .OrderByDescending(i => i.RoomId)
                .ToPagedList((int)page, pageSize);

            return View(Blogs);
        }

        [Route("/Room-{slug}-{id:int}.html")]
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbRooms == null)
            {
                return NotFound();
            }

            var Room = await _context.TbRooms
                .FirstOrDefaultAsync(m => m.RoomId == id);
            if (Room == null)
            {
                return NotFound();
            }

            return View(Room);
        }


    }
  
}
