using Microsoft.EntityFrameworkCore;

namespace aspiranteAPI.Models
{
    public class AspiranteContext : DbContext
    {
        public AspiranteContext(DbContextOptions<AspiranteContext> options)
            : base(options)
        {
        }

        public DbSet<Aspirante> Aspirantes { get; set; }
    }
}
