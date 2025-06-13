using fachaMotos.Models.Entities;
using Microsoft.EntityFrameworkCore;


namespace fachaMotos.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<User> Users { get; set; }
        public DbSet<Bike> Bikes { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<UserBikeFavorita> ListasDeFavoritos { get; set; }
        public DbSet<ComentarioBlog> ComentariosBlog { get; set; }
        public DbSet<ComentarioMoto> ComentariosMoto { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserBikeFavorita>()
                .HasKey(f => new { f.UserId, f.BikeId });

            modelBuilder.Entity<UserBikeFavorita>()
                .HasOne(f => f.User)
                .WithMany(u => u.MotosFavoritas)
                .HasForeignKey(f => f.UserId);

            modelBuilder.Entity<UserBikeFavorita>()
                .HasOne(f => f.Bike)
                .WithMany(b => b.UsuariosQueLaTienenComoFavorita)
                .HasForeignKey(f => f.BikeId);

            modelBuilder.Entity<ComentarioBlog>()
               .HasOne(c => c.Blog)
               .WithMany(b => b.Comentarios)
               .HasForeignKey(c => c.BlogId)
               .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ComentarioBlog>()
                .HasOne(c => c.Usuario)
                .WithMany(u => u.ComentariosEnBlogs)
                .HasForeignKey(c => c.UsuarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ComentarioMoto>()
                .HasOne(c => c.Bike)
                .WithMany(b => b.Comentarios)
                .HasForeignKey(c => c.BikeId);

            modelBuilder.Entity<ComentarioMoto>()
                .HasOne(c => c.user)
                .WithMany(u => u.ComentariosEnMotos)
                .HasForeignKey(c => c.UserId)
                .OnDelete(DeleteBehavior.Cascade);
        }

    }
}
