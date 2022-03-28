namespace Projeto.Redis.Domain.Entities
{
    public class Cliente : BaseEntity
    {
        public Cliente(string nome, string email, string telefone, string telefone2, string rua, string bairro, string cep, string cidade, string estado)
        {
            Nome = nome;
            Email = email;
            Telefone = telefone;
            Telefone2 = telefone2;
            Rua = rua;
            Bairro = bairro;
            Cep = cep;
            Cidade = cidade;
            Estado = estado;
        }

        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public string Telefone2 { get; set; }
        public string Rua { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
    }
}