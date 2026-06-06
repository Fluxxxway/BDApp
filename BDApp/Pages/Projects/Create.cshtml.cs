<<<<<<< Updated upstream
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
=======
﻿
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
>>>>>>> Stashed changes
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

<<<<<<< Updated upstream
        [BindProperty]
=======
        [BindProperty]  
>>>>>>> Stashed changes
        public string Name { get; set; } = string.Empty;

        [BindProperty]
        public string? Description { get; set; }

<<<<<<< Updated upstream
        public string? GeneratedCode { get; set; }
        public string? ErrorMessage { get; set; }

        public void OnGet()
        {
=======
        public string? GeneratedCode { get; set; }  
        public string? ErrorMessage { get; set; }   

        public void OnGet()
        {
            
>>>>>>> Stashed changes
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
<<<<<<< Updated upstream
=======
                
>>>>>>> Stashed changes
                var plainCode = GenerateRandomCode();

                var project = new Project
                {
                    Name = Name,
                    Description = Description,
<<<<<<< Updated upstream
                    InviteCodeHash = HashHelper.Hash(plainCode)
=======
                    InviteCodeHash = HashHelper.Hash(plainCode) 
>>>>>>> Stashed changes
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

<<<<<<< Updated upstream
=======

>>>>>>> Stashed changes
        private static string GenerateRandomCode()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}
