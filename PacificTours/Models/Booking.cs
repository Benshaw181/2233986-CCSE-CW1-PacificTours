using System.ComponentModel.DataAnnotations;

namespace PacificTours.Models
{
    public class Booking
    {
        public int Id { get; set; }
        public string BookingType { get; set; }
        public string BookingDetails { get; set; }
        public string BookingCustomerId { get; set; }
        public double BookingPrice { get; set; }
        public DateTime BookingStartDate { set; get; }
        public DateTime BookingEndDate { set; get; }
        public double BookingAmountPaid { get; set; }
        public DateTime BookingPackageDate { get; set; }
    }
}
