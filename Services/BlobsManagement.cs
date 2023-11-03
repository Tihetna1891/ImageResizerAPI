using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Azure.Storage.Blobs;
using ImageProcessing2.API.Services.Interfaces;

namespace ImageProcessing2.API.Services;

public class BlobsMAnagement : IBlobsManagement 
{
    public async Task<string> UploadFile(string containerName, string fileName, byte[] file, string connectionString)
    {
        //create a container reference
        var container = new BlobContainerClient(connectionString, containerName);
        await container.CreateIfNotExistsAsync();
        await container.SetAccessPolicyAsync(Azure.Storage.Blobs.Models.PublicAccessType.Blob);

        var blob = container.GetBlobClient(fileName);

        Stream str = new MemoryStream(file);

        await blob.UploadAsync(str);

        return blob.Uri.AbsoluteUri;
    }
}