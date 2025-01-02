namespace Moongazing.Ink.Infrastructure.Aws.Services;

public interface IStorageService
{
    Task<string> UploadFileAsync(byte[] fileData);
    Task<string> UpdateFileAsync(string key, byte[] fileData);
    Task<bool> DeleteFileAsync(string key);
    string ExtractFileKeyFromUrl(string url);
    Task<List<string>> UploadFilesAsync(Dictionary<string, byte[]> files);
    Task<List<string>> UpdateFilesAsync(Dictionary<string, byte[]> files);
    Task<List<bool>> DeleteFilesAsync(ICollection<string> keys);
    Task<string> UploadProfilePicture(byte[] fileData, Guid userId);
}
