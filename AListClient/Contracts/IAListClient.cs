using AListClient.Models.Driver.DriverTemplate;
using AListClient.Models.Storage.StorageList;
using AListClient.Models.UserAuth.Login;
using AListClient.Models.UserAuth.Me;

namespace AListClient.Contracts;

public interface IAListClient
{
    public IHttpClientProvider HttpClientProvider { get; }

    public Task<LoginReponse> Login(
        string username,
        string password,
        CancellationToken cancellationToken = default
    );

    public Task<LoginReponse> LoginHash(
        string username,
        string password,
        CancellationToken cancellationToken = default
    );

    public Task<MeReponse> GetMe(CancellationToken cancellationToken = default);

    public void SetIp(string Ip);

    public string GetIp();

    public Task<DriverTemplateReponse> GetDriverTemplates(CancellationToken token = default);

    public Task<List<string>> GetDriverNames(CancellationToken token = default);

    public Task<DriverTemplate> GetDriverTemplate(
        string driverName,
        CancellationToken token = default
    );

    public Task<StorageListReponse> GetStorageList(
        int page = 1,
        int pagesize = 1,
        CancellationToken token = default
    );
}
