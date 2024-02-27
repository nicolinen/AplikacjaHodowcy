using AplikacjaHodowcy.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace AplikacjaHodowcy.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Miot> Mioty { get; set; }
        public virtual DbSet<Linia> Linie { get; set; }
        public virtual DbSet<Szczeniak> Szczeniaki { get; set; }
        public virtual DbSet<Konkurs> Konkursy { get; set; }
    }
}