namespace MyLinqF1.Models
{
    public class Pilot
    {
        public int Id { get; set; }
        public string FirstName { get; set; }     // ex. "Lewis"
        public string LastName { get; set; }      // ex. "Hamilton"
        public string Nationality { get; set; }   // ex. "Britannique"
        public int TeamId { get; set; }           // FK vers une Team
    }
}