using Azure.Data.Tables;
using labCloud_3.Models;

namespace labCloud_3.Services
{
    public class ContactTableService
    {
        private readonly TableClient _tableClient;

        public ContactTableService(string connectionString, string tableName)
        {
            _tableClient = new TableClient(connectionString, tableName);
            _tableClient.CreateIfNotExists();
        }

        public async Task AddContactAsync(ContactEntity contact)
        {
            await _tableClient.AddEntityAsync(contact);
        }

        public async Task<List<ContactEntity>> GetAllContactsAsync()
        {
            var result = new List<ContactEntity>();
            var query = _tableClient.QueryAsync<ContactEntity>();

            await foreach (var entity in query)
            {
                result.Add(entity);
            }

            return result;
        }

        public async Task UpdateContactAsync(ContactEntity contact)
        {
            await _tableClient.UpdateEntityAsync(contact, contact.ETag, TableUpdateMode.Replace);
        }

        public async Task DeleteContactAsync(string partitionKey, string rowKey)
        {
            await _tableClient.DeleteEntityAsync(partitionKey, rowKey);
        }
    }
}