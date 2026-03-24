namespace MyWebAPI.DTOs
{
    public class LaptopReadDto
    {
        public int Id { get; set; }
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}
