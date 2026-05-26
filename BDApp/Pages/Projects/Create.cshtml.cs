using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using BDApp.Data;
using BDApp.Models;
using BDApp.Services;

namespace BDApp.Pages.Projects
{
    [Authorize]
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public string Name { get; set; } = string.Empty;

        [BindProperty]
        public string? Description { get; set; }

        public string? GeneratedCode { get; set; }
        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                var plainCode = GenerateRandomCode();

                var project = new Project
                {
                    Name = Name,
                    Description = Description,
                    InviteCodeHash = HashHelper.Hash(plainCode)
                };

                _context.Projects.Add(project);
                await _context.SaveChangesAsync();

                GeneratedCode = plainCode;
                Name = string.Empty;
                Description = null;

                return Page();
            }
            catch (Exception ex)
            {
                ErrorMessage = $"Ошибка: {ex.Message}";
                return Page();
            }
        }

        private static string GenerateRandomCode()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
