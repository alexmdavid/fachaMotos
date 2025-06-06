﻿using fachaMotos.Models.Entities;
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
        }

    }
}
