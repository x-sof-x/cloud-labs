namespace labCloud_3.Models
{
    public class ContactModel
    {
        public string LastName { get; set; } = string.Empty;
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public List<string> Phones { get; set; } = new List<string>();
        public string PhotoUrl { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}".Trim();
        }
    }
}