using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace fachaMotos.Models.Entities
{
    public class User
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }

        public string Nombre { get; set; }

        public string Correo { get; set; }

        public string Clave { get; set; }

        public static implicit operator User(Review v)
        {
            throw new NotImplementedException();
        }
    }
}
