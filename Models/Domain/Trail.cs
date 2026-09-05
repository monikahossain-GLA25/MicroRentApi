namespace MicroRentApi.Models.Domain
{
    public class Trail
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double DistanceInKm { get; set; }

        public string? ImageUrl { get; set; }


        public Guid DestinationId { get; set; }

        public Guid TrailDifficultyId { get; set; }


        // Navigation Properties

        public Destination Destination { get; set; }

        public TrailDifficulty TrailDifficulty { get; set; }
    }
}
