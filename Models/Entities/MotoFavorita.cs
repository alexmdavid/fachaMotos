namespace fachaMotos.Models.Entities
{
    public class MotoFavorita
    {
        public int ListaDeFavoritosId { get; set; }
        public ListaDeFavoritos ListaDeFavoritos { get; set; }

        public int MotoId { get; set; }
        public Bike Moto { get; set; }
    }

}
