namespace WebApi.Models
{
    public class Login
    {
        public int? IdEmpresa { get; set; }
        public string? CodigoEmpresa { get; set; }
        public string? Usuario { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
    }
}
