using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BDApp.Data;
using BDApp.Models;
using Microsoft.EntityFrameworkCore;

<<<<<<< Updated upstream
namespace BDApp.Pages.Projects
{
    [Authorize]
    public class IndexModel : PageModel
=======
namespace BDApp.Pages.Projects  
{
    [Authorize]
    public class IndexModel : PageModel 
>>>>>>> Stashed changes
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
