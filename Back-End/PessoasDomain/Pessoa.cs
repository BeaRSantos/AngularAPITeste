using System;

namespace CRUDAPI.Domain
{
    public class Pessoa
    {
        public int PessoaId { get; set; }

        public string Nome { get; set; }

        public string CPF { get; set; }

        public string Email { get; set; }

        public string Telefone { get; set; }

        public string Sexo { get; set; }

        public DateTime DataNascimento { get; set; }
    }
}
