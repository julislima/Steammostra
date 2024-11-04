namespace Steammostra.Models
{
    public class Logins
    {
        public int id { get; set; }
        public string nome { get; set; } // Tipo string para o nome
        public string senha { get; set; } // Aqui está a correção: senha deve ser string
        public string email { get; set; } // Tipo string para o email
    }
}
