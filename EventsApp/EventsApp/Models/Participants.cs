namespace EventsApp.Models
{
    public class Participants
    {
        public string ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public Events Event { get; set; }   
    }
}
