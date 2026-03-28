namespace LogiTrack.Tracking.Models
{
    public class GpsData
    {
        public int Id { get; set; }
        public int TruckId { get; set; }
        public string TruckName { get; set; }
        public double Latitude { get; set; }
        public double Longitude { get; set; }
        public DateTime Timestamp { get; set; }
        public double Speed { get; set; }
    }
}
