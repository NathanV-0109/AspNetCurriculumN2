using System;

namespace CadCurriculoMVC.Models
{
    public class PessoaViewModel
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public string CPF { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }
        public double PretensaoSalarial { get; set; }
        public string CargoPretendido { get; set; }
    }
}