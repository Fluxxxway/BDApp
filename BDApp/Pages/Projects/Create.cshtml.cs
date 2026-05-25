// 🔥 ДОБАВЬ ЭТИ СТРОКИ В САМОМ ВЕРХУ:
using Microsoft.AspNetCore.Authorization;  // Для [Authorize]
using Microsoft.AspNetCore.Mvc;             // Для IActionResult, PageModel, RedirectToPage
using Microsoft.AspNetCore.Mvc.RazorPages;  // Для PageModel
using BDApp.Data;                           // Для ApplicationDbContext
using BDApp.Models;                         // Для Project
using BDApp.Services;                       // Для HashHelper

namespace BDApp.Pages.Projects
{
    [Authorize]  // 🔒 Теперь компилятор знает, что это
    public class CreateModel : PageModel  // 🔒 И это
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]  // 🔗 Автоматически связывает поле формы с этим свойством
        public string Name { get; set; } = string.Empty;

        [BindProperty]
        public string? Description { get; set; }

        public string? GeneratedCode { get; set; }  // Для показа кода после создания
        public string? ErrorMessage { get; set; }   // Для показа ошибок

        public void OnGet()
        {
            // Пустая форма при открытии страницы
        }

        public async Task<IActionResult> OnPostAsync()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            try
            {
                // Генерация случайного кода
                var plainCode = GenerateRandomCode();

                var project = new Project
                {
                    Name = Name,
                    Description = Description,
                    InviteCodeHash = HashHelper.Hash(plainCode) // 🔥 Хешируем!
                };

                _context.Projects.Add(project);
                await _context.SaveChangesAsync();

                // Показываем код ТОЛЬКО СЕЙЧАС (больше нигде не сохраняем)
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

        // Генерация 8-символьного кода без похожих букв (I, O, 0, 1)
        private static string GenerateRandomCode()
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZ23456789";
            var random = new Random();
            return new string(Enumerable.Repeat(chars, 8)
                .Select(s => s[random.Next(s.Length)]).ToArray());
        }
    }
}