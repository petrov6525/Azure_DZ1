// See https://aka.ms/new-console-template for more information
using Azure.Storage.Blobs;
using Azure.Storage.Blobs.Models;
using Azure;


string conString = "DefaultEndpointsProtocol=https;AccountName=daryncevstudent;AccountKey=Di2rFiceS4dsU8ghZkk18EcY/CacChk4QLK8keOgLyLQH8S+XuG/6ngZvEFLarD0fYfM33Pvq+0i+ASto3vfTg==;EndpointSuffix=core.windows.net";

var blobServiceClient = new BlobServiceClient(conString);

string containerName = "conn1b54ff75-36b9-405c-943e-bbba7cb643aa";


string fileName = "Test.txt";


BlobContainerClient blobContainerClient = blobServiceClient.GetBlobContainerClient(containerName);



BlobClient blobClient = blobContainerClient.GetBlobClient(fileName);


Response<BlobDownloadInfo> downloadResponse = await blobClient.DownloadAsync();
BlobDownloadInfo downloadInfo = downloadResponse.Value;

string contents;

using (var reader = new StreamReader(downloadInfo.Content))
{
    contents = await reader.ReadToEndAsync();
}
Console.WriteLine("File contents: " + contents);


Console.ReadLine();


