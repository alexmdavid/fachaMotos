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
        public DbSet<ComentarioBlogReaction> ComentariosBlogReaction { get; set; }
        public DbSet<Blog> Blogs { get; set; }
        public DbSet<ReviewReaction> ReviewReactions { get; set; }

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

            
            modelBuilder.Entity<ReviewReaction>()
                .HasKey(rr => rr.Id);

            modelBuilder.Entity<ReviewReaction>()
                .HasOne(rr => rr.Review)
                .WithMany(r => r.Reacciones)
                .HasForeignKey(rr => rr.ReviewId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ReviewReaction>()
                .HasOne(rr => rr.Usuario)
                .WithMany(u => u.ReviewReacciones)
                .HasForeignKey(rr => rr.UserId)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<ComentarioBlogReaction>()
                .HasKey(cbr => cbr.Id);

            modelBuilder.Entity<ComentarioBlogReaction>()
                .HasOne(cbr => cbr.Comentario)
                .WithMany(cb => cb.Reacciones)
                .HasForeignKey(cbr => cbr.ComentarioId)
                .OnDelete(DeleteBehavior.Cascade);

            modelBuilder.Entity<ComentarioBlogReaction>()
                .HasOne(cbr => cbr.Usuario)
                .WithMany(u => u.ComentarioBlogReacciones)
                .HasForeignKey(cbr => cbr.UserId)
                .OnDelete(DeleteBehavior.Restrict);

        }

    }
}
