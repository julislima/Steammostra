using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc;
using Steammostra.Models;

namespace Steammostra.Pages
{
    public class CreateModel : PageModel
    {
        private readonly ApplicationDbContext _context;

        // Construtor que recebe o contexto do banco de dados
        public CreateModel(ApplicationDbContext context)
        {
            _context = context;
        }

        // Propriedade bindable para receber os dados do formulário
        [BindProperty]
        public Logins Logins { get; set; }

        // Método chamado ao submeter o formulário
        public IActionResult OnPost()
        {
            // Verifica se o estado do modelo é válido
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Adiciona o login ao banco de dados
            _context.Logins.Add(Logins);
            _context.SaveChanges();

            // Redireciona para a página inicial após o cadastro
            return RedirectToPage("/home"); // Assegure-se de que "/home" é a página correta para onde redirecionar
        }
    }
}
