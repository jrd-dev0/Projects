using CarParkingApp.Models.Enums;

namespace CarParkingApp.Models
{
    public class Car
    {
        public int Id { get; set; }
        public string Manufacturer { get; set; }
        public string Model { get; set; }
        public string LicencePlate { get; set; }
        public Color Color { get; set; }
    }
}