using Buoi5.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Buoi5.Components
{
    public class SidebarViewComponent : ViewComponent
    {
        private readonly ApplicationDbContext _context;

        public SidebarViewComponent(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<IViewComponentResult> InvokeAsync()
        {
            var categories = await _context.Categories
                .Include(c => c.Books)
                .Select(c => new
                {
                    c.CategoryId,
                    c.CategoryName,
                    BookCount = c.Books.Count
                })
                .ToListAsync();

            return View(categories);
        }
    }
}
