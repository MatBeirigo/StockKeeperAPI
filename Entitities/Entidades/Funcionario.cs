namespace Entitities.Entidades
{
    public class Funcionario
    {
        public int Id { get; set; }
        public string Nome { get; set; }    
        public string Cpf { get; set; } 
        public string Cargo { get; set; }
        public string Username { get; set; }
        public string Senha { get; set; }
        public int Tipo { get; set; }
        public Funcionario() { }
    }
}
