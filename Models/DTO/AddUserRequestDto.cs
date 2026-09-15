namespace MicroRentApi.Models.DTO
{
    public class AddUserRequestDto
    {
        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public string? UserImageUrl { get; set; }
    }
}
