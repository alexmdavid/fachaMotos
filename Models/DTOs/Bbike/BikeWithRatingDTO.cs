using fachaMotos.Models.DTOs.Review;
using fachaMotos.Models.Entities;

namespace fachaMotos.Models.DTOs.Bbike
{
    public class BikeWithRatingDTO
    {
        public Bike Bike { get; set; }
        public double AvgRating { get; set; }
        public List<ReviewDTO> Reviews { get; set; } = new List<ReviewDTO>();
    }


}
