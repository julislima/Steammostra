using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Steammostra.Models;
using System.Linq;

namespace Steammostra.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        [BindProperty]
        public Logins Logins { get; set; }

        public IActionResult OnPost()
        {
            if (!ModelState.IsValid)
            {
                return Page();
            }

            _context.Logins.Add(Logins);
            _context.SaveChanges();

            return RedirectToPage("/Home"); // Redireciona após o cadastro
        }

        public IActionResult OnPostLogin()
        {
            // Verifica se o email e senha fornecidos estão corretos
            var usuario = _context.Logins
                .FirstOrDefault(u => u.email == Logins.email && u.senha == Logins.senha);

            if (usuario != null)
            {
                // Exibe mensagem de boas-vindas
                TempData["BemVindo"] = $"Bem-vindo, {usuario.nome}!";
                return RedirectToPage("/Home"); // Redireciona para a página inicial
            }

            ModelState.AddModelError(string.Empty, "E-mail ou senha incorretos.");
            return Page();
        }
    }
}
