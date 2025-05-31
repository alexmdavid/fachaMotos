using fachaMotos.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace fachaMotos.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Admin> Admins { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ListaDeFavoritos> ListasDeFavoritos { get; set; }
        public DbSet<MotoFavorita> MotosFavoritas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<MotoFavorita>()
                .HasKey(mf => new { mf.ListaDeFavoritosId, mf.MotoId });

            modelBuilder.Entity<MotoFavorita>()
                .HasOne(mf => mf.ListaDeFavoritos)
                .WithMany(lf => lf.MotosFavoritas)
                .HasForeignKey(mf => mf.ListaDeFavoritosId);

            modelBuilder.Entity<MotoFavorita>()
                .HasOne(mf => mf.Moto)
                .WithMany(m => m.MotosFavoritas)
                .HasForeignKey(mf => mf.MotoId);
        }



    }
}
