namespace PacificTours.Models
{
    public class Basket
    {
        public int Id { get; set; }
        public string CustomerId { get; set; }
        public string BasketItem { get; set; }
        public string ItemType { get; set; }
        public int Cost { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
    }
}
