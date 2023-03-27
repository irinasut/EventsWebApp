using System.ComponentModel.DataAnnotations.Schema;

namespace EventsApp.Models
{
    public class Participants
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public int EventId { get; set; }
        [ForeignKey("EventId")]
        public virtual Events Event { get; set; }   
    }
}
