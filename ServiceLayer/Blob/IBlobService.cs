using Azure.Storage.Blobs.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServiceLayer.Blob
{
    public interface IBlobService
    {
        public Task UploadFileBlobAsync(string filePath, string fileName);
        public Task<BlobInfo> GetBlobAsync(string fileName);
    }
}
