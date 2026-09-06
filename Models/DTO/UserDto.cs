namespace MicroRentApi.Models.DTO
{
    public class UserDto
    {
        public Guid Id { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? UserImageUrl { get; set; }
    }
}
