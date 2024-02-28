using AListClient.Models.FileServer.FileLists;

namespace AListClient.Contracts.Services;

public class CloudFileService : ICloudFileService
{
    public CloudFileService(IAListClient aListClient)
    {
        AListClient = aListClient;
    }

    public IAListClient AListClient { get; }

    public async Task<FsReponse> GetFolderList(FsRequest request,CancellationToken token = default)
    {
        var resquest = AListClient.HttpClientProvider.PostRequestMessage(
            $"http://{AListClient.GetIp()}/api/fs/list",
            request,
            true,
            false
        );

        var reponse =  await AListClient.HttpClientProvider.Paser<FsReponse>(await AListClient.HttpClientProvider.SendAsync(resquest,token),token);
        if (reponse.Code == 200)
            return reponse.Data;
        return default;
    }
}
