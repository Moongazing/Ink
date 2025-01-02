using Amazon.S3;
using Amazon.S3.Model;
using Amazon.S3.Transfer;
using Microsoft.Extensions.Options;
using Moongazing.Ink.Infrastructure.Aws.Configurations;

namespace Moongazing.Ink.Infrastructure.Aws.Services;

public class StorageService : IStorageService
{
    private readonly AwsS3Settings awsS3Settings;
    private readonly IAmazonS3 s3Client;
    private readonly TransferUtility transferUtility;

    public StorageService(IOptions<AwsS3Settings> awsS3Settings,
                          IAmazonS3 s3Client)
    {
        this.awsS3Settings = awsS3Settings.Value;
        this.s3Client = s3Client;
        transferUtility = new(s3Client);
    }

    public async Task<string> UploadProfilePicture(byte[] fileData, Guid userId)
    {
        var fileName = $"{Guid.NewGuid()}/User/{userId}";

        var key = GenerateFileKey(fileName);

        using var stream = new MemoryStream(fileData);
        var request = new TransferUtilityUploadRequest
        {
            InputStream = stream,
            Key = key,
            BucketName = awsS3Settings.BucketName,
            CannedACL = S3CannedACL.PublicRead
        };

        await transferUtility.UploadAsync(request).ConfigureAwait(false);

        return GenerateFileUrl(key);
    }
    public async Task<string> UploadFileAsync(byte[] fileData)
    {
        var fileName = $"{Guid.NewGuid()}";

        var key = GenerateFileKey(fileName);

        using var stream = new MemoryStream(fileData);
        var request = new TransferUtilityUploadRequest
        {
            InputStream = stream,
            Key = key,
            BucketName = awsS3Settings.BucketName,
            CannedACL = S3CannedACL.PublicRead
        };

        await transferUtility.UploadAsync(request).ConfigureAwait(false);

        return GenerateFileUrl(key);
    }

    public async Task<string> UpdateFileAsync(string key, byte[] fileData)
    {
        await DeleteFileAsync(key).ConfigureAwait(false);
        return await UploadFileAsync(fileData).ConfigureAwait(false);
    }

    public async Task<bool> DeleteFileAsync(string key)
    {
        var deleteObjectRequest = new DeleteObjectRequest
        {
            BucketName = awsS3Settings.BucketName,
            Key = key
        };

        var response = await s3Client.DeleteObjectAsync(deleteObjectRequest).ConfigureAwait(false);
        return response.HttpStatusCode == System.Net.HttpStatusCode.NoContent;
    }
    private static string GenerateFileKey(string fileName)
    {
        return $"{Guid.NewGuid()}_{fileName}";
    }

    private string GenerateFileUrl(string key)
    {
        return $"{awsS3Settings.ServiceURL}/{awsS3Settings.BucketName}/{key}";
    }

    public string ExtractFileKeyFromUrl(string url)
    {
        var uri = new Uri(url);
        return uri.AbsolutePath[(uri.AbsolutePath.LastIndexOf('/') + 1)..];
    }

    public async Task<List<string>> UploadFilesAsync(Dictionary<string, byte[]> files)
    {
        var urls = new List<string>();

        foreach (var kvp in files)
        {
            var url = await UploadFileAsync(kvp.Value);
            urls.Add(url);
        }

        return urls;
    }

    public async Task<List<string>> UpdateFilesAsync(Dictionary<string, byte[]> files)
    {
        var urls = new List<string>();

        foreach (var kvp in files)
        {
            var url = await UpdateFileAsync(kvp.Key, kvp.Value);
            urls.Add(url);
        }

        return urls;
    }

    public async Task<List<bool>> DeleteFilesAsync(ICollection<string> keys)
    {
        var results = new List<bool>();

        foreach (var key in keys)
        {
            var result = await DeleteFileAsync(key);
            results.Add(result);
        }

        return results;
    }
}
