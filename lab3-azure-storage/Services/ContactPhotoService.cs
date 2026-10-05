using Azure.Storage.Blobs;

namespace labCloud_3.Services
{
    public class ContactPhotoService
    {
        private readonly BlobContainerClient _containerClient;

        public ContactPhotoService(string connectionString, string containerName)
        {
            var serviceClient = new BlobServiceClient(connectionString);
            _containerClient = serviceClient.GetBlobContainerClient(containerName);
            _containerClient.CreateIfNotExists();
        }

        public async Task<string> UploadPhotoAsync(string contactId, string localFilePath)
        {
            string blobName = $"{contactId}{Path.GetExtension(localFilePath)}";
            var blobClient = _containerClient.GetBlobClient(blobName);

            using FileStream fileStream = File.OpenRead(localFilePath);
            await blobClient.UploadAsync(fileStream, overwrite: true);

            return blobClient.Uri.ToString();
        }

        public async Task DeletePhotoAsync(string contactId)
        {
            var blobs = _containerClient.GetBlobsAsync();

            await foreach (var blobItem in blobs)
            {
                if (blobItem.Name.StartsWith(contactId))
                {
                    await _containerClient.DeleteBlobIfExistsAsync(blobItem.Name);
                }
            }
        }
    }
}