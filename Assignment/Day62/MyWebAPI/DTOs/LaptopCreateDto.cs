namespace MyWebAPI.DTOs
{
    public class LaptopCreateDto
    {
        public string Brand { get; set; } = string.Empty;
        public string Model { get; set; } = string.Empty;
        public int Price { get; set; }
    }
}
