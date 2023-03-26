namespace EventsApp.Models
{
    public class ParticipantsModel
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string PhoneNumber { get; set; }
        public string EmailAddress { get; set; }

        public EventsModel Event { get; set; }   
    }
}
