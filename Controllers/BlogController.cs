using DOAN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using X.PagedList;

namespace DOAN.Controllers
{
    public class BlogController : Controller
    {
        private readonly AlskContext _context;

        public BlogController(AlskContext context)
        {
            _context = context;
        }
        public IActionResult Index(int? page)
        {
            if (page == null) page = 1;
            int pageSize = 4;
            var Blogs = _context.TbBlogs.Where(i => (bool)i.IsActive).OrderByDescending(i => i.BlogId).ToPagedList((int)page, pageSize);

            return View(Blogs);
        }
        [Route("/Blog-{slug}-{id:long}.html", Name = "Details")]
        public IActionResult Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var Blogs = _context.TbBlogs
                .FirstOrDefault(m => (m.BlogId == id) && (m.IsActive == true));
            if (Blogs == null)
            {
                return NotFound();
            }
            ViewBag.blogComment = _context.TbBlogComments.Where(i => i.BlogId == id).ToList();
            return View(Blogs);
        }


    }

}

