using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BDApp.Data;
using BDApp.Models;
using Microsoft.EntityFrameworkCore;

namespace BDApp.Pages.Projects  // 🔥 Должно совпадать с папкой!
{
    [Authorize]
    public class IndexModel : PageModel  // 🔥 Класс называется IndexModel!
    {
        private readonly ApplicationDbContext _context;

        public IndexModel(ApplicationDbContext context)
        {
            _context = context;
        }

        public List<Project> Projects { get; set; } = new();

        public async Task OnGetAsync()
        {
            Projects = await _context.Projects.ToListAsync();
        }
    }
}