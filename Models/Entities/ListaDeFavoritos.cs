namespace fachaMotos.Models.Entities
{
    public class ListaDeFavoritos
    {
        public int Id { get; set; }

        public int UserId { get; set; }
        public User Usuario { get; set; }

        // Muchas motos en la lista
        public List<MotoFavorita> MotosFavoritas { get; set; } = new List<MotoFavorita>();
    }

}
