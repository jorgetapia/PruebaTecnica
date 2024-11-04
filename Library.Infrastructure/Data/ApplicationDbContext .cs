
using Library.Domain.Entities;
using Microsoft.EntityFrameworkCore;
namespace Library.Infrastructure.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

       
        public DbSet<Book> Books { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

           
            modelBuilder.Entity<Book>(entity =>
            {
                entity.ToTable("Books");

                entity.HasKey(e => e.Id);

                entity.Property(e => e.Titulo)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.Autor)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.Genero)
                    .IsRequired();

                entity.Property(e => e.FechaPublicacion)
                    .HasColumnType("DATE");

                entity.Property(e => e.Sinopsis)
                    .HasMaxLength(500);
            });
        }
    }
}
