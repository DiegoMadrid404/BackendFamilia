namespace Proyecto.Datos.Contexto
{
    using Microsoft.EntityFrameworkCore;
    public partial class ContextoProyecto
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=EIVITUX;Initial Catalog=Familia;Integrated Security=True;Encrypt=False;TrustServerCertificate=True;");
            }
        }
    }
}