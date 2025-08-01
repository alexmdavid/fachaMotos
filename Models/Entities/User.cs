﻿using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Runtime.Serialization;

namespace fachaMotos.Models.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        [MaxLength(100)]
        [Required]
        public string Nombre { get; set; }

        [MaxLength(160)]
        [EmailAddress]
        [Required]
        public string Correo { get; set; }

        [MinLength(8)]
        [Required]
        public string ClaveHash { get; set; }
        public string? ImagenPerfilUrl { get; set; } = null;
        public List<UserBikeFavorita> MotosFavoritas { get; set; } = new List<UserBikeFavorita>();

        [Required]
        public string Rol { get; set; }= "Administrador";
        public List<ComentarioBlog> ComentariosEnBlogs { get; set; } = new List<ComentarioBlog>();
        public List<Review> Reviews { get; set; } = new List<Review>();
        public List<ReviewReaction> ReviewReacciones { get; set; } = new List<ReviewReaction>();
        public List<ComentarioBlogReaction> ComentarioBlogReacciones { get; internal set; } = new List<ComentarioBlogReaction>();
    }
}
