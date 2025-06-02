namespace fachaMotos.Models.Entities
{
    public class UserBikeFavorita
    {
        public int UserId { get; set; }
        public User User { get; set; }

        public int BikeId { get; set; }
        public Bike Bike { get; set; }
    }
}
