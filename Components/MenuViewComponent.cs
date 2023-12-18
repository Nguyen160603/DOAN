using Microsoft.AspNetCore.Mvc;
using DOAN.Models;


namespace WebDA.Components
{
        [ViewComponent(Name = "MenuView")]
        public class MenuViewComponent : ViewComponent
        {
            private AlskContext _context;

            public MenuViewComponent(AlskContext context)
            {
                _context = context;
            }
            public async Task<IViewComponentResult> InvokeAsync()
            {
            
                var items = _context.TbMenus.Where(m => (bool)m.IsActive).OrderBy(m => m.Position).ToList();
                return await Task.FromResult<IViewComponentResult>(View(items));
            }
        }
}




