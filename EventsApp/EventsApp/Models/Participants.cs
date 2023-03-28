using System.ComponentModel.DataAnnotations.Schema;

namespace EventsApp.Models
{
    public class Participants
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        [ForeignKey("EventId")]
        public Events? Event { get; set; }
        public int EventId { get; set; }
    }
}
