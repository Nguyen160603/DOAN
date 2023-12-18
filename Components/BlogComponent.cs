using Microsoft.AspNetCore.Mvc;
using DOAN.Models;
namespace WebDA.Components
{
    [ViewComponent(Name = "Blog")]
    public class BlogComponent : ViewComponent
{
    private readonly AlskContext _context;

    public BlogComponent(AlskContext context)
    {
        _context = context;
        }
    public async Task<IViewComponentResult> InvokeAsync()
        {
            var items = _context.TbBlogs.Where(m => (bool)m.IsActive).OrderBy(i => i.BlogId).Take(3).ToList();
            ViewBag.blogComment = _context.TbBlogComments.Where(m => (bool)m.IsActive).ToList();
            return await Task.FromResult<IViewComponentResult>(View(items));
        }
    }
}
