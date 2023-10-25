using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using ServiceLayer.Extensions;

namespace ServiceLayer.Blob
{
    public class BlobService : IBlobService
    {
        private readonly BlobServiceClient _blobServiceClient;

        public BlobService(BlobServiceClient blobServiceClient)
        {
            _blobServiceClient = blobServiceClient;
        }

        public async Task<BlobInfo> GetBlobAsync(string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("realestate");
            var blobClient = containerClient.GetBlobClient(fileName);

            var blobDownloadInfo = await blobClient.DownloadAsync();

            return new BlobInfo()
            {
                Content = blobDownloadInfo.Value.Content,
                ContentType = blobDownloadInfo.Value.ContentType
            };
        }

        public async Task UploadFileBlobAsync(string filePath, string fileName)
        {
            var containerClient = _blobServiceClient.GetBlobContainerClient("realestate");
            
            var blobClient = containerClient.GetBlobClient(Guid.NewGuid().ToString());

            await blobClient.UploadAsync(filePath, new BlobHttpHeaders { ContentType = filePath.GetContentType() });
        }
    }
}
