using Azure;
using Azure.Data.Tables;

namespace labCloud_3.Models
{
    public class ContactEntity : ITableEntity
    {
        public string PartitionKey { get; set; } = string.Empty;
        public string RowKey { get; set; } = string.Empty;
        public DateTimeOffset? Timestamp { get; set; }
        public ETag ETag { get; set; }

        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public string Address { get; set; } = string.Empty;
        public string PhonesCsv { get; set; } = string.Empty;
        public string PhotoUrl { get; set; } = string.Empty;

        public override string ToString()
        {
            return $"{LastName} {FirstName} {MiddleName}".Trim();
        }
    }
}