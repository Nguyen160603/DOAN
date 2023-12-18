using DOAN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DOAN.Areas.Admin.Controllers
{
    public class BlogController : Controller
    {
        private readonly AlskContext _context;

        public BlogController(AlskContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            var blog = _context.TbBlogs.OrderBy(m => m.BlogId).ToList();
            return View(blog);
        }
    }
}
