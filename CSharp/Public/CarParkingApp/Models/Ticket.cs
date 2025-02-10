namespace CarParkingApp.Models
{
    public class Ticket
    {
        public int CarId { get; set; }
        public Car Car { get; set; }

        public int SpaceId { get; set; }
        public Space Space { get; set; }

        public int EntryId { get; set; }
        public Entry Entry { get; set; }


    }
}
