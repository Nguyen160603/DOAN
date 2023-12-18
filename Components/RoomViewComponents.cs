using DOAN.Models;
using Microsoft.AspNetCore.Mvc;

namespace DOAN.Components
{
    [ViewComponent(Name = "Room")]
    public class RoomViewComponent : ViewComponent
    {
        private readonly AlskContext _context;

        public RoomViewComponent(AlskContext context)
        {
            _context = context;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            var listofRoom = (from p in _context.TbRooms
                              where (p.IsActive == true) 
                              orderby p.RoomId descending
                              select p).Take(6).ToList();
            return await Task.FromResult((IViewComponentResult)View("Default", listofRoom));
        }
    }
}

