using AListClient.Models.FileServer.FileLists;

namespace AListClient.Contracts;

public interface ICloudFileService
{
    public Task<FsReponse> GetFolderList(FsRequest request, CancellationToken token = default);
}
