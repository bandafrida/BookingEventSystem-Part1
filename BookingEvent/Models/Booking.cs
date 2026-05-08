using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingEvent.Models
{
    public class Booking
    {
        [Key]
        public int BookingId { get; set; }

        public DateTime BookingDate { get; set; }

        [ForeignKey("VenueId")]
        public int VenueId { get; set; }
        public Venue Venue { get; set; }

        [ForeignKey("EventId")]
        public int EventId { get; set; }
        public Event Event { get; set; }
    }
}