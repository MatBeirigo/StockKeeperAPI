namespace Entitities.Entidades
{
    public class UsuarioEstoque
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public enum TipoUsuario
        {
            Estoque,
            GestaoDeCompras,
            NotaFiscal,
            Faturamento,
            Financeiro,
            CRM,
            RecursosHumanos,
            Qualidade,
            Logistica,
        }
    }
}
