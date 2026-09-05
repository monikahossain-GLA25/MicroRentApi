namespace MicroRentApi.Models.Domain
{
    public class Rental
    {
        public Guid Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public double LengthInKm { get; set; }

        public string? RentalImageUrl { get; set; }

        public Guid PaymentId { get; set; }

        public Guid UserId { get; set; }


        // Navigation Properties

        public Payment Payment { get; set; }

        public User User { get; set; }
    }
}
