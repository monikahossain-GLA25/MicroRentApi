namespace MicroRentApi.Models.Domain
{
    public class User
    {
        public Guid Id { get; set; }

        public string Code { get; set; }

        public string Name { get; set; }

        public string? UserImageUrl { get; set; }
    }
}
