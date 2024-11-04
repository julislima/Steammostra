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

        // Propriedade bindable para receber os dados do formul�rio
        [BindProperty]
        public Logins Logins { get; set; }

        // M�todo chamado ao submeter o formul�rio
        public IActionResult OnPost()
        {
            // Verifica se o estado do modelo � v�lido
            if (!ModelState.IsValid)
            {
                return Page();
            }

            // Adiciona o login ao banco de dados
            _context.Logins.Add(Logins);
            _context.SaveChanges();

            // Redireciona para a p�gina inicial ap�s o cadastro
            return RedirectToPage("/home"); // Assegure-se de que "/home" � a p�gina correta para onde redirecionar
        }
    }
}
