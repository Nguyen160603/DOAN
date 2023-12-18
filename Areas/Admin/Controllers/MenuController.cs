using DOAN.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DOAN.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class MenuController : Controller
    {
        private readonly AlskContext _context;

        public MenuController(AlskContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        {
            var mnList = _context.TbMenus.OrderBy(m => m.MenuId).ToList();

            return  View(mnList);
        }

        // GET: Admin/Menus/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.TbMenus == null)
            {
                return NotFound();
            }

            var tbMenu = await _context.TbMenus
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (tbMenu == null)
            {
                return NotFound();
            }

            return View(tbMenu);
        }

        // GET: Admin/Menus/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Admin/Menus/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("MenuId,Title,Alias,Description,Levels,ParentId,Position,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsActive")] TbMenu tbMenu)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tbMenu);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tbMenu);
        }

        // GET: Admin/Menus/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.TbMenus == null)
            {
                return NotFound();
            }

            var tbMenu = await _context.TbMenus.FindAsync(id);
            if (tbMenu == null)
            {
                return NotFound();
            }
            return View(tbMenu);
        }

        // POST: Admin/Menus/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("MenuId,Title,Alias,Description,Levels,ParentId,Position,CreatedDate,CreatedBy,ModifiedDate,ModifiedBy,IsActive")] TbMenu tbMenu)
        {
            if (id != tbMenu.MenuId)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tbMenu);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TbMenuExists(tbMenu.MenuId))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(tbMenu);
        }

        // GET: Admin/Menus/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.TbMenus == null)
            {
                return NotFound();
            }

            var tbMenu = await _context.TbMenus
                .FirstOrDefaultAsync(m => m.MenuId == id);
            if (tbMenu == null)
            {
                return NotFound();
            }

            return View(tbMenu);
        }

        // POST: Admin/Menus/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.TbMenus == null)
            {
                return Problem("Entity set 'AlskContext.TbMenus'  is null.");
            }
            var tbMenu = await _context.TbMenus.FindAsync(id);
            if (tbMenu != null)
            {
                _context.TbMenus.Remove(tbMenu);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TbMenuExists(int id)
        {
            return (_context.TbMenus?.Any(e => e.MenuId == id)).GetValueOrDefault();
        }
    }
}

