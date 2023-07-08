namespace Entitities.Entidades
{
    public class UsuarioEmpresa
    {
        public string UsuarioId { get; set; }
        public ApplicationUser Usuario { get; set; }

        public int EmpresaId { get; set; }
        public Empresas Empresa { get; set; }
    }
}
