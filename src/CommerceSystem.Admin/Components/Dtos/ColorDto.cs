namespace CommerceSystem.Admin.Components.Dtos
{
    public class ColorDto
    {
        public Guid Id { get; set; }

        public string Name { get; set; } = string.Empty;

        public string? HexCode { get; set; }
    }
}
