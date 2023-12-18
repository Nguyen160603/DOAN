using Microsoft.AspNetCore.Mvc;
using DOAN.Models;

namespace WebDA.Components
{
    [ViewComponent(Name = "RecentBlog")]
    public class RecentPostComponent : ViewComponent
    {
        private readonly AlskContext _context;

        public RecentPostComponent(AlskContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofPost = (from p in _context.TbBlogs
                              where (p.IsActive == true)
                              orderby p.BlogId descending
                              select p).Take(6).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofPost));
        }

    }
}
